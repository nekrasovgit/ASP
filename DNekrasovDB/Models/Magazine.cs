using System;

namespace DNekrasovDB.Models
{
    public class Magazine : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string RssUrl { get; set; }


    }
}
