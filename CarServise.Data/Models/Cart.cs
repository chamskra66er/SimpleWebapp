using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarServise.Data.Models
{
    public class Cart
    {
        public int CartLineId { get; set; }
        public Forum Forum { get; set; }
        public int Quantity { get; set; }
    }
}
