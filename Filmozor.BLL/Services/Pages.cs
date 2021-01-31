using Filmozor.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using Filmozor.DAL.Repositories;
using Filmozor.BLL.DTO;
using System;

namespace Filmozor.BLL.Services
{
    public class Pages
    {
        public static IEnumerable<FilmDTO> Top100()
        {
            IEnumerable<Film> bufffilms = FilmRep.GetFilmsFromDB();
            bufffilms = from film in bufffilms
                        orderby film.rating descending
                        select film;

            List<FilmDTO> films = new List<FilmDTO>();

            foreach (var bufffilm in bufffilms)
            {
                films.Add(FilmToFilmDTO(bufffilm));
                if (films.Count == 100) break;
            } 
            return films;
        }

        public static List<FilmDTO> NewFilms()
        {
            IEnumerable<Film> bufffilms = FilmRep.GetFilmsFromDB();
            bufffilms = from film in bufffilms
                        orderby film.year descending
                        select film;

            List<FilmDTO> films = new List<FilmDTO>();
            int year = DateTime.Now.Year;
            int count = 0;
            foreach (var bufffilm in bufffilms)
            {
                if (count < 5)
                {
                    films.Add(FilmToFilmDTO(bufffilm));
                    count++;
                }
                if (count == 5 && int.Parse(bufffilm.year) == year - 1)
                {
                    count = 0;
                    year--;
                }
                if (films.Count == 40) break;
            }
            return films;
        }

        public static GenresType Genres()
        {
            Random rand = new Random();
            IEnumerable<Film> films = FilmRep.GetFilmsFromDB();
            List<string> genres = GenreRep.GetGenres();

            int[] counts = new int[genres.Count()];
            List<Film> selectedfilms = new List<Film>();
            List<Film> bufferfilms = new List<Film>();
            List<Film> minibufferfilms = new List<Film>();
            Film buff_film = new Film();

            for (int i = 0; i < genres.Count(); i++)
            {
                counts[i] = 0;
                bufferfilms.Clear();
                minibufferfilms.Clear();
                foreach (var film in films)
                {
                    if (film.genre.Contains(genres[i].ToLower())) bufferfilms.Add(film);
                }

                if (bufferfilms.Count - 1 >= 5)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        buff_film = bufferfilms[rand.Next(0, bufferfilms.Count - 1)];
                        if (!minibufferfilms.Contains(buff_film)) minibufferfilms.Add(buff_film);
                        else j--;
                    }
                    counts[i] = 5;
                    selectedfilms.AddRange(minibufferfilms);
                }
                else
                    foreach (var film in bufferfilms)
                    {
                        selectedfilms.Add(film);
                        counts[i]++;
                    }
            }

            List<FilmDTO> gfilms = new List<FilmDTO>();

            foreach (var bufffilm in selectedfilms)
            {
                gfilms.Add(FilmToFilmDTO(bufffilm));
            }

            GenresType gt = new GenresType();
            gt.Films = gfilms;
            gt.Counts = counts;
            gt.Genres = genres;
            return gt;
        }

        public static List<FilmDTO> Search(string searchstring)
        {
            IEnumerable<Film> films = FilmRep.GetFilmsFromDB();
            List<Film> buff_films = new List<Film>();
            foreach (var film in films)
            {
                if (film.rusName.ToLower().Contains(searchstring.ToLower()) || film.engName.ToLower().Contains(searchstring.ToLower()))
                {
                    buff_films.Add(film);
                }
            }
            List<FilmDTO> searchfilms = new List<FilmDTO>();
            foreach (var bufffilm in buff_films)
            {
                searchfilms.Add(FilmToFilmDTO(bufffilm));
            }
            return searchfilms;
        }

        public static IndexType Index()
        {
            Random rand = new Random();
            IEnumerable<Film> doublefilms = FilmRep.GetFilmsFromDB();
            IEnumerable<New> news = NewRep.GetNewsFromDB();

            news = from _new in news
                          orderby _new.date_of_publication descending
                          select _new;

            news = news.Take(10);

            IEnumerable<Film> films = new List<Film>();
            List<Film> buffercom = new List<Film>();
            List<Film> buffernow = new List<Film>();

            doublefilms = from film in doublefilms
                          orderby film.date_of_premier descending
                          select film;

            films = doublefilms.Take(10);
            
            foreach (var film in doublefilms)
            {
                if (film.date_of_premier >= DateTime.Now) buffercom.Add(film);
                else
                if (film.date_of_premier <= DateTime.Now && (DateTime.Now - film.date_of_premier).Days <= 14) buffernow.Add(film);
                else break;
            }

            List<FilmDTO> mainfilms = new List<FilmDTO>();

            foreach (var bufffilm in films)
            {
                mainfilms.Add(FilmToFilmDTO(bufffilm));
            }

            List<NewDTO> mainnews = new List<NewDTO>();
            foreach (var _new in news)
            {
                mainnews.Add(NewToNewDTO(_new));
            }

            IndexType it = new IndexType();
            it.Films = mainfilms;
            //it.Coming = FilmToFilmDTO(buffercom[rand.Next(0, buffercom.Count - 1)]);
            //it.Now = FilmToFilmDTO(buffernow[rand.Next(0, buffernow.Count - 1)]);
            it.News = mainnews;
            return it;
        }

        public static FilmDTO FilmToFilmDTO(Film bufffilm)
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

        public static NewDTO NewToNewDTO(New buff_new)
        {
            NewDTO _new = new NewDTO
            {
                NewID = buff_new.NewID,
                avatar = buff_new.avatar,
                date_of_publication = buff_new.date_of_publication,
                description = buff_new.description,
                title = buff_new.title
            };
            return _new;
        }

        public static List<FilmDTO> MyFilms(string id)
        {
            IEnumerable<Film> films = FilmRep.GetFilmsFromDB();
            List<FilmDTO> buff_films = new List<FilmDTO>();
            foreach (var film in films)
            {
                if (RatingService.GetRating(id, film.FilmID) > 0)
                {
                    buff_films.Add(FilmToFilmDTO(film));
                }
            }
            return buff_films;
        }
        public static List<int> MyRating(string id)
        {
            IEnumerable<Film> films = FilmRep.GetFilmsFromDB();
            List<int> rating = new List<int>();
            foreach (var film in films)
            {
                if (RatingService.GetRating(id, film.FilmID) > 0)
                {
                    rating.Add(RatingService.GetRating(id, film.FilmID));
                }
            }
            return rating;
        }
    }
}
