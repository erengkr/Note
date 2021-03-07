using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note.Core;
using Note.Model;

namespace Note.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblNotessesController : ControllerBase
    {
        private readonly NotesContext _context;
        private List<TblUser> tblUsers;

        public TblNotessesController(NotesContext context) 
        {
            _context = context;
            tblUsers = _context.TblUsers.ToList();
        }


        // GET: api/TblNotesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblNotess>>> GetTblNotesses()
        {
            return await _context.TblNotesses.ToListAsync();
        }

        // GET: api/TblNotesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblNotess>> GetTblNotess(int id)
        {
            var tblNotess = await _context.TblNotesses.FindAsync(id);

            if (tblNotess == null)
            {
                return NotFound();
            }

            return tblNotess;
        }

        // PUT: api/TblNotesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblNotess(int id, TblNotess tblNotess)
        {
            if (id != tblNotess.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblNotess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNotessExists(id))
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

        // POST: api/TblNotesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblNotess>> PostTblNotess(TblNotess tblNotess)
        {
            if (tblUsers.FindIndex(item => item.Id == tblNotess.UserId) < 1)
            {
                return UnprocessableEntity();
            }

            _context.TblNotesses.Add(tblNotess);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (TblNotessExists(tblNotess.Id))
                {
                    
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblNotess", new { id = tblNotess.Id }, tblNotess);
        }

        // DELETE: api/TblNotesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblNotess(int id)
        {
            var tblNotess = await _context.TblNotesses.FindAsync(id);
            if (tblNotess == null)
            {
                return NotFound();
            }

            _context.TblNotesses.Remove(tblNotess);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblNotessExists(int id)
        {
            return _context.TblNotesses.Any(e => e.Id == id);
        }
    }
}
