using FilmHaus.Models.View;
using FilmHaus.Services.ListFilms;
using FilmHaus.Services.Lists;
using FilmHaus.Services.ListShows;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Reports")]
    [Route("Index")]
    public class ListController : Controller
    {
        private IListService ListService { get; }
        private IListFilmService ListFilmService { get; }
        private IListShowService ListShowService { get; }

        public ListController(IListService listService, IListFilmService listFilmService, IListShowService listShowService)
        {
            ListService = listService;
            ListFilmService = listFilmService;
            ListShowService = listShowService;
        }

        // GET: Lists
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            return View();
        }

        // GET: Lists/MyLists
        [HttpGet]
        [Route("MyLists")]
        public ActionResult MyLists()
        {
            return View();
        }

        // GET: Lists/Details/5
        [Route("Details/{listId:guid}")]
        public ActionResult Details(Guid listId)
        {
            var result = ListService.GetListByListId(listId);

            if (this.User.Identity.GetUserId() == result.UserId)
            {

            }
            if (result != null)
                return View(result);

            return RedirectToAction("Index");
        }

        // GET: Lists/Edit/5
        [Route("Edit/{listId:guid}")]
        public ActionResult Edit(Guid listId)
        {
            var result = ListService.GetListByListId(listId);

            if (result != null && this.User.Identity.GetUserId() == result.UserId)
                return View(new EditListViewModel(result));

            return RedirectToAction("Index");
        }

        // POST: Lists/AddFilmToList
        [HttpPost]
        public ActionResult AddFilmToList(Guid mediaId, Guid listId)
        {
            return View();
        }

        // POST: List/RemoveFilmFromList
        [HttpPost]
        public ActionResult RemoveFilmFromLibrary(Guid mediaId, Guid listId)
        {
            return View();
        }
    }
}