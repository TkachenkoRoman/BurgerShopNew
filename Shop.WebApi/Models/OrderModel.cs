using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.WebApi.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipAddress { get; set; }
        public DateTime ShippedDate { get; set; }
        public string DeliveryMan { get; set; }
        public string Status { get; set; }
        public double TotalPrice { get; set; }
    }
}