using BussinessObject.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eAuthorStoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorRepository repository = new AuthorRepository();

        // GET: api/Authors
        [HttpGet("getAll")]
        public ActionResult<IEnumerable<Author>> GetAll()
        {
            return repository.GetAll();
        }

        // GET: api/Authors/5
        [HttpGet("getById/{id}")]
        public ActionResult<Author> GetById(int id)
        {
            var Author = repository.GetById(id);

            if (Author == null)
            {
                return NotFound();
            }

            return Author;
        }

        // PUT: api/Authors/5
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Author Author)
        {
            if (id != Author.AuthorId)
            {
                return BadRequest();
            }
            try
            {
                var result = repository.Update(Author);
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

        // POST: api/Authors
        [HttpPost("create")]
        public ActionResult<Author> Create(Author Author)
        {
            var result = repository.Create(Author);
            if (result != null) return Ok(result);
            else return BadRequest();
        }

        // DELETE: api/Authors/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var Author = repository.GetById(id);
            if (Author == null)
            {
                return NotFound();
            }

            repository.Delete(Author);

            return Ok();
        }
    }

}
