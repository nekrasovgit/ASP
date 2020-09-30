using System;

namespace DNekrasovDB.Models.DB
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
