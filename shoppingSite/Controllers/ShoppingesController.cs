using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using shoppingSite.Data;
using shoppingSite.Models;
using System.Security.Cryptography.X509Certificates;

namespace shoppingSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllComputers()
        {
            var computers=ApplicationCntx.Computer;
            return Ok(computers);
        }
        [HttpGet("{id=int}")]
        public IActionResult GetOneComputers([FromRoute(Name = "id")] int id)
        {
            var computer = ApplicationCntx.Computer.Where(b => b.Id.Equals(id)).SingleOrDefault();
            if (computer == null)
               return NotFound();
            return Ok(computer);         
        }
        [HttpPost]
        public IActionResult GetOneComputers([FromBody] Shopping computer)
        {
            try
            {
                if (computer is null)
                    return BadRequest();
                ApplicationCntx.Computer.Add(computer);
                    return StatusCode(201);
           

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }
        [HttpPut("{id=int}")]
        public IActionResult GetOneComputers([FromRoute(Name ="id")] int id,[FromBody]Shopping computer)
        {
            var entitiy = ApplicationCntx.Computer.Find(b => b.Id.Equals(id));
            if (entitiy == null)
                return BadRequest();
            ApplicationCntx.Computer.Remove(entitiy);
            computer.Id = entitiy.Id;
            ApplicationCntx.Computer.Add(computer);
            return Ok(computer);
        }
        [HttpDelete]
        public IActionResult GetAllComputers(int id)
        {
            ApplicationCntx.Computer.Clear();
           return NoContent();
        }
        [HttpDelete("{id=int}")]
        public IActionResult DeleteOneComputers([FromRoute(Name ="id")]int id)
        {
          var entity=ApplicationCntx.Computer.Find(b=>b.Id.Equals(id));
            if(entity == null)
            {
                return NotFound(new
                {
                    statusCode=404,
                    message=$"BU ürünü silin:{id} cloud not found."
                });
            } 
            ApplicationCntx.Computer.Remove(entity);
            return NotFound();
            
        }
        [HttpPatch("{id=int}")]
        public IActionResult GetOneComputer([FromRoute(Name = "id")] int id, [FromBody]
        JsonPatchDocument<Shopping> computerPatch)
        {
            var entity=ApplicationCntx.Computer.Find(b=>b.Id.Equals(id));
            if(entity == null)
            {
                return NotFound();
            }
            computerPatch.ApplyTo(entity);
            return NoContent();
            
        }
    }
}
