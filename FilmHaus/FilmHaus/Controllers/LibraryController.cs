﻿using FilmHaus.Models.View;
using FilmHaus.Services.Films;
using FilmHaus.Services.Shows;
using FilmHaus.Services.UserFilms;
using FilmHaus.Services.UserShows;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FilmHaus.Controllers
{
    [Authorize]
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
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();

            return View(new UserLibraryViewModel
                (
                    films: UserFilmService.GetAllFilmsForUser(userId),
                    shows: UserShowService.GetAllShowsForUser(userId)
                ));
        }

        // GET: Library/MyFilms
        [HttpGet]
        public ActionResult MyFilms()
        {
            return View(UserFilmService.GetAllFilmsForUser(this.User.Identity.GetUserId()));
        }

        // GET: Library/MyShows
        [HttpGet]
        public ActionResult MyShows()
        {
            return View(UserShowService.GetAllShowsForUser(this.User.Identity.GetUserId()));
        }

        // POST: Library/AddFilmToLibrary
        [HttpPost]
        public ActionResult AddFilmToLibrary(Guid mediaId, string userId)
        {
            UserFilmService.AddFilmToUserLibrary(mediaId, userId);
            return View("MyFilms");
        }

        // POST: Library/RemoveFilmFromLibrary
        [HttpPost]
        public ActionResult RemoveFilmFromLibrary(Guid mediaId, string userId)
        {
            UserFilmService.ObsoleteFilmInUserLibrary(mediaId, userId);
            return View("MyFilms");
        }

        // POST: Library/AddShowToLibrary
        [HttpPost]
        public ActionResult AddShowToLibrary(Guid mediaId, string userId)
        {
            UserShowService.AddShowToUserLibrary(mediaId, userId);
            return View("MyShows");
        }

        // POST: Library/RemoveShowFromLibrary
        [HttpPost]
        public ActionResult RemoveShowFromLibrary(Guid mediaId, string userId)
        {
            UserShowService.ObsoleteShowInUserLibrary(mediaId, userId);
            return View("MyShows");
        }
    }
}