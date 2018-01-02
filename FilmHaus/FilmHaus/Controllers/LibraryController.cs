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

        // GET: Library
        [HttpGet]
        [Route("Index")]
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            return View(new UserLibraryViewModel
                (
                    films: UserFilmService.GetAllFilmsForUser(userId),
                    shows: UserShowService.GetAllShowsForUser(userId)
                ));
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
        [Route("AddFilmToLibrary/{mediaId:guid}")]
        public ActionResult AddFilmToLibrary(Guid mediaId)
        {
            if (UserFilmService.AddFilmToUserLibrary(mediaId, this.User.Identity.GetUserId()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: Library/RemoveFilmFromLibrary
        [HttpPost]
        [Route("RemoveFilmFromLibrary/{mediaId:guid}")]
        public ActionResult RemoveFilmFromLibrary(Guid mediaId)
        {
            if (UserFilmService.ObsoleteFilmInUserLibrary(mediaId, this.User.Identity.GetUserId()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: Library/AddShowToLibrary
        [HttpPost]
        [Route("AddShowToLibrary/{mediaId:guid}")]
        public ActionResult AddShowToLibrary(Guid mediaId)
        {
            if (UserShowService.AddShowToUserLibrary(mediaId, this.User.Identity.GetUserId()))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: Library/RemoveShowFromLibrary
        [HttpPost]
        [Route("RemoveShowFromLibrary/{mediaId:guid}")]
        public ActionResult RemoveShowFromLibrary(Guid mediaId)
        {
            if (UserShowService.ObsoleteShowInUserLibrary(mediaId, this.User.Identity.GetUserId()))
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