using Filmozor.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filmozor.Controllers
{
    public class Top100Controller : Controller
    {
        public ActionResult Top100()
        {
            ViewBag.Films = Pages.Top100(); 
            ViewBag.Count = Pages.Top100().Count();
            return View();
        }
    }
}