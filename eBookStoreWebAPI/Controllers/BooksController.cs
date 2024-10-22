using BussinessObject.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookRepository repository = new BookRepository();

        // GET: api/Books
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return repository.GetAll();
        }

        // GET: api/Books/5
        [HttpGet("getById/{id}")]
        public ActionResult<Book> GetById(int id)
        {
            var Book = repository.GetById(id);

            if (Book == null)
            {
                return NotFound();
            }

            return Book;
        }

        // PUT: api/Books/5
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Book Book)
        {
            if (id != Book.BookId)
            {
                return BadRequest();
            }
            try
            {
              var result =  repository.Update(Book);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Update failed");
            }

            return NoContent();
        }

        // POST: api/Books
        [HttpPost("create")]
        public ActionResult<Book> Create(Book Book)
        {
           var result = repository.Create(Book);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

        // DELETE: api/Books/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var Book = repository.GetById(id);
            if (Book == null)
            {
                return NotFound();
            }

            repository.Delete(Book);

            return Ok();
        }
    }
}
