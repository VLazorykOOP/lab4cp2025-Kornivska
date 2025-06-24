namespace BookStoreApp.Models
{
    public class Book
    {
        public int Id { get; set; }  // ключ у базі
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
