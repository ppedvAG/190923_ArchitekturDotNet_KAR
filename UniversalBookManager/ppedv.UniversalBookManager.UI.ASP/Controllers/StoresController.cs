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
    public class StoresController : ApiController
    {
        public StoresController()
        {
            this.core = new Core(new EFUnitOfWork());
        }
        private Core core;

        public IEnumerable<Store> GetAllStores()
        {
            var result = core.GetUnitOfWorkFor<Store>()
                              .StoreRepository.GetAll()
                              .Select(x => new Store
                              {
                                  ID = x.ID,
                                  Address = x.Address,
                                  Name = x.Name,
                                  Inventory = new HashSet<Inventory>(x.Inventory.Select(inv => new Inventory
                                  {
                                      ID = inv.ID,
                                      Amount = inv.Amount,
                                      Book = new Book
                                      {
                                          ID = inv.Book.ID,
                                          Author = inv.Book.Author,
                                          Pages = inv.Book.Pages,
                                          Price = inv.Book.Price,
                                          Title = inv.Book.Title,
                                      }
                                  }))
                              })
                              .ToArray();
            return result;
        }

        public IHttpActionResult GetStore(int id)
        {
            return Ok(core.GetUnitOfWorkFor<Store>().StoreRepository.GetByID(id));
        }

        [HttpGet]
        [Route("api/Sample/Custom")]
        public IHttpActionResult Custom()
        {
            return Ok(core.GetUnitOfWorkFor<Store>().StoreRepository.GetAll());
        }
    }
}
