using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shop.Data;
using Shop.WebApi.Models;

namespace Shop.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        private IShopRepository _repo;
        private ModelFactory _modelFactory;

        public BaseApiController(IShopRepository repo)
        {
            _repo = repo;
        }

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(_repo);
                }
                return _modelFactory;
            }
        }

        protected IShopRepository TheRepository
        {
            get { return _repo; }
        }    
    }
}
