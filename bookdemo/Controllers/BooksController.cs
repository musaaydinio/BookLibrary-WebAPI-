using bookdemo.Data;
using bookdemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookdemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContextcs.Books;
            return Ok(books);
        }
        [HttpGet("{id=int}")]
        public IActionResult GetAllBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContextcs.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();

            if(book is null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CrateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();
                ApplicationContextcs.Books.Add(book);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id=int}")]
        public IActionResult UpdateOneBook([FromRoute(Name ="id")]int id ,[FromBody] Book book)
        {
            var entity = ApplicationContextcs.Books.Find(b => b.Id.Equals(id));

            if(entity is null)
            {
                return NotFound();
            }
            if (id!= book.Id)
            {
                return BadRequest();
            }
            ApplicationContextcs.Books.Remove(entity);
            book.Id=entity.Id;
            ApplicationContextcs.Books.Add(book);
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContextcs.Books.Clear();
            return NoContent();
        }
        [HttpDelete("{id=int}")]
        public IActionResult DeleteOneBook([FromRoute(Name="id")]int id)
        {
            var entitiy=ApplicationContextcs.Books.Find(b=>b.Id.Equals(id));
            if (entitiy is null)
            {
                return NotFound(new
                {
                    statuscode =404,
                    message =$"Book with id={id} could not found."

                });
            }
            ApplicationContextcs.Books.Remove(entitiy);
            return NoContent();
        }

        [HttpPatch("{id=int}")]
        public IActionResult PartiallyOneBook([FromRoute(Name="id")] int id, [FromBody] 
        JsonPatchDocument<Book> bookPatch)
        {
            var entity = ApplicationContextcs.Books.Find(b => b.Id.Equals(id));
            if (entity is null)
                return NotFound();

            bookPatch.ApplyTo(entity);
            return NoContent();
        }
    }  
}
