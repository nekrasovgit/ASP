using System;

namespace DNekrasovDB.Models.DB
{
    public class Magazine : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string RssUrl { get; set; }


    }
}
