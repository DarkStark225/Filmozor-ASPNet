using System;

namespace Filmozor.DAL.Entities
{
    public class Film
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
    }
}
