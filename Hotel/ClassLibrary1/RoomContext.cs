using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RoomContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }

        public RoomContext(DbContextOptions<RoomContext> options) : base(options)
        {

        }
    }
}
