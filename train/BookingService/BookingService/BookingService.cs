﻿using AutoMapper;
using BookingService.HeaderService;
using BookingService.Model;
using BookingService.Publisher;
using BookingService.Subscriber;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly IMongoCollection<Reservation> _reservation;
        private readonly IHeaderService _headerService;
        private readonly IPublisher _publicher;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingService> _logger;

        public BookingService(IReservationSettings settings, IHeaderService headerService, IPublisher publicher, IMapper mapper,
            ILogger<BookingService> logger)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _reservation = database.GetCollection<Reservation>(settings.ReservationCollectionName);
            _headerService = headerService;
            _publicher = publicher;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> CreateReservation(BookingRequestModel model)
        {
            try
            {

                VerificationRoomId verify = new VerificationRoomId() { RoomId = model.RoomId.ToString() };

                var price = await _publicher.VerifyRoomId(verify);
                var message = "Room was not found!!!!!";


                if (price == message)
                {
                    throw new Exception(message);
                }

                if (model.ReservFinishedDate <= model.ReservStartDate)
                    throw new Exception("Start date can not be biggest than finish date");

                var filter = Builders<Reservation>.Filter.Eq("RoomId", model.RoomId);

                var listReservations = _reservation.Find(filter).ToList();
                //if (reservation != null) throw new Exception("Room can't be booked");

                foreach (var reservation in listReservations)
                {
                    if (model.ReservStartDate >= reservation.ReservStartDate &&
                        model.ReservStartDate <= reservation.ReservFinishedDate ||
                        model.ReservFinishedDate >= reservation.ReservStartDate &&
                        model.ReservFinishedDate <= reservation.ReservFinishedDate)
                    {
                        throw new Exception("Room can't be booked");
                    }
                    else
                    {
                        if (model.ReservStartDate <= reservation.ReservStartDate &&
                            model.ReservFinishedDate >= reservation.ReservFinishedDate)
                        {
                            throw new Exception("Room can't be booked");
                        }
                    }
                }


                var startDate = DateTime.UtcNow;
                var finishDate = startDate.AddMinutes(2);
                var userId = _headerService.GetUserId();
                var numberOfNights = (model.ReservFinishedDate - model.ReservStartDate).Days;
                var priceForNight = Convert.ToDecimal(price);
                var amountPaid = numberOfNights * priceForNight;

                var newReservation = new Reservation()
                {
                    Id = Guid.NewGuid(),
                    RoomId = model.RoomId,
                    UserId = userId,
                    StartDateOfBooking = startDate,
                    FinishDateOfBooking = finishDate,
                    ReservStartDate = model.ReservStartDate,
                    ReservFinishedDate = model.ReservFinishedDate,
                    NumberOfNights = numberOfNights,
                    AmountPaid = amountPaid,
                    Status = Status.Booked
                };


                _reservation.InsertOne(newReservation);
                var newTransferReservation = new TransferReservation()
                {
                    RoomId = newReservation.RoomId
                };

                return "Reservation was added successfully";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CancelReservation(Guid id)
        {
            try
            {
                var filter = Builders<Reservation>.Filter.Eq("Id", id);
                var reservation = _reservation.Find(filter).FirstOrDefault();
                if (reservation == null) throw new Exception("Book doesn't existst");

                var newTransferReservation = new CancelReservation()
                {
                    RoomId = reservation.RoomId
                };

                _reservation.DeleteOne(Builders<Reservation>.Filter.Eq("Id", id));

                return "Reservation was canceled successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEnumerable<ReservationDTO> GetReservation()
        {
            try
            {
                var userId = _headerService.GetUserId();

                var filter = Builders<Reservation>.Filter.Eq("UserId", userId);
                var reservation = _reservation.Find(filter).ToList();


                var modelReservation = _mapper.Map<IEnumerable<ReservationDTO>>(reservation);

                return modelReservation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CheckReservation(JobMessage message)
        {
            //_logger.LogInformation("start check");
            var awaitMessage = "Let's check";

            if (message.Message == awaitMessage)
            {
                var allReservation = _reservation.Find(_ => true).ToList();

                foreach (var finishDates in allReservation)
                {
                    if (finishDates.Status == Status.Booked)
                    {

                        if (DateTime.UtcNow > finishDates.FinishDateOfBooking)
                        {
                            var id = finishDates.Id;
                            _reservation.DeleteOne(Builders<Reservation>.Filter.Eq("Id", id));

                        }
                    }
                }
            }
            //_logger.LogInformation("finish check");
        }

        public async Task DeleteReservation(DeleteMessage message)
        {
            var mes = "Let's delete";

            if (message.Message == mes)
            {
                var allReservation = _reservation.Find(_ => true).ToList();

                foreach (var finishDates in allReservation)
                {
                    if (finishDates.Status == Status.Paid)
                    {

                        if (DateTime.UtcNow == finishDates.ReservFinishedDate)
                        {
                            var id = finishDates.Id;
                            _reservation.DeleteOne(Builders<Reservation>.Filter.Eq("Id", id));
                        }
                    }
                }
            }

        }

        public async Task<string> VerifyReservationId(VerificationReservationId verification)
        {
            var verifyReservationId = verification.ReservationId;
            var verifyUserId = Guid.Parse(verification.UserId);
            var verify = Guid.Parse(verifyReservationId);



            var filter = Builders<Reservation>.Filter.Eq("Id", verify);
            var reservation = _reservation.Find(filter).FirstOrDefault();
            if (reservation == null)
            {
                var errBook = "Book doesn't existst";
                var serializeBook = JsonConvert.SerializeObject(errBook);
                return serializeBook;
            }


            if (verifyUserId == reservation.UserId)
            {
                var senderReservation = new SenderReservation()
                {
                    RoomId = reservation.RoomId,
                    ReservStartDate = reservation.ReservStartDate,
                    ReservFinishedDate = reservation.ReservFinishedDate,
                    NumberOfNights = reservation.NumberOfNights,
                    AmountPaid = reservation.AmountPaid
                };

                var send = JsonConvert.SerializeObject(senderReservation);

                return send;
            }

            var errorSend = "User doesn't existst";
            var err = JsonConvert.SerializeObject(errorSend);

            return err;
        }

        public async Task ChangeStatus(Payment payment)
        {
            var filter = Builders<Reservation>.Filter.Eq("Id", payment.ReservationId);
            var reservation = _reservation.Find(filter).FirstOrDefault();
            reservation.Status = Status.Paid;

            _reservation.ReplaceOne(filter, reservation);

        }
    }
}
