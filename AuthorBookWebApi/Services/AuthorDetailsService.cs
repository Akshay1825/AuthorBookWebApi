using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;
using AuthorBookWebApi.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookWebApi.Services
{
    public class AuthorDetailsService:IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetails> _repository;
        private readonly IMapper _mapper;

        public AuthorDetailsService(IRepository<AuthorDetails> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<AuthorDetailsDTO> GetAll()
        {
            var authorDetails = _repository.GetAll().ToList();
            List<AuthorDetailsDTO> result = _mapper.Map<List<AuthorDetailsDTO>>(authorDetails);
            return result;
        }
        public AuthorDetailsDTO Get(int id)
        {
            var authorDetails = _repository.Get(id);
            var authorDetailsDTO = _mapper.Map<AuthorDetailsDTO>(authorDetails);
            return authorDetailsDTO;
        }

        public int Add(AuthorDetailsDTO authorDetailsDTO)
        {
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDTO);
            _repository.Add(authorDetails);
            return authorDetails.Id;
        }

        public AuthorDetailsDTO Update(AuthorDetailsDTO authorDetailsDTO)
        {
            var existingAuthordetails = _mapper.Map<AuthorDetails>(authorDetailsDTO);
            var updatedAuthorDetails = _repository.GetAll().AsNoTracking().FirstOrDefault(x=>x.Id == existingAuthordetails.Id);
            if (updatedAuthorDetails != null)
            {
                _repository.Update(updatedAuthorDetails);
            }
            var updatedAuthorDetailsDTO = _mapper.Map<AuthorDetailsDTO>(updatedAuthorDetails);
            return updatedAuthorDetailsDTO;
        }

        public bool Delete(AuthorDetailsDTO authorDetailsDTO)
        {
            var authorDetails = _mapper.Map<AuthorDetails>(authorDetailsDTO);
            var existingDetails = _repository.Get(authorDetails.Id);
            if (existingDetails != null)
            {
                _repository.Delete(existingDetails);
                return true;
            }
            return false;
        }
        public AuthorDetailsDTO GetByAuthorId(int id)
        {
            var authorDetails = _repository.GetAll().Include(a => a.Author).ToList();
            var author = authorDetails.Where(a => a.AuthorId == id).FirstOrDefault();
            var authorDetail = _mapper.Map<AuthorDetailsDTO>(author);
            return authorDetail;
        }
    }
}
