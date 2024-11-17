using System.ComponentModel.DataAnnotations.Schema;

namespace AuthorBookWebApi.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int AuthorId { get; set; }
    }
}
