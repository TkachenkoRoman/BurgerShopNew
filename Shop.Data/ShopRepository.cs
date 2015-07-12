using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data.Models;

namespace Shop.Data
{
    public class ShopRepository : IShopRepository
    {

        private BurgerShopDBEntities _ctx;
        public ShopRepository(BurgerShopDBEntities ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Products> GetAllProducts()
        {
            return _ctx.Products.AsQueryable();
        }

        public Products GetProduct(int productID)
        {
            return _ctx.Products.Find(productID);
        }

        public bool Insert(Products product)
        {
            try
            {
                _ctx.Products.Add(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Products originalProduct, Products updatedProduct)
        {
            try
            {
                _ctx.Entry(originalProduct).CurrentValues.SetValues(updatedProduct);
                return true;
            }
            catch
            {
                return false;
            }  
        }

        public bool DeleteProduct(int productID)
        {
            try
            {
                var entity = _ctx.Products.Find(productID);
                if (entity != null)
                {
                    _ctx.Products.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // logging
            }
            return false;
        }

        public bool Insert(Orders order)
        {
            try
            {
                _ctx.Orders.Add(order);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Orders> GetAllOrders()
        {
            return _ctx.Orders.AsQueryable();
        }

        public Orders GetOrder(int orderID)
        {
            return _ctx.Orders.Find(orderID);
        }

        public bool Update(Orders originalOrder, Orders updatedOrder)
        {
            _ctx.Entry(originalOrder).CurrentValues.SetValues(updatedOrder);
            originalOrder.Customers = updatedOrder.Customers;
            return true;
        }

        public bool DeleteOrder(int orderID)
        {
            try
            {
                var entity = _ctx.Orders.Find(orderID);
                if (entity != null)
                {
                    _ctx.Orders.Remove(entity);
                    return true;
                }
            }
            catch
            {
                // logging
            }
            return false;
        }

        public bool Insert(OrderDetails orderDetails)
        {
            try
            {
                _ctx.OrderDetails.Add(orderDetails);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<OrderDetails> GetOrderDetailsByOrderID(int orderID)
        {
            return _ctx.OrderDetails.Where(x => x.OrderID == orderID).AsQueryable();
        }

        public bool Insert(Customers customer)
        {
            try
            {
                _ctx.Customers.Add(customer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Customers> GetAllCustomers()
        {
            return _ctx.Customers.AsQueryable();
        }

        public Customers GetCustomer(int customerID)
        {
            return _ctx.Customers.Find(customerID);
        }

        public bool Update(Customers originalCustomer, Customers updatedCustomer)
        {
            _ctx.Entry(originalCustomer).CurrentValues.SetValues(updatedCustomer);
            return true;
        }

        public bool DeleteCustomer(int customerID)
        {
            try
            {
                var entity = _ctx.Customers.Find(customerID);
                if (entity != null)
                {
                    _ctx.Customers.Remove(entity);
                    return true;
                }
            }
            catch 
            {
                // logging
            }
            return false;
        }

        public bool Insert(Categories category)
        {
            try
            {
                _ctx.Categories.Add(category);
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public IQueryable<Categories> GetAllCategories()
        {
            return _ctx.Categories.AsQueryable();
        }

        public Categories GetCategory(int categoryID)
        {
            return _ctx.Categories.Find(categoryID);
        }

        public bool Update(Categories originalCategory, Categories updatedCategory)
        {
            try
            {
                _ctx.Entry(originalCategory).CurrentValues.SetValues(updatedCategory);
                return true;
            }
            catch 
            {
                return false;
            }      
        }

        public bool DeleteCategory(int categoryID)
        {
            try
            {
                var entity = _ctx.Categories.Find(categoryID);
                if (entity != null)
                {
                    _ctx.Categories.Remove(entity);
                }
            }
            catch 
            {
                //logging
            }
            return false;
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
