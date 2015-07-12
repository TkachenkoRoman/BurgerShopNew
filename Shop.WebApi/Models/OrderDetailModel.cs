using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.WebApi.Models
{
    public class OrderDetailModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}