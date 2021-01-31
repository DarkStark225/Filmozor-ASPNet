using Filmozor.BLL.DTO;
using Filmozor.BLL.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Filmozor.Controllers
{
    public class NoveltiesController : Controller
    {
        public ActionResult Novelties()
        {
            ViewBag.Films = Pages.NewFilms();
            return View();
        }
    }
}