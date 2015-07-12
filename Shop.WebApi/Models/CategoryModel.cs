using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.WebApi.Models
{
    public class CategoryModel
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}