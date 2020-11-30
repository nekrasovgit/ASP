using Model;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RoomContext _roomContext;

        public BookingRepository(RoomContext roomContext)
        {
            _roomContext = roomContext;
        }

        public async Task AddRoomAsync(Room room)
        {
            _roomContext.Rooms.Add(room);
            await SaveChangeAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _roomContext.SaveChangesAsync();

        }
    }
}
