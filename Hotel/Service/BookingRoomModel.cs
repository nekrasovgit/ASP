using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class BookingRoomModel
    {
        public int Number { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int NumberOfPeople { get; set; }

        public decimal PriceForOneNight { get; set; }
    }
}
