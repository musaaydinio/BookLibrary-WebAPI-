using Entities;
using Entities.DataTranferObjcets;
using Entities.ResquestFeatures;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;


namespace Presentation.Controllers
{
    [ServiceFilter(typeof(LogFilterAttribute))]
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookPrametrs bookPrametrs)
        {
                var books =await _manager.BookServices.GetAllBooksAsync(bookPrametrs,false);
                return Ok(books);
          
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
                var book = await _manager.BookServices
                .GetOneBookIdAsync(id, false);
                
                return Ok(book);   
        }
        [ServiceFilter(typeof(ValidetionFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookdto)
        { 

              var book= await _manager.BookServices.CreateOneBookAsync(bookdto);
                return StatusCode(201, book);
            
        }
        [ServiceFilter(typeof(ValidetionFilterAttribute))]
        [HttpPut("{id=int}")]
        public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookdto)
        {
           
               await _manager.BookServices.UpdateOneBookAsync(id, bookdto, false);
                return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {

                await _manager.BookServices.DeleteOneBookAsync(id, false);
                return NoContent();
           
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneBookAsync([FromRoute(Name ="id")]int id, 
            [FromBody] JsonPatchDocument<BookDtoForUpdate>bookpatch)
        { 
            if(bookpatch is null)
               return BadRequest();

            var result = await _manager.BookServices.GetOneBookForPatchAsync(id, false);
               
            bookpatch.ApplyTo(result.bookDtoForUpdate,ModelState);

            TryValidateModel(result.bookDtoForUpdate);

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _manager.BookServices.SaveChangesForUpdateAsync(result.bookDtoForUpdate,result.book);
            
            return NoContent();
        }
    }
}

