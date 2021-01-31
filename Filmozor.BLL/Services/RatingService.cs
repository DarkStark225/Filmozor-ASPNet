using Filmozor.BLL.DTO;
using Filmozor.DAL.Entities;
using Filmozor.DAL.Repositories;
using System;

namespace Filmozor.BLL.Services
{
    public class RatingService
    {
        public static void Rating(int rat,string id, int filmid)
        {
            Rating rating = new Rating
            {
                UserId = id,
                Value = rat,
                FilmId=filmid
            };
            
            RatingRep.RatingInDB(rating);

            int old_value = GetRating(id, filmid);

            if (old_value > 0)
            {
                Film film = FilmRep.GetFilmFromDB(filmid);
                double r =  (film.rating * film.number_of_voices - old_value + rat) / film.number_of_voices;
                film.rating = Math.Round(r,3);
                FilmRep.PasteFilm(film);  
            }
            else
            {
                Film film = FilmRep.GetFilmFromDB(filmid);
                film.number_of_voices++;
                double r = ((film.rating * film.number_of_voices + rating.Value) / film.number_of_voices);
                film.rating = Math.Round(r,3);
                FilmRep.PasteFilm(film);
            }
        }
        public static int GetRating(string id, int filmid)
        {
            Rating rating = new Rating
            {
                UserId = id,
                FilmId = filmid
            };
            return RatingRep.GetRatingFromDB(rating);
        }
    }
}
