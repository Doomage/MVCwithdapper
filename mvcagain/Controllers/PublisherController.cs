using mvcagain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace mvcagain.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        // GET: Publisher
        public ActionResult Index()
        {
            var db = new BookstoreDb();

            var publishers = db.GetPublishers();

            return View(publishers.ToList());
        }

        public ActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name")]Publisher publisher)
        {
            if (string.IsNullOrWhiteSpace(publisher.Name))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var db = new BookstoreDb();
            db.Create(publisher);
            
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var db = new BookstoreDb();
            var publisher = db.GetPublishers().Where(i => i.Id == id).FirstOrDefault();

            return View(publisher);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var db = new BookstoreDb();
            db.DeletePublisher(id);

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var db = new BookstoreDb();
            var publisher = db.GetPublishers().Where(i => i.Id == id).FirstOrDefault();

            return View(publisher);
        }

        [HttpPost]
        public ActionResult Edit(Publisher publisher)
        {
            var db = new BookstoreDb();
            db.Update(publisher);

            return RedirectToAction("Index");
        }



    }
}