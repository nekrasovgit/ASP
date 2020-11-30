using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IBookingRepository
    {
        Task AddRoomAsync(Room room);
        Task SaveChangeAsync();
    }
}
