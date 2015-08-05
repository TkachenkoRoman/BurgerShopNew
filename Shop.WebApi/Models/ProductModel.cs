using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.WebApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public byte CategoryID { get; set; }
        public string PictureDetailPath { get; set; }
    }
}