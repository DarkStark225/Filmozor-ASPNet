using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmozor.BLL.DTO
{
    public class NewDTO
    {
        public int NewID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string avatar { get; set; }
        public DateTime date_of_publication { get; set; }

        public NewDTO() { }
        public NewDTO(string title, string description, string avatar)
        {
            this.title = title;
            this.description = description;
            this.avatar = avatar;
            this.date_of_publication = DateTime.Now;
        }
    }
}
