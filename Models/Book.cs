using System.ComponentModel.DataAnnotations;

namespace BookApi.Models
{
    public class Book
    {
        [Key]
        public string ISBN_10 { get; set; }
        public string Title { get; set; }
        public string SmallThumbnail { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }      
    }
}
