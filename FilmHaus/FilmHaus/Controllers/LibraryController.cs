using FilmHaus.Models.View;
using FilmHaus.Services.UserFilms;
using FilmHaus.Services.UserShows;
using Microsoft.AspNet.Identity;
using System;
using System.Net;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Library")]
    public class LibraryController : Controller
    {
        private IUserFilmService UserFilmService { get; }

        private IUserShowService UserShowService { get; }

        public LibraryController(IUserFilmService userFilmService, IUserShowService userShowService)
        {
            UserFilmService = userFilmService;
            UserShowService = userShowService;
        }

        // GET: Library/Films
        [HttpGet]
        [Route("Films")]
        public ActionResult Films()
        {
            return View(UserFilmService.GetAllFilmsForUser(this.User.Identity.GetUserId()));
        }

        // GET: Library/Shows
        [HttpGet]
        [Route("Shows")]
        public ActionResult Shows()
        {
            return View(UserShowService.GetAllShowsForUser(this.User.Identity.GetUserId()));
        }

        // POST: Library/AddFilmToLibrary
        [HttpPost]
        public ActionResult AddFilmToLibrary(Guid mediaId)
        {
            if (UserFilmService.AddFilmToUserLibrary(mediaId, this.User.Identity.GetUserId()))
                return RedirectToAction("Details", "Films", new { mediaId });

            return RedirectToAction("Films", "Library");
        }

        // POST: Library/RemoveFilmFromLibrary
        [HttpPost]
        public ActionResult RemoveFilmFromLibrary(Guid mediaId)
        {
            if (UserFilmService.ObsoleteFilmInUserLibrary(mediaId, this.User.Identity.GetUserId()))
                return RedirectToAction("Details", "Films", new { mediaId });

            return RedirectToAction("Films", "Library");
        }

        // POST: Library/AddShowToLibrary
        [HttpPost]
        public ActionResult AddShowToLibrary(Guid mediaId)
        {
            if (UserShowService.AddShowToUserLibrary(mediaId, this.User.Identity.GetUserId()))
                return RedirectToAction("Details", "Shows", new { mediaId });

            return RedirectToAction("Shows", "Library");
        }

        // POST: Library/RemoveShowFromLibrary
        [HttpPost]
        public ActionResult RemoveShowFromLibrary(Guid mediaId)
        {
            if (UserShowService.ObsoleteShowInUserLibrary(mediaId, this.User.Identity.GetUserId()))
                return RedirectToAction("Details", "Shows", new { mediaId });

            return RedirectToAction("Shows", "Library");
        }
    }
}