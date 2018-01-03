using FilmHaus.Models.View;
using FilmHaus.Services.ListFilms;
using FilmHaus.Services.Lists;
using FilmHaus.Services.ListShows;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Lists")]
    public class ListsController : Controller
    {
        private IListService ListService { get; }

        private IListFilmService ListFilmService { get; }

        private IListShowService ListShowService { get; }

        public ListsController(IListService listService, IListFilmService listFilmService, IListShowService listShowService)
        {
            ListService = listService;
            ListFilmService = listFilmService;
            ListShowService = listShowService;
        }

        // GET: Lists
        [Route("Index")]
        public ActionResult Index()
        {
            return View(ListService.GetAllSharedLists());
        }

        // GET: Lists/MyLists
        [Route("MyLists")]
        public ActionResult MyLists()
        {
            return View(ListService.GetAllListsByUserId(this.User.Identity.GetUserId()));
        }

        // GET: Lists/Details/5
        [Route("Details/{listId:guid}")]
        public ActionResult Details(Guid listId)
        {
            var result = ListService.GetListWithMediaByListId(listId);

            if (result != null)
                return View(result);

            return RedirectToAction("Index");
        }

        // POST: Films/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateListViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", "Library");

            try
            {
                ListService.CreateList(viewModel);
            }
            catch
            {
                throw;
            }

            return RedirectToAction("MyLists");
        }

        // GET: Lists/Edit/5
        [Route("Edit/{listId:guid}")]
        public ActionResult Edit(Guid listId)
        {
            var result = ListService.GetListByListId(listId);

            if (result != null && this.User.Identity.GetUserId() == result.Id)
                return View(new EditListViewModel(result));

            return RedirectToAction("Index");
        }

        // POST: Films/Edit/5 To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditListViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                ListService.UpdateListByListId(viewModel.ListId, viewModel);
            }
            catch
            {
                throw;
            }

            return RedirectToAction("Details", new { listId = viewModel.ListId });
        }

        // POST: Lists/AddFilmToList
        [HttpPost]
        [Route("AddFilmToList/{mediaId:guid}/{listId:guid}")]
        public ActionResult AddFilmToList(Guid mediaId, Guid listId)
        {
            if (ListFilmService.AddFilmToList(listId, mediaId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: List/RemoveFilmFromList
        [HttpPost]
        [Route("RemoveFilmFromList/{mediaId:guid}/{listId:guid}")]
        public ActionResult RemoveFilmFromList(Guid mediaId, Guid listId)
        {
            if (ListFilmService.ObsoleteFilmInList(listId, mediaId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: Lists/AddShowToList
        [HttpPost]
        [Route("AddShowToList/{mediaId:guid}/{listId:guid}")]
        public ActionResult AddShowToList(Guid mediaId, Guid listId)
        {
            if (ListShowService.AddShowToList(listId, mediaId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: List/RemoveShowFromList
        [HttpPost]
        [Route("RemoveShowFromList/{mediaId:guid}/{listId:guid}")]
        public ActionResult RemoveShowFromList(Guid mediaId, Guid listId)
        {
            if (ListShowService.ObsoleteShowInList(listId, mediaId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}