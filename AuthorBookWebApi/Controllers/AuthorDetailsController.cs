using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;
using AuthorBookWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailsController : ControllerBase
    {
        private readonly IAuthorDetailsService _authorDetailsService;

        public AuthorDetailsController(IAuthorDetailsService authorDetailsService)
        {
            _authorDetailsService = authorDetailsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _authorDetailsService.GetAll();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existingAuthorDetails = _authorDetailsService.Get(id);
            return Ok(existingAuthorDetails);
        }

        [HttpPost]
        public IActionResult Add(AuthorDetailsDTO authorDetailsDTO)
        {
            var newAuthorDetailsId = _authorDetailsService.Add(authorDetailsDTO);
            return Ok(newAuthorDetailsId);
        }

        [HttpPut]
        public IActionResult Update(AuthorDetailsDTO authorDetailsDTO)
        {
            var updatedAuthorDTODetails = _authorDetailsService.Update(authorDetailsDTO);
            if (updatedAuthorDTODetails != null)
                return Ok(updatedAuthorDTODetails);
            return NotFound("AuthorDetails Not Found");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(AuthorDetailsDTO authorDetailsDTO)
        {
            if (_authorDetailsService.Delete(authorDetailsDTO))
                return Ok("AuthorDetails Deleted Successfully");
            return NotFound("AuthorDetails Not Found");
        }

        [HttpGet("authorDetail/{authorId}")]
        public IActionResult GetByAuthorID(int authorId)
        {
            var detailDTO = _authorDetailsService.GetByAuthorId(authorId);
            return Ok(detailDTO);
        }
    }
}
