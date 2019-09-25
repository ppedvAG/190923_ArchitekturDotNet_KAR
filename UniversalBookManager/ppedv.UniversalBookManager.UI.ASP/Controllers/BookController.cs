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
        // ToDo: Funktioniert das überhaupt mit XML ? -> Testen !!!!
        // Wenn nicht -> In den Commits die alte Version mit direktem UoW raussuchen
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
            return View(core.GetUnitOfWorkFor<Book>().BookRepository.GetByID(id));
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
                core.GetUnitOfWorkFor<Book>().BookRepository.Add(newBook);
                core.GetUnitOfWorkFor<Book>().Save();

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
            return View(core.GetUnitOfWorkFor<Book>().BookRepository.GetByID(id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book editedBook)
        {
            try
            {
                core.GetUnitOfWorkFor<Book>().BookRepository.Update(editedBook);
                core.GetUnitOfWorkFor<Book>().Save();

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
            return View(core.GetUnitOfWorkFor<Book>().BookRepository.GetByID(id));
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book deleteMe)
        {
            try
            {
                var loadedBook = core.GetUnitOfWorkFor<Book>().BookRepository.GetByID(id);
                core.GetUnitOfWorkFor<Book>().BookRepository.Delete(loadedBook);
                core.GetUnitOfWorkFor<Book>().Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
