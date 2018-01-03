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
        [Route("AddRatingToFilm/{mediaId:guid}/{rating:int}")]
        public ActionResult AddRatingToFilm(AddRatingViewModel rating)
        {
            if (UserFilmRatingService.AddRatingToUserLibrary(User.Identity.GetUserId(), rating.MediaId, rating.Rating))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("ChangeRatingForFilm/{mediaId:guid}/{rating:int}")]
        public ActionResult ChangeRatingForFilm(ChangeRatingViewModel rating)
        {
            if (UserFilmRatingService.ChangeRatingInUserLibrary(User.Identity.GetUserId(), rating.MediaId, rating.Rating))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("RemoveRatingFromFilm/{mediaId:guid}")]
        public ActionResult RemoveRatingFromFilm(Guid mediaId)
        {
            if (UserFilmRatingService.ObsoleteRatinginUserLibrary(User.Identity.GetUserId(), mediaId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("AddRatingToShow/{mediaId:guid}/{rating:int}")]
        public ActionResult AddRatingToShow(AddRatingViewModel rating)
        {
            if (UserShowRatingService.AddRatingToUserLibrary(User.Identity.GetUserId(), rating.MediaId, rating.Rating))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("ChangeRatingForShow/{mediaId:guid}/{rating:int}")]
        public ActionResult ChangeRatingForShow(ChangeRatingViewModel rating)
        {
            if (UserShowRatingService.ChangeRatingInUserLibrary(User.Identity.GetUserId(), rating.MediaId, rating.Rating))
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("RemoveRatingFromShow/{mediaId:guid}")]
        public ActionResult RemoveRatingFromShow(Guid mediaId)
        {
            if (UserShowRatingService.ObsoleteRatinginUserLibrary(User.Identity.GetUserId(), mediaId))
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