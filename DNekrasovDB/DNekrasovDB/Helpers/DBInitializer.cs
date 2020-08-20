using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNekrasovDB.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace DNekrasovDB.Helpers
{
    public class DBInitializer
    {
        private readonly GoodNewsContext _goodNewsContext;

        public DBInitializer(GoodNewsContext goodNewsContext)
        {
            _goodNewsContext = goodNewsContext;
        }

        public async Task Initialize()
        {
            if(!await _goodNewsContext.Roles.AnyAsync(r => r.Name.Equals("Admin")))
            {
                await _goodNewsContext.Roles.AddAsync(new Roles() { Id = Guid.NewGuid(), Name = "Admin" });
            }

            if (!await _goodNewsContext.Roles.AnyAsync(r => r.Name.Equals("User")))
            {
                await _goodNewsContext.Roles.AddAsync(new Roles() { Id = Guid.NewGuid(), Name = "User" });
            }

            if (_goodNewsContext.ChangeTracker.HasChanges())
                await _goodNewsContext.SaveChangesAsync();

            if (!await _goodNewsContext.Users.AnyAsync(u => u.Name.Equals("Administrator")))
            {
                var user = await _goodNewsContext.Users.AddAsync(new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    Password = "1231234",
                    Email = "d.a.04nekrasov@gmail.com"

                });

                var userRole = await _goodNewsContext.UserRoles.AddAsync(new UserRoles()
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Entity.Id,
                    RolesId = (await _goodNewsContext.Roles.FirstOrDefaultAsync(role => role.Name.Equals("Admin"))).Id
                });
            }

            if(_goodNewsContext.ChangeTracker.HasChanges())
                await _goodNewsContext.SaveChangesAsync();



            
        }
    }
}
