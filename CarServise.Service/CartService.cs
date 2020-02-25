using CarServise.Data;
using CarServise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarServise.Service
{
    public class CartService : ICart
    {
        private List<Cart> lineCollection = new List<Cart>();
        public void AddItem(Forum forum, int quantity)
        {
            Cart line = lineCollection
                .Where(p => p.Forum.Id == forum.Id)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new Cart
                {
                    Forum = forum,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void Clear() => lineCollection.Clear();

        public virtual decimal ComputerTotalValue() =>
            lineCollection.Sum(e => Convert.ToInt32(e.Forum.Value) * e.Quantity);

        public virtual IEnumerable<Cart> Lines() => lineCollection;

        public virtual void RemoveLine(Forum forum) =>
            lineCollection.RemoveAll(l => l.Forum.Id == forum.Id);
    }
}
