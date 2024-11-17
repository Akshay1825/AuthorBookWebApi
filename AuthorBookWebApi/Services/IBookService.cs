using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;

namespace AuthorBookWebApi.Services
{
    public interface IBookService
    {
        public List<BookDTO> GetAll();
        public BookDTO Get(int id);
        public int Add(BookDTO bookDTO);
        public BookDTO Update(BookDTO bookDTO);
        public bool Delete(BookDTO bookDTO);
        public BookDTO GetBookByAuthorID(int id);
    }
}
