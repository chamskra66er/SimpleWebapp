﻿using CarServise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarServise.Models.CartViewModels
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public virtual void AddItem(Forum forum, int quantity)
        {
            var line = lineCollection
                .Where(p => p.Forum.Id == forum.Id)
                .FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine
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
        public IEnumerable<CartLine> Lines => lineCollection;

        public virtual void RemoveLine(Forum forum) =>
            lineCollection.RemoveAll(l => l.Forum.Id == forum.Id);
    }
}
