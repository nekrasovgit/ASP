using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Train.Model
{
    public class UserAccount
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Summ { get; set; }
    }
}
