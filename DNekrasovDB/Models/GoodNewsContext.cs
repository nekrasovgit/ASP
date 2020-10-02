using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNekrasovDB.Models
{
    public class GoodNewsContext : DbContext
    {
        public DbSet<Comments> Comments { get; set; }

        public DbSet<Magazine> Magazines { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public GoodNewsContext(DbContextOptions<GoodNewsContext> options) : base(options)
        {

        }
    }
}
