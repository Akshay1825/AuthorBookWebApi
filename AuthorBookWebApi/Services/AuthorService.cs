using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Exceptions;
using AuthorBookWebApi.Models;
using AuthorBookWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookWebApi.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IRepository<Author> _repository;
        private readonly IRepository<Book> _repository1;
        private readonly IMapper _mapper;

        public AuthorService(IRepository<Author> repository,IMapper mapper, IRepository<Book> repository1)
        {
            _repository = repository;
            _mapper = mapper;
            _repository1 = repository1;
        }
        public List<AuthorDTO> GetAll()
        {
            var authors = _repository.GetAll().Include(x => x.Books).Include(y => y.AuthorDetails).ToList();
            List<AuthorDTO> result = _mapper.Map<List<AuthorDTO>>(authors);
            return result;
        }
        public AuthorDTO Get(int id)
        {
            var author = _repository.Get(id);
            if (author == null)
            {
                throw new AuthorNotFoundException("Author Not Found");
            }
            var authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }

        public int Add(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            _repository.Add(author);
            return author.Id;
        }

        public AuthorDTO Update(AuthorDTO authorDTO)
        {
            var existingAuthor = _mapper.Map<Author>(authorDTO);
            var updatedAuthor = _repository.GetAll().AsNoTracking().FirstOrDefault(x=>x.Id == existingAuthor.Id);
            if (updatedAuthor != null)
            {
                _repository.Update(updatedAuthor);
            }
            var updatedAuthorDTO = _mapper.Map<AuthorDTO>(updatedAuthor);
            return updatedAuthorDTO;
        }

        public bool Delete(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            var existingAuthor = _repository.Get(author.Id);
            if (existingAuthor != null)
            {
                _repository.Delete(author);
                return true;
            }
            return false;
        }

        public AuthorDTO GetByName(string name)
        {
            var author = _repository.GetAll().Include(x => x.Books).AsNoTracking().Where(a => a.Name == name).FirstOrDefault();
            var authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }
        public AuthorDTO GetAuthorByBookID(int id)
        {
            var authorId = _repository1.Get(id).AuthorId;
            var author = _repository.GetAll().Include(x => x.Books).AsNoTracking().FirstOrDefault(x=> x.Id == authorId);
            var authorDTO = _mapper.Map<AuthorDTO>(author);
            return authorDTO;
        }
    }
}
