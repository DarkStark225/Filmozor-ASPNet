using Filmozor.DAL.EF;
using Filmozor.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Filmozor.DAL.Repositories
{
    public class FilmRep
    {
        public static ApplicationContext Database = new ApplicationContext();
        public static Film GetFilmFromDB(int id)
        {
            return Database.Films.Where(f => f.FilmID == id).FirstOrDefault();
        }
        public static IEnumerable<Film> GetFilmsFromDB()
        {
            IEnumerable<Film> films = Database.Films;
            return films;
        }

        public static void PasteFilm(Film film)
        {
            Film old_film = Database.Films.Where(f => f.FilmID == film.FilmID).FirstOrDefault();

            if (old_film != null)
            {
                Database.Entry<Film>(old_film).State = EntityState.Modified;
                Database.SaveChanges();
            }
            else
            {
                Database.Films.Add(film);
                Database.SaveChanges();
            }
        }

        public static void DeleteFilmFromDB(int id)
        {
            Film old_film = Database.Films.Where(f => f.FilmID == id).FirstOrDefault();

            if (old_film != null)
            {
                Database.Entry<Film>(old_film).State = EntityState.Deleted;
                Database.SaveChanges();
            }
        }
    }
}
