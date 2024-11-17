using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;

namespace AuthorBookWebApi.Services
{
    public interface IAuthorDetailsService
    {
        public List<AuthorDetailsDTO> GetAll();
        public AuthorDetailsDTO Get(int id);
        public int Add(AuthorDetailsDTO authorDetailsDTO);
        public AuthorDetailsDTO Update(AuthorDetailsDTO authorDetailsDTO);
        public bool Delete(AuthorDetailsDTO authorDetailsDTO);
        public AuthorDetailsDTO GetByAuthorId(int id);
    }
}
