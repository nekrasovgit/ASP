using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Train.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public Guid ReservationId { get; set; }
        public DateTime ReservStartDate { get; set; }
        public DateTime ReservFinishDate { get; set; }
        public int PriceForNight { get; set; }
        public DateTime DateOfPayment { get; set; }
        public int AmountPaid { get; set; }
        
    }
}
