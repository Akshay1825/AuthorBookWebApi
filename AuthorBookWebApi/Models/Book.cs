using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorBookWebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime DateOfRelease { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
