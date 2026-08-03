using Entities;
using Entities.DataTranferObjcets;
using Entities.LinkModels;
using Entities.ResquestFeatures;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text.Json;


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

        [HttpHead]
        [HttpGet(Name ="GetAllBooksAsync")]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookPrametrs bookPrametrs)
        {
                var linkParameters=new lLinkParameters()
                {
                    BookPrametrs = bookPrametrs,
                    HttpContext=HttpContext
                };
                var result = await _manager.BookServices.GetAllBooksAsync(linkParameters,false);
                Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.MetaDeta));

            return result .linkResponse.Haslinks? 
                Ok(result.linkResponse.LinkedEntities):
                Ok(result.linkResponse.ShapedEntities);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
                var book = await _manager.BookServices
                .GetOneBookIdAsync(id, false);
                
                return Ok(book);   
        }
        [ServiceFilter(typeof(ValidetionFilterAttribute))]
        [HttpPost(Name ="CreateOneBookAsync")]
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

        [HttpOptions]
        public IActionResult GetBooksOptions()
        {
            Response.Headers.Add("Allow", "GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
}

