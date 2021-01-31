using Filmozor.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Filmozor.Controllers
{
    public class MyPageController : Controller
    {
        // GET: MyPage
        public ActionResult MyPage()
        {
            if (User.IsInRole("admin")) return View();
            return RedirectToActionPermanent("Index","Home");
        }

        public ActionResult MyFilms()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Films = Pages.MyFilms(User.Identity.GetUserId());
                ViewBag.Ratings = Pages.MyRating(User.Identity.GetUserId());
                return View();
            }
            return RedirectToActionPermanent("Index", "Home");
        }
    }
}