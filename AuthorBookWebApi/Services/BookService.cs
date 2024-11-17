using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;
using AuthorBookWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookWebApi.Services
{
    public class BookService:IBookService
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<BookDTO> GetAll()
        {
            var books = _repository.GetAll().ToList();
            List<BookDTO> result = _mapper.Map<List<BookDTO>>(books);
            return result;
        }
        public BookDTO Get(int id)
        {
            var book = _repository.Get(id);
            var bookDTO = _mapper.Map<BookDTO>(book);
            return bookDTO;
        }

        public int Add(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _repository.Add(book);
            return book.Id;
        }

        public BookDTO Update(BookDTO bookDTO)
        {
            var existingBook = _mapper.Map<Book>(bookDTO);
            var updatedBook = _repository.GetAll().AsNoTracking().FirstOrDefault(x=>x.Id == existingBook.Id);
            if (updatedBook != null)
            {
                _repository.Update(updatedBook);
            }
            var updatedBookDTO = _mapper.Map<BookDTO>(updatedBook);
            return updatedBookDTO;
        }

        public bool Delete(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            var existingBook = _repository.Get(book.Id);
            if (existingBook != null)
            {
                _repository.Delete(existingBook);
                return true;
            }
            return false;
        }

        public BookDTO GetBookByAuthorID(int id)
        {
            var books = _repository.GetAll().Include(b => b.Author).ToList();
            var book = books.FirstOrDefault(b => b.AuthorId == id);
            var bookDTO = _mapper.Map<BookDTO>(book);

            return bookDTO;
        }
    }
}
