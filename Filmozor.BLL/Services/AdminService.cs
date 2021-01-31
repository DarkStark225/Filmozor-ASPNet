using Filmozor.BLL.DTO;
using Filmozor.DAL.Entities;
using Filmozor.DAL.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Filmozor.BLL.Services
{
    public class AdminService
    {
        public static int AddFilm(FilmDTO film)
        {
            Film newfilm = new Film
            {
                avatar = film.avatar,
                rusName = film.rusName,
                engName = film.engName,
                description = film.description,
                genre = film.genre,
                year = film.year,
                director = film.director,
                duration = film.duration,
                trailer = film.trailer,
                number_of_voices = film.number_of_voices,
                rating = film.rating,
                date_of_premier = film.date_of_premier,
                shots1 = film.shots1,
                shots2 = film.shots2,
                shots3 = film.shots3
            };
            return Admin.AddFilmInDB(newfilm);
        }

        public static void ChangeFilm(FilmDTO film)
        {
            Film newfilm = FilmRep.GetFilmFromDB(film.FilmID);
            newfilm.avatar = film.avatar;
            newfilm.rusName = film.rusName;
            newfilm.engName = film.engName;
            newfilm.description = film.description;
            newfilm.genre = film.genre;
            newfilm.year = film.year;
            newfilm.director = film.director;
            newfilm.duration = film.duration;
            newfilm.trailer = film.trailer;
            newfilm.number_of_voices = film.number_of_voices;
            newfilm.rating = film.rating;
            newfilm.date_of_premier = film.date_of_premier;
            newfilm.shots1 = film.shots1;
            newfilm.shots2 = film.shots2;
            newfilm.shots3 = film.shots3;
            FilmRep.PasteFilm(newfilm);
        }

        public static void ChangeNew(NewDTO _new)
        {
            New c_new = NewRep.GetNewFromDB(_new.NewID);
            c_new.avatar = _new.avatar;
            c_new.description = _new.description;
            c_new.date_of_publication = _new.date_of_publication;
            c_new.title = _new.title;
            NewRep.PasteNew(c_new);
        }

        public static void AddNew(NewDTO _new)
        {
            New new_new = new New
            {
                avatar = _new.avatar,
                date_of_publication = _new.date_of_publication,
                description = _new.description,
                title = _new.title
            };
            Admin.AddNewInDB(new_new);
        }

    }
}
