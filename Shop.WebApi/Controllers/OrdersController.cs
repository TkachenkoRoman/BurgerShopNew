using Shop.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.Data.Models;
using Shop.WebApi.Models;

namespace Shop.WebApi.Controllers
{
    public class OrdersController : BaseApiController
    {
        public OrdersController(IShopRepository repo) : base(repo)
        {

        }

        public IEnumerable<OrderModel> Get()
        {
            IQueryable<Orders> query = TheRepository.GetAllOrders();
            var results = query.ToList().Select(s => TheModelFactory.Create(s));
            return results;
        }

        public HttpResponseMessage GetOrder(int orderID)
        {
            try
            {
                var order = TheRepository.GetOrder(orderID);
                if (order != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(order));
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

        public HttpResponseMessage Post([FromBody] OrderFormModel orderFormModel)
        {
            try
            {
                var res = TheModelFactory.Parse(orderFormModel);
                if (res != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
