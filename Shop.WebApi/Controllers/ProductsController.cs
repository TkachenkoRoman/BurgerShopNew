using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.Data;
using Shop.Data.Models;
using Shop.WebApi.Models;

namespace Shop.WebApi.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController(IShopRepository repo) : base(repo) 
        {

        }

        public IEnumerable<ProductModel> Get()
        {
            //IShopRepository repository = new ShopRepository(new BurgerShopDBEntities());
            //return repository.GetAllProducts().ToList();
            IQueryable<Products> query = TheRepository.GetAllProducts();
            var results = query.ToList().Select(s => TheModelFactory.Create(s));
            return results;
        }

        public HttpResponseMessage GetProduct(int productID)
        {
            //IShopRepository repository = new ShopRepository(new BurgerShopDBEntities());
            //return repository.GetProduct(productID);
            try
            {
                var product = TheRepository.GetProduct(productID);
                if (product != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(product));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post([FromBody] ProductModel productModel)
        {
            try
            {
                var entity = TheModelFactory.Parse(productModel);
                if (entity == null) Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error in parsing product");

                if (TheRepository.Insert((Products)entity) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(entity));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cannot save into database");
                }

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
