using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        // GET: Search/Films
        public ActionResult Films(string searchTerm)
        {
            return View();
        }

        // GET: Search/Shows
        public ActionResult Shows(string searchTerm)
        {
            return View();
        }
    }
}