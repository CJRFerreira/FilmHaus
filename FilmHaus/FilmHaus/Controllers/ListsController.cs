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
            return View(ListService.GetAllSharedLists());
        }

        // GET: Lists/MyLists
        [HttpGet]
        [Route("MyLists")]
        public ActionResult MyLists()
        {
            return View(ListService.GetAllListsByUserId(this.User.Identity.GetUserId()));
        }

        // GET: Lists/Details/5
        [Route("Details/{listId:guid}")]
        public ActionResult Details(Guid listId)
        {
            var result = ListService.GetListByListId(listId);

            if (result != null)
                return View(result);

            return RedirectToAction("Index");
        }

        // GET: Films/Create
        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View(new CreateListViewModel());
        }

        // POST: Films/Create To protect from overposting attacks, please enable the specific
        // properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateListViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                ListService.CreateList(viewModel, this.User.Identity.GetUserId());
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

            if (result != null && this.User.Identity.GetUserId() == result.UserId)
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
        public ActionResult AddFilmToList(Guid mediaId, Guid listId)
        {
            ListFilmService.AddFilmToList(listId, mediaId);
            return RedirectToAction("Details", new { listId });
        }

        // POST: List/RemoveFilmFromList
        [HttpPost]
        public ActionResult RemoveFilmFromList(Guid mediaId, Guid listId)
        {
            ListFilmService.ObsoleteFilmInList(listId, mediaId);
            return RedirectToAction("Details", new { listId });
        }

        // POST: Lists/AddShowToList
        [HttpPost]
        public ActionResult AddShowToList(Guid mediaId, Guid listId)
        {
            ListShowService.AddShowToList(listId, mediaId);
            return RedirectToAction("Details", new { listId });
        }

        // POST: List/RemoveShowFromList
        [HttpPost]
        public ActionResult RemoveShowFromList(Guid mediaId, Guid listId)
        {
            ListShowService.ObsoleteShowInList(listId, mediaId);
            return RedirectToAction("Details", new { listId });
        }
    }
}