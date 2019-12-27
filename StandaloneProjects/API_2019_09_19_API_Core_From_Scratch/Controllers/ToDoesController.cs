using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_2019_09_19_API_Core_From_Scratch.Models;

namespace API_2019_09_19_API_Core_From_Scratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoesController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public ToDoesController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/ToDoes
        [HttpGet]
        public IEnumerable<ToDo> GetToDoes()
        {
            return _context.ToDoes;
        }

        // GET: api/ToDoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDo([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDo = await _context.ToDoes.FindAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }

            return Ok(toDo);
        }

        // PUT: api/ToDoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDo([FromRoute] long id, [FromBody] ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDo.ToDoId)
            {
                return BadRequest();
            }

            _context.Entry(toDo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(id))
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

        // POST: api/ToDoes
        [HttpPost]
        public async Task<IActionResult> PostToDo([FromBody] ToDo toDo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ToDoes.Add(toDo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDo", new { id = toDo.ToDoId }, toDo);
        }

        // DELETE: api/ToDoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDo = await _context.ToDoes.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            _context.ToDoes.Remove(toDo);
            await _context.SaveChangesAsync();

            return Ok(toDo);
        }

        private bool ToDoExists(long id)
        {
            return _context.ToDoes.Any(e => e.ToDoId == id);
        }
    }
}