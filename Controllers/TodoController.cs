using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.DTOs;
using ToDoList.Api.Mapper;
using ToDoList.Api.Services;

namespace ToDoList.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        private readonly IRepository Repos;
        public TodoController(IRepository _repos)
        {
            Repos = _repos;
        }

        

        [HttpGet("GetAllToDo")]
        public async Task<IActionResult> GetAll()
        {
            try
            {


                // Fetch the authenticated user's ID
                string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId is null) return BadRequest("User does not exist!");

                var items = await Repos.GetAll(userId);

                return Ok(items);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTodo/{id}")]
        public async Task<IActionResult> GetTodo(int id)
        {
            try
            {

                // Fetch the authenticated user's ID
                string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId is null) return BadRequest("User does not exist!");

                var item = await Repos.GetSingle(id, userId);
                if (item is null) return NotFound();


                
                return Ok(item.MapToSummeryDTO());
            }


            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("CreateTodo")]
        public async Task<IActionResult> CreateTodo([FromBody] CreateToDoDTO item)
        {
            try
            {

                string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId is null) return BadRequest("User does not exist!");

                var newItem = await Repos.CreateTodo(item, userId);

                return CreatedAtAction(nameof(GetTodo), new { id = newItem!.Id }, newItem.MapToSummeryDTO());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] UpdateTodoDTO item)
        {
            try
            {


                string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId is null) return BadRequest("User does not exist!");

                var result = await Repos.UpDateTodo(id, item, userId);
                if (result is false) return BadRequest(); //returns a true or false

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            try
            {

                string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId is null) return BadRequest("User does not exist!");

                var result = await Repos.DeleteTodo(id, userId); //returns a true or false

                if (result is false) return BadRequest();

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJla2VsZW1lMjJAZ21haWwuY29tIiwianRpIjoiMWFkMWM0NzktZGU3OC00NGRlLWE5OWItZmMyMTEyYzM1M2VlIiwiZXhwIjoxNzI2MTIyNDk5LCJpc3MiOiJUb0RvTGlzdCIsImF1ZCI6IlRvRG9MaXN0In0._6z2p09zpyTRGJGlZw7ZocKgjoG2itCA2isgaAqgeLw