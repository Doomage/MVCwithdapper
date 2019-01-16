using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcagain.Models;

namespace mvcagain.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var db = new BookstoreDb();
            ViewBag.Name = db.GetPublishers().ToList();
            return View(db.GetBooks().ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }
       
        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            var db = new BookstoreDb();
            db.Create(book);            
                   
            return RedirectToAction("Index");
            
        }

        public ActionResult Create()
        {
            var db = new BookstoreDb();
            var publishers = db.GetPublishers().ToList();
            
            return View(publishers);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new BookstoreDb();
            var book = db.GetBooks().Where(i => i.Id == id).FirstOrDefault();           
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            var db = new BookstoreDb();
            db.Update(book);

            return RedirectToAction("Index");
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new BookstoreDb();
            var book = db.GetBooks().Where(i => i.Id == id).FirstOrDefault();
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Book book)
        {
            
                var db = new BookstoreDb();
                db.DeleteBook(id);                
                
                return RedirectToAction("Index");
            
        }
    }
}
