using System.Web.Mvc;

using Filmozor.BLL.Services;
using Microsoft.AspNet.Identity;

namespace Filmozor.Controllers
{
    public class FilmController : Controller
    {
        public ActionResult Film(int id)
        {
            if (FilmService.GetFilm(id) != null)
            {
                ViewBag.film = FilmService.GetFilm(id);
                if (User.Identity.IsAuthenticated) ViewBag.myrating = RatingService.GetRating(User.Identity.GetUserId(), id);
                else ViewBag.myrating = 0;
                return View();
            }
            return RedirectToActionPermanent("Index","Home");
        }
        public RedirectToRouteResult Rating(int rat, int filmid)
        {
            RatingService.Rating(rat, User.Identity.GetUserId(), filmid);
            return RedirectToActionPermanent("Film", "Film", new { id = filmid });
        }
    }
}