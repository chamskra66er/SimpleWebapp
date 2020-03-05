using CarServise.Data;
using CarServise.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarServise.Service
{
    public class OrderService : IOrder
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Order> Orders =>
            _context.Orders.Include(l => l.Lines).ThenInclude(o => o.Forum);

        public Order GetById(int id)
        {
            return _context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Forum));
            if (order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
