using ppedv.UniversalBookManager.Data.EF;
using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ppedv.UniversalBookManager.UI.ASP.Controllers
{
    public class WebAPIController : ApiController
    {
        public WebAPIController()
        {
            core = new Core(new EFUnitOfWork());
        }
        private Core core;

        public IEnumerable<Store> GetAllStores()
        {
            return core.GetUnitOfWorkFor<Store>().StoreRepository.GetAll();
        }
    }
}
