using Microsoft.AspNetCore.Mvc;
using Prueba.Models;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;
        public ClienteController(Context context)
        {
            _context = context;
        }
        [HttpGet(Name ="GetBooks")]
        public IActionResult GetBooks()
        {
            var books = _context.Books.ToList();
            return Ok(books);
        }

        [HttpPost(Name = "PostBooks")]
        public IActionResult PostBoooks([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
        }
    }
}
