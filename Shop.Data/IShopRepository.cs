using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data.Models;

namespace Shop.Data
{
    public interface IShopRepository
    {
        IQueryable<Products> GetAllProducts();
        Products GetProduct(int productID);
        bool Insert(Products product);
        bool Update(Products originalProduct, Products updatedProduct);
        bool DeleteProduct(int productID);

        int Insert(Orders order); // returnes id
        IQueryable<Orders> GetAllOrders();
        Orders GetOrder(int orderID);
        bool Update(Orders originalOrder, Orders updatedOrder);
        bool DeleteOrder(int orderID);

        bool Insert(OrderDetails orderDetails);
        IQueryable<OrderDetails> GetOrderDetailsByOrderID(int orderID);

        int Insert(Customers customer); // returnes id
        IQueryable<Customers> GetAllCustomers();
        Customers GetCustomer(int customerID);
        bool Update(Customers originalCustomer, Customers updatedCustomer);
        bool DeleteCustomer(int customerID);

        bool Insert(Categories category);
        IQueryable<Categories> GetAllCategories();
        Categories GetCategory(int categoryID);
        bool Update(Categories originalCategory, Categories updatedCategory);
        bool DeleteCategory(int categoryID);

        bool SaveAll();
    }
}
