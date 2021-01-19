using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Train.AccountService;
using Train.Model;

namespace Train.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IAccountService _accountService;
        
        public OrderService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public string PayRoom(OrderModel model)
        {

            var newOrder = new Order()
            {
                Id = Guid.NewGuid(),
                UserId = model.UserId,
                RoomId = model.RoomId,
                ReservationId = model.ReservationId,
                ReservStartDate = model.ReservStartDate,
                ReservFinishDate = model.ReservFinishDate,
                PriceForNight = model.PriceForNight,
                DateOfPayment = model.DateOfPayment,
                AmountPaid = model.AmountPaid,
                
            };

            var response = _accountService.HandlePayment(newOrder.AmountPaid);

            return response;
        }
    }
}
