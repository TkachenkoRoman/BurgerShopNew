using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.WebApi.Models
{
    public class cartItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
    }
}
