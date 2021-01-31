using System;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Filmozor.BLL.DTO;
using Filmozor.BLL.Services;

namespace Filmozor.Controllers
{
    public class AdminController : Controller
    {
        public RedirectToRouteResult AddFilm(HttpPostedFileBase ava, string rusName, string engName, string description, string genre, string year, string director, int duration, string trailer, int number_of_voices, string rating, DateTime date_of_premier, HttpPostedFileBase shots1, HttpPostedFileBase shots2, HttpPostedFileBase shots3)
        {
            if (User.IsInRole("admin"))
            {
                string fileName, sava = "", shot1 = "", shot2 = "", shot3 = "";
                Directory.CreateDirectory(@"C:\Users\Леонид\Desktop\Программирование\фильмозор\Filmozor\Filmozor.WEB\Images\Films\" + engName);
                if (ava != null)
                {
                    fileName = System.IO.Path.GetFileName(ava.FileName);
                    ava.SaveAs(Server.MapPath("/Images/Films/" + engName + "/" + fileName));
                    sava = "/Images/Films/" + engName + "/" + fileName;
                }
                if (shots1 != null)
                {
                    fileName = System.IO.Path.GetFileName(shots1.FileName);
                    shots1.SaveAs(Server.MapPath("/Images/Films/" + engName + "/" + fileName));
                    shot1 = "/Images/Films/" + engName + "/" + fileName;
                }
                if (shots2 != null)
                {
                    fileName = System.IO.Path.GetFileName(shots2.FileName);
                    shots2.SaveAs(Server.MapPath("/Images/Films/" + engName + "/" + fileName));
                    shot2 = "/Images/Films/" + engName + "/" + fileName;
                }
                if (shots3 != null)
                {
                    fileName = System.IO.Path.GetFileName(shots3.FileName);
                    shots3.SaveAs(Server.MapPath("/Images/Films/" + engName + "/" + fileName));
                    shot3 = "/Images/Films/" + engName + "/" + fileName;
                }

                FilmDTO film = new FilmDTO(sava, rusName, engName, description, genre, year, director, duration, trailer, number_of_voices, rating, date_of_premier, shot1, shot2, shot3);

                return RedirectToActionPermanent("Film", "Film", new { id = AdminService.AddFilm(film) });
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public RedirectToRouteResult AddNew(string title, string description, HttpPostedFileBase avatar)
        {
            if (User.IsInRole("admin"))
            {
                string fileName, ava = "";
                if (avatar != null)
                {
                    fileName = System.IO.Path.GetFileName(avatar.FileName);
                    avatar.SaveAs(Server.MapPath("/Images/News/" + fileName));
                    ava = "/Images/News/" + fileName;
                }

                NewDTO _new = new NewDTO(title, description, ava);
                AdminService.AddNew(_new);

                return RedirectToActionPermanent("Index", "Home");
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public ActionResult FilmForm()
        {
            if (User.IsInRole("admin"))
            {
                return View();
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public ActionResult ChangeFilm(int id)
        {
            if (User.IsInRole("admin"))
            {
                ViewBag.Film = FilmService.GetFilm(id);
                ViewBag.id = id;
                return View();
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public RedirectToRouteResult DeleteFilm(int id)
        {
            if (User.IsInRole("admin"))
            {
                Directory.Delete(@"C:\Users\Леонид\Desktop\Программирование\фильмозор\Filmozor\Filmozor.WEB\Images\Films\"+FilmService.GetFilm(id).engName, true);
                FilmService.DeleteFilm(id);
                return RedirectToActionPermanent("FilmTable");
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public RedirectToRouteResult ChangeFilmL(int id, HttpPostedFileBase ava, string rusName, string engName, string description, string genre, string year, string director, int duration, string trailer, DateTime date_of_premier, HttpPostedFileBase shots1, HttpPostedFileBase shots2, HttpPostedFileBase shots3)
        {
            if (User.IsInRole("admin"))
            {
                FilmDTO film = FilmService.GetFilm(id);
                film.date_of_premier = date_of_premier;
                film.description = description;
                film.director = director;
                film.duration = duration;
                film.engName = engName;
                film.genre = genre;
                film.rusName = rusName;
                film.trailer = trailer;
                film.year = year;
                string fileName;
                if (ava != null)
                {
                    fileName = System.IO.Path.GetFileName(ava.FileName);
                    ava.SaveAs(Server.MapPath("/Images/Films/" + engName + "/" + fileName));
                    film.avatar = "/Images/Films/" + engName + "/" + fileName;
                }
                if (shots1 != null)
                {
                    fileName = System.IO.Path.GetFileName(shots1.FileName);
                    shots1.SaveAs(Server.MapPath("/Images/Films/" + engName + "/" + fileName));
                    film.shots1 = "/Images/Films/" + engName + "/" + fileName;
                }
                if (shots2 != null)
                {
                    fileName = System.IO.Path.GetFileName(shots2.FileName);
                    shots2.SaveAs(Server.MapPath("/Images/Films/" + engName + "/" + fileName));
                    film.shots2 = "/Images/Films/" + engName + "/" + fileName;
                }
                if (shots3 != null)
                {
                    fileName = System.IO.Path.GetFileName(shots3.FileName);
                    shots3.SaveAs(Server.MapPath("/Images/Films/" + engName + "/" + fileName));
                    film.shots3 = "/Images/Films/" + engName + "/" + fileName;
                }

                AdminService.ChangeFilm(film);

                return RedirectToActionPermanent("FilmTable");
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public ActionResult FilmTable()
        {
            if (User.IsInRole("admin"))
            {
                ViewBag.Films = FilmService.GetFilms();
                return View();
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public ActionResult NewsTable()
        {
            if (User.IsInRole("admin"))
            {
                ViewBag.News = NewService.GetNews();
                return View();
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public ActionResult ChangeNew(int id)
        {
            if (User.IsInRole("admin"))
            {
                ViewBag.New = NewService.GetNew(id);
                ViewBag.id = id;
                return View();
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public RedirectToRouteResult DeleteNew(int id)
        {
            if (User.IsInRole("admin"))
            {
                string s = NewService.GetNew(id).avatar;
                s = s.Remove(0, s.LastIndexOf('/'));
                System.IO.File.Delete(@"C:\Users\Леонид\Desktop\Программирование\фильмозор\Filmozor\Filmozor.WEB\Images\News\" + s);

                NewService.DeleteNew(id);
                return RedirectToActionPermanent("NewsTable");
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public RedirectToRouteResult ChangeNewL(int id,string title, string description, HttpPostedFileBase avatar, DateTime date_of_publication)
        {
            if (User.IsInRole("admin"))
            {
                NewDTO _new = NewService.GetNew(id);
                _new.date_of_publication = date_of_publication;
                _new.description = description;
                _new.title = title;
  
                if (avatar != null)
                {
                    string fileName = System.IO.Path.GetFileName(avatar.FileName);
                    avatar.SaveAs(Server.MapPath("/Images/News/" + fileName));
                    _new.avatar = "/Images/News/" + fileName;
                }

                AdminService.ChangeNew(_new);

                return RedirectToActionPermanent("Index", "Home");
            }
            return RedirectToActionPermanent("Index", "Home");
        }

        public ActionResult NewForm()
        {
            if (User.IsInRole("admin"))
            {
                return View();
            }
            return RedirectToActionPermanent("Index", "Home");
        }

    }
}