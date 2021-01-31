using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmozor.BLL.DTO
{
    public class FilmDTO
    {
        public int FilmID { get; set; }
        public string avatar { get; set; }
        public string rusName { get; set; }
        public string engName { get; set; }
        public string description { get; set; }
        public string genre { get; set; }
        public string year { get; set; }
        public string director { get; set; }
        public int duration { get; set; }
        public string trailer { get; set; }
        public int number_of_voices { get; set; }
        public DateTime date_of_premier { get; set; }
        public double rating { get; set; }
        public string shots1 { get; set; }
        public string shots2 { get; set; }
        public string shots3 { get; set; }

        public FilmDTO() { }
        public FilmDTO(string ava, string rusName, string engName, string description, string genre, string year, string director, int duration, string trailer, int number_of_voices, string rating, DateTime date_of_premier, string shot1, string shot2, string shot3)
        {
            this.avatar = ava;
            this.rusName = rusName;
            this.engName = engName;
            this.description = description;
            this.genre = genre;
            this.year = year;
            this.director = director;
            this.duration = duration;
            this.trailer = trailer;
            this.number_of_voices = number_of_voices;
            this.rating = double.Parse(rating);
            this.date_of_premier = date_of_premier;
            this.shots1 = shot1;
            this.shots2 = shot2;
            this.shots3 = shot3;
        }
        public FilmDTO(int id, string ava, string rusName, string engName, string description, string genre, string year, string director, int duration, string trailer, int number_of_voices, string rating, DateTime date_of_premier, string shot1, string shot2, string shot3)
        {
            this.FilmID = id;
            this.avatar = ava;
            this.rusName = rusName;
            this.engName = engName;
            this.description = description;
            this.genre = genre;
            this.year = year;
            this.director = director;
            this.duration = duration;
            this.trailer = trailer;
            this.number_of_voices = number_of_voices;
            this.rating = double.Parse(rating);
            this.date_of_premier = date_of_premier;
            this.shots1 = shot1;
            this.shots2 = shot2;
            this.shots3 = shot3;
        }
    }
}
