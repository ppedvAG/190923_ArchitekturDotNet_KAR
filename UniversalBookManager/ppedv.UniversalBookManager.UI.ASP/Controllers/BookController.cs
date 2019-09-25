using ppedv.UniversalBookManager.Data.EF;
using ppedv.UniversalBookManager.Domain;
using ppedv.UniversalBookManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ppedv.UniversalBookManager.UI.ASP.Controllers
{
    public class BookController : Controller
    {
        // 1) Core
        public BookController()
        {
            core = new Core(new EFUnitOfWork());
        }
        private readonly Core core;

        // GET: Book
        public ActionResult Index()
        {
            return View(core.GetAllBooks());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View(core.UoW.BookRepository.GetByID(id));
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View(new Book { Author = "Max Mustermann", Title = "Work in Progress..." });
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book newBook)
        {
            try
            {
                core.UoW.BookRepository.Add(newBook);
                core.UoW.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View(core.UoW.BookRepository.GetByID(id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book editedBook)
        {
            try
            {
                core.UoW.BookRepository.Update(editedBook);
                core.UoW.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View(core.UoW.BookRepository.GetByID(id));
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book deleteMe)
        {
            try
            {
                var loadedBook = core.UoW.BookRepository.GetByID(id);
                core.UoW.BookRepository.Delete(loadedBook);
                core.UoW.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
