using System;

namespace Model

{
    public class Room
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int NumberOfPeople { get; set; }

        public decimal PriceForOneNight { get; set; }
    }
}
