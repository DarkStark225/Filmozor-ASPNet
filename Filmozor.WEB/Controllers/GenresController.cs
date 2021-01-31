using Filmozor.BLL.DTO;
using Filmozor.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Filmozor.Controllers
{
    public class GenresController : Controller
    {
        public ActionResult Genres()
        {
            GenresType gt = Pages.Genres();
            ViewBag.Films = gt.Films;
            ViewBag.Counts = gt.Counts;
            ViewBag.Genres = gt.Genres;
            ViewBag.Count = gt.Genres.Count;
            return View();
        }
    }
}