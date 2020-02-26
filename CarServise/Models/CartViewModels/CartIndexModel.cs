using CarServise.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.CartViewModels
{
    public class CartIndexModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
