using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Data.Models;
using Shop.Data;

namespace Shop.WebApi.Models
{
    public class ModelFactory
    {
        IShopRepository _repo;
        public ModelFactory(IShopRepository repo)
        {
            _repo = repo;
        }

        public ProductModel Create(Products product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                PicturePath = product.PicturePath,
                CategoryID = product.CategoryID
            };
        }

        public OrderModel Create(Orders order)
        {
            return new OrderModel
            {
                Id = order.Id,
                CustomerID = order.CustomerID,
                OrderDate = order.OrderDate,
                ShipAddress = order.ShipAddress,
                ShippedDate = order.ShippedDate,
                DeliveryMan = order.DeliveryMan,
                Status = order.Status,
                TotalPrice = order.TotalPrice
            };
        }

        public OrderDetailModel Create(OrderDetails orderDetail)
        {
            return new OrderDetailModel
            {
                OrderID = orderDetail.OrderID,
                ProductID = orderDetail.ProductID,
                Quantity = orderDetail.Quantity
            };
        }

        public CustomerModel Create(Customers customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                PhoneNumber = customer.PhoneNumber,
                Name = customer.Name,
                Email = customer.Email
            };
        }

        public CategoryModel Create(Categories category)
        {
            return new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public Products Parse(ProductModel model)
        {
            try
            {
                var product = new Products
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    PicturePath = model.PicturePath,
                    CategoryID = model.CategoryID,
                    Categories = _repo.GetCategory(model.CategoryID)
                };
                return product;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}