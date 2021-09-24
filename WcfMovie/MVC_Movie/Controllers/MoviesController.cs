using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Movie.Controllers
{
    public class MoviesController : Controller
    {
        public static ServiceReferenceMovie.Service1Client myService = new ServiceReferenceMovie.Service1Client();
        // GET: Movie
        public ActionResult Index()
        {
            return View(myService.GetAll().ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View(myService.GetById(id));
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(ServiceReferenceMovie.Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                myService.Add(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(ServiceReferenceMovie.Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                myService.Edit(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ServiceReferenceMovie.Movie movie)
        {
            try
            {
                // TODO: Add delete logic here
                myService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
