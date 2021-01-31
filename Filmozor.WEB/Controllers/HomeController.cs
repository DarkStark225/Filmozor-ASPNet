using System.Web.Mvc;
using Filmozor.BLL.Services;
using Filmozor.BLL.DTO;

namespace Filmozor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IndexType it = Pages.Index();
            ViewBag.Films = it.Films;
            ViewBag.Coming = it.Coming;
            ViewBag.Now = it.Now;
            ViewBag.News = it.News;
            return View();
        }

        public ActionResult Search(string searchstring)
        {
            ViewBag.str = searchstring;
            ViewBag.Films = Pages.Search(searchstring);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}