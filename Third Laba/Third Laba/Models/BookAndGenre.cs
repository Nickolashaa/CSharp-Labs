namespace Third_Laba.Models
{
    public class BookAndGenre
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public Book? Book { get; set; }
        public int? GenreId { get; set; }
        public Genre? genre { get; set; }
    }
}
