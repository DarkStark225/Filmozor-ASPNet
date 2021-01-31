using System;

namespace Filmozor.DAL.Entities
{
    public class New
    {
        public int NewID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string avatar { get; set; }
        public DateTime date_of_publication { get; set; }
    }
}
