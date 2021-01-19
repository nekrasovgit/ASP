using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Train.Model;

namespace Train.AccountService
{
    public class AccountService
    {
        public string HandlePayment(int amountPaid)
        {
            try
            {
                var newAccount = new UserAccount()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Summ = 500,
                };

                var cashStore = new CashStore()
                {
                    Store = 0
                };

                if (newAccount.Summ > amountPaid)
                {
                    cashStore.Store = newAccount.Summ - amountPaid;
                }
                else
                {
                    throw new Exception("I'm sorry, but it appears your account has insufficient funds.");
                }

                return "payment was successfully";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
