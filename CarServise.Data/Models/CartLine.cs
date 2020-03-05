using System;
using System.Collections.Generic;
using System.Text;

namespace CarServise.Data.Models
{
    public class CartLine
    {
        public int CartLineId{ get; set; }
        public Forum Forum { get; set; }
        public int Quantity { get; set; }
    }
}
