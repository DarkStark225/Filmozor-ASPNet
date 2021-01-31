using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmozor.BLL.DTO
{
    public class GenresType
    {
        public List<FilmDTO> Films { get; set; }
        public int[] Counts { get; set; }
        public List<string> Genres { get; set; }
    }
}
