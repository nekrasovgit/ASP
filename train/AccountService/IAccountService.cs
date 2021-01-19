using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Train.AccountService
{
    public interface IAccountService
    {
        string HandlePayment(int amountPaid);
    }
}
