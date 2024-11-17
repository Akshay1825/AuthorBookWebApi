using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;
using AuthorBookWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDTOs = _authorService.GetAll();
            return Ok(authorDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existingAuthorDTO = _authorService.Get(id);
            return Ok(existingAuthorDTO);
        }

        [HttpPost]
        public IActionResult Add(AuthorDTO authorDTO)
        {
            var newAuthorId = _authorService.Add(authorDTO);
            return Ok(newAuthorId);
        }

        [HttpPut]
        public IActionResult Update(AuthorDTO authorDTO)
        {
            var UpdatedAuthorDTO = _authorService.Update(authorDTO);
            if(UpdatedAuthorDTO != null)
                return Ok(UpdatedAuthorDTO);
            return NotFound("Author Not Found");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(AuthorDTO authorDTO)
        {
            if (_authorService.Delete(authorDTO))
                return Ok("Author Deleted Successfully");
            return NotFound("Author Not Found");
        }

        [HttpGet("author/{name}")]
        public IActionResult GetByName(string name)
        {
            var authorDTO = _authorService.GetByName(name);
            return Ok(authorDTO);
        }

        [HttpGet("book/{id}")]
        public IActionResult GetAuthorByBookId(int id)
        {
            var authorDTO = _authorService.GetAuthorByBookID(id);
            return Ok(authorDTO);
        }
    }
}
