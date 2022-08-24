using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HUTECH_API_DB.Models;

namespace HUTECH_API_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly HutechAPI _context;

        public DatabaseController(HutechAPI context)
        {
            _context = context;
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<Database>>> GetDatabaseByUserId(int userId)
        //{
        //    if (_context.Users == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.Users.Include(user => user.Databases).FirstOrDefaultAsync(user => user.Id == userId);
        //    if (user == null)
        //    {
        //        return BadRequest();
        //    }
        //    var databases = user.Databases;
        //    if (databases == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(databases);
        //}

        // GET: api/Database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Database>>> GetDatabases()
        {
          if (_context.Databases == null)
          {
              return NotFound();
          }
            return await _context.Databases.ToListAsync();
        }

        // GET: api/Database/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Database>> GetDatabase(int id)
        {
          if (_context.Databases == null)
          {
              return NotFound();
          }
            var database = await _context.Databases.FindAsync(id);

            if (database == null)
            {
                return NotFound();
            }

            return database;
        }

        // PUT: api/Database/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatabase(int id, Database database)
        {
            if (id != database.Id)
            {
                return BadRequest();
            }

            _context.Entry(database).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatabaseExists(id))
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

        // POST: api/Database
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Database>> PostDatabase(Database database)
        {
          if (_context.Databases == null)
          {
              return Problem("Entity set 'HutechAPI.Databases'  is null.");
          }
            _context.Databases.Add(database);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatabase", new { id = database.Id }, database);
        }

        // DELETE: api/Database/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatabase(int id)
        {
            if (_context.Databases == null)
            {
                return NotFound();
            }
            var database = await _context.Databases.FindAsync(id);
            if (database == null)
            {
                return NotFound();
            }

            _context.Databases.Remove(database);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatabaseExists(int id)
        {
            return (_context.Databases?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
