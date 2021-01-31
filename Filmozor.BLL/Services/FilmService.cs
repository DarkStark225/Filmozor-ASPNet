using Filmozor.BLL.DTO;
using Filmozor.DAL.EF;
using Filmozor.DAL.Entities;
using Filmozor.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmozor.BLL.Services
{
    public class FilmService
    {
        public static FilmDTO GetFilm(int id)
        {
            Film bufffilm = FilmRep.GetFilmFromDB(id);
            if (bufffilm != null)
            {
                FilmDTO film = new FilmDTO
                {
                    FilmID = bufffilm.FilmID,
                    avatar = bufffilm.avatar,
                    date_of_premier = bufffilm.date_of_premier,
                    description = bufffilm.description,
                    director = bufffilm.director,
                    duration = bufffilm.duration,
                    engName = bufffilm.engName,
                    genre = bufffilm.genre,
                    number_of_voices = bufffilm.number_of_voices,
                    rating = bufffilm.rating,
                    rusName = bufffilm.rusName,
                    shots1 = bufffilm.shots1,
                    shots2 = bufffilm.shots2,
                    shots3 = bufffilm.shots3,
                    trailer = bufffilm.trailer,
                    year = bufffilm.year
                };
                return film;
            }
            return null;
        }

        public static List<FilmDTO> GetFilms()
        {
            IEnumerable<Film> bufffilm = FilmRep.GetFilmsFromDB();
            List<FilmDTO> films = new List<FilmDTO>();
            foreach (var film in bufffilm)
            {
                films.Add(Pages.FilmToFilmDTO(film));
            }
            return films;
        }

        public static void DeleteFilm(int id)
        {
            FilmRep.DeleteFilmFromDB(id);
        }
    }
}
