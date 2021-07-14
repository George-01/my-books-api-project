using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _bookService;

        public BooksController(BooksService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return StatusCode(200, allBooks);
        }

        [HttpGet("get-book-by-Id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return StatusCode(200, book);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBook(book);
            return StatusCode(201, "Book Created Successfully");
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody]BookVM book)
        {
            var updatedBook = _bookService.UpdateBookById(id, book);
            return StatusCode(200, updatedBook);
        }

        [HttpDelete("delete-books-by-id/{id}")]
        public IActionResult DeleteBookByID(int id)
        {
            _bookService.DeleteBookByID(id);
            return Ok();
        }
    }
}
