using CarServise.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarServise.Data
{
    public interface IOrder
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
        Order GetById(int id);
    }
}
