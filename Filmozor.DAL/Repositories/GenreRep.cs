using Filmozor.DAL.EF;
using Filmozor.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmozor.DAL.Repositories
{
    public class GenreRep
    {
        public static ApplicationContext Database = new ApplicationContext();
        public static List<string> GetGenres()
        {
            IEnumerable<Genre> genres = Database.Genres;
            genres = from genre in genres
                        orderby genre.genre ascending
                        select genre;

            List<string> sgenres = new List<string>();

            foreach (var genre in genres)
            {
                sgenres.Add(genre.genre);
            }
            return sgenres;
        }
    }
}
