using AuthorBookWebApi.DTOs;
using AuthorBookWebApi.Models;
using AuthorBookWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorBookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookDTOs = _bookService.GetAll();
            return Ok(bookDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existingBookDTO = _bookService.Get(id);
            return Ok(existingBookDTO);
        }

        [HttpPost]
        public IActionResult Add(BookDTO bookDTO)
        {
            var newBookID = _bookService.Add(bookDTO);
            return Ok(newBookID);
        }

        [HttpPut]
        public IActionResult Update(BookDTO bookDTO)
        {
            var updatedBookDTO = _bookService.Update(bookDTO);
            if (updatedBookDTO!=null)
                return Ok(updatedBookDTO);
            return NotFound("Book Not Found");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(BookDTO bookDTO)
        {
            if (_bookService.Delete(bookDTO))
                return Ok("Book Deleted Successfully");
            return NotFound("Book Not Found");
        }

        [HttpGet("author/{id}")]
        public IActionResult GetByAuthorID(int id)
        {
            var bookDTO = _bookService.GetBookByAuthorID(id);
            return Ok(bookDTO);
        }
    }
}
