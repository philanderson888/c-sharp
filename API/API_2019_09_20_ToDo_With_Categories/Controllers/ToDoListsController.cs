using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_2019_09_20_ToDo_With_Categories;

namespace API_2019_09_20_ToDo_With_Categories.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public ToDoListsController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/ToDoLists
        [HttpGet]
        public IEnumerable<ToDoList> GetToDoLists()
        {
            return _context.ToDoLists;
        }

        // GET: api/ToDoLists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoList = await _context.ToDoLists.FindAsync(id);

            if (toDoList == null)
            {
                return NotFound();
            }

            return Ok(toDoList);
        }

        // PUT: api/ToDoLists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoList([FromRoute] int id, [FromBody] ToDoList toDoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoList.ToDoListId)
            {
                return BadRequest();
            }

            _context.Entry(toDoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoLists
        [HttpPost]
        public async Task<IActionResult> PostToDoList([FromBody] ToDoList toDoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ToDoLists.Add(toDoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoList", new { id = toDoList.ToDoListId }, toDoList);
        }

        // DELETE: api/ToDoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoList = await _context.ToDoLists.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }

            _context.ToDoLists.Remove(toDoList);
            await _context.SaveChangesAsync();

            return Ok(toDoList);
        }

        private bool ToDoListExists(int id)
        {
            return _context.ToDoLists.Any(e => e.ToDoListId == id);
        }
    }
}