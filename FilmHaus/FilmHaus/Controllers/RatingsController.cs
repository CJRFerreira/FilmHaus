using FilmHaus.Models.View;
using FilmHaus.Services.UserFilmRatings;
using FilmHaus.Services.UserShowRatings;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
    [RoutePrefix("Ratings")]
    public class RatingsController : Controller
    {
        private IUserFilmRatingService UserFilmRatingService { get; }

        private IUserShowRatingService UserShowRatingService { get; }

        public RatingsController(IUserFilmRatingService userFilmRatingService, IUserShowRatingService userShowRatingService)
        {
            UserFilmRatingService = userFilmRatingService;
            UserShowRatingService = userShowRatingService;
        }

        [HttpPost]
        public ActionResult AddRatingToFilm(Guid MediaId, int Rating)
        {
            if (UserFilmRatingService.AddRatingToUserLibrary(User.Identity.GetUserId(), MediaId, Rating))
                return RedirectToAction("Details", "Films", new { mediaId = MediaId });

            return RedirectToAction("Films", "Library");
        }

        [HttpPost]
        public ActionResult ChangeRatingForFilm(Guid MediaId, int Rating)
        {
            if (UserFilmRatingService.ChangeRatingInUserLibrary(User.Identity.GetUserId(), MediaId, Rating))
                return RedirectToAction("Details", "Films", new { mediaId = MediaId });

            return RedirectToAction("Films", "Library");
        }

        [HttpPost]
        public ActionResult RemoveRatingFromFilm(Guid MediaId)
        {
            if (UserFilmRatingService.ObsoleteRatinginUserLibrary(User.Identity.GetUserId(), MediaId))
                return RedirectToAction("Details", "Films", new { mediaId = MediaId });

            return RedirectToAction("Films", "Library");
        }

        [HttpPost]
        public ActionResult AddRatingToShow(Guid MediaId, int Rating)
        {
            if (UserShowRatingService.AddRatingToUserLibrary(User.Identity.GetUserId(), MediaId, Rating))
                return RedirectToAction("Details", "Shows", new { mediaId = MediaId });

            return RedirectToAction("Shows", "Library");
        }

        [HttpPost]
        public ActionResult ChangeRatingForShow(Guid MediaId, int Rating)
        {
            if (UserShowRatingService.ChangeRatingInUserLibrary(User.Identity.GetUserId(), MediaId, Rating))
                return RedirectToAction("Details", "Shows", new { mediaId = MediaId });

            return RedirectToAction("Shows", "Library");
        }

        [HttpPost]
        public ActionResult RemoveRatingFromShow(Guid MediaId)
        {
            if (UserShowRatingService.ObsoleteRatinginUserLibrary(User.Identity.GetUserId(), MediaId))
                return RedirectToAction("Details", "Shows", new { mediaId = MediaId });

            return RedirectToAction("Shows", "Library");
        }
    }
}