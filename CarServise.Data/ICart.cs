using CarServise.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServise.Data
{
    public interface ICart
    {
        void AddItem(Forum forum, int quantity);
        void RemoveLine(Forum forum);
        decimal ComputerTotalValue();
        void Clear();
        IEnumerable<Cart> Lines();

    }
}
