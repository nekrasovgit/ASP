using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Train.Model;

namespace Train.OrderService
{
    public interface IOrderService
    {
        string PayRoom(OrderModel model);
    }
}
