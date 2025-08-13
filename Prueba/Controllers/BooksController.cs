using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly Context _context;
        public BooksController(Context context)
        {
            _context = context;
        }
        [HttpGet()]
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAsync(int id)
        {
            var books = await _context.Books.FirstAsync(b => b.Id == id);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAsync(int id, [FromBody] Book book)
        {
            var books = await _context.Books.FirstAsync(b => b.Id == id);
            if (books == null)
            {
                return NotFound();
            }
            books.Title = book.Title;
            books.Author = book.Author;
            var ola = _context.Books.Update(books);
            await _context.SaveChangesAsync();
            return Ok(ola.Entity);
        }

        [HttpPost()]
        public IActionResult PostBook([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteBook(int id)
        {
            var nue = await _context.Books.FirstAsync(b => b.Id == id);
            if (nue != null)
            {
                _context.Books.Remove(nue);
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            else
            {
                return StatusCode(404);
            }
           
            
        }
    }
}
