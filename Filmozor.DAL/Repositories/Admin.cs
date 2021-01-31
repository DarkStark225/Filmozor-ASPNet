using Filmozor.DAL.EF;
using Filmozor.DAL.Entities;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Filmozor.DAL.Repositories
{
    public class Admin
    {
        public static ApplicationContext Database = new ApplicationContext();
        public static int AddFilmInDB(Film item)
        {
            Film film = item;
            Database.Films.Add(film);
            Database.SaveChanges();
            IEnumerable<Film> films = Database.Films;
            foreach (var bfilm in films)
            {
                film = bfilm;
            }
            return film.FilmID; 
        }

        public static void AddNewInDB(New item)
        {
            New _new = item;
            Database.News.Add(_new);
            Database.SaveChanges();
        }
    }
}
