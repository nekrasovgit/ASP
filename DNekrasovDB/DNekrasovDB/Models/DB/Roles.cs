﻿using System;
using System.Collections.Generic;

namespace DNekrasovDB.Models.DB
{
    public class Roles : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<UserRoles> UserRoles { get; set; }

        
    }
}
