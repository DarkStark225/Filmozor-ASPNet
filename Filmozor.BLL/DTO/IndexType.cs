using System.Collections.Generic;
namespace Filmozor.BLL.DTO
{
    public class IndexType
    {
        public List<FilmDTO> Films { get; set; }
        public List<NewDTO> News { get; set; }
        public FilmDTO Coming { get; set; }
        public FilmDTO Now { get; set; }
    }
}
