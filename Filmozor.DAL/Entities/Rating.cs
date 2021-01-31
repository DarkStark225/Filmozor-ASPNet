namespace Filmozor.DAL.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int FilmId { get; set; }
        public int Value { get; set; }
    }
}
