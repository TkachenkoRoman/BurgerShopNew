using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
                CategoryID = product.CategoryID,
                PictureDetailPath = product.PictureDetailPath
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
                    PictureDetailPath = model.PictureDetailPath,
                    Categories = _repo.GetCategory(model.CategoryID)
                };
                return product;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<object> Parse(OrderFormModel model)
        {
            try
            {
                List<object> result = new List<object>();
                List<OrderDetails> detailsList = new List<OrderDetails>();
                List<Customers> allCustomers = (List<Customers>)_repo.GetAllCustomers().ToList();

                var customer = new Customers
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

                Customers existingCustomer = allCustomers.FirstOrDefault(c => c.PhoneNumber == model.PhoneNumber);

                int customerId = -1;
                if (existingCustomer != null)
                {
                    _repo.Update(existingCustomer, customer);
                    customerId = existingCustomer.Id;
                }
                else
                    customerId = _repo.Insert(customer);
                if (customerId < 0)
                    return null;
                result.Add(customer);

                var order = new Orders
                {
                    CustomerID = customerId,
                    Status = "new",
                    ShipAddress = String.Join(" ", new string[] {model.Street, model.Flat, model.House})
                };

                int orderId = _repo.Insert(order);
                if (orderId < 0)
                    return null;
                result.Add(order);

                foreach (cartItem item in model.Items)
                {
                    var details = new OrderDetails
                    {
                        OrderID = orderId,
                        ProductID = item.id,
                        Quantity = item.quantity
                    };
                    if (!_repo.Insert(details))
                        return null;
                    detailsList.Add(details);
                }
                result.Add(detailsList);

                return result;
            }
            catch (Exception ex)
            {
                Debug.Print("****************" + ex);
                return null;
            }
        }
    }
}