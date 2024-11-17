using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;

namespace AuthorBookWebApi.Services
{
    public interface IAuthorService
    {
        public List<AuthorDTO> GetAll();
        public AuthorDTO Get(int id);
        public int Add(AuthorDTO authorDTO);
        public AuthorDTO Update(AuthorDTO authorDTO);
        public bool Delete(AuthorDTO authorDTO);
        public AuthorDTO GetByName(string name);

        public AuthorDTO GetAuthorByBookID(int id);
    }
}
