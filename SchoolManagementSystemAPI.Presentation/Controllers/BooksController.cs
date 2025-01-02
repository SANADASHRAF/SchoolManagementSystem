using Contracts;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystemAPI.Presentation.Controllers
{
    [Route("SchoolManagement/BooksController/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {


        private readonly IServiceManager _service;
        private readonly ILoggerManager _logger;
        public BooksController(IServiceManager service, ILoggerManager logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet(Name = "GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _service.bookService.GetAllBooksAsync(trackChanges: false);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error-{ex.Message}");
            }
        }

        [HttpGet(Name = "GetBookById")]
        public async Task<IActionResult> GetBookById(long id)
        {
            try
            {
                var book = await _service.bookService.GetBookByIdAsync(id, trackChanges: false);
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error-{ex.Message}");
            }
        }

        [HttpGet(Name = "GetBooksByTermAndYear")]
        public async Task<IActionResult> GetBooksByTermAndYear(int termId, int academicYearId)
        {
            var books = await _service.bookService.GetBooksByTermAndYearAsync(termId, academicYearId, trackChanges: false);
            return Ok(books);
        }

        [HttpPost(Name = "CreateBook")]
        public async Task<IActionResult> CreateBook([FromForm] BookForCreationDto bookDto)
        {
            try
            {
                var book = await _service.bookService.CreateBookAsync(bookDto);
                return CreatedAtRoute("GetBookById", new { id = book.BookId }, book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error-{ex.Message}");
            }

        }

        [HttpDelete(Name = "DeleteBook")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            try
            {
                await _service.bookService.DeleteBookAsync(id);
                return Ok("Deleted Successfully!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error-{ex.Message}");
            }
        }




    }
}
