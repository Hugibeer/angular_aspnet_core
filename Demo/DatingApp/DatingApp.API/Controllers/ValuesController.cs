using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DataContext _context;
        public ValuesController(DataContext _context)
        {
            this._context = _context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _context.Values.ToArrayAsync();
            return Ok(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var value = await _context.Values
                .Where(v => v.ID == id)
                .FirstOrDefaultAsync();
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Value value)
        {
            try 
            {
                var newValue = new Value
                {
                    Name = value.Name
                };
                _context.Values.Add(newValue);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch 
            {
                return BadRequest("Input data is not valid.");
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]string value)
        {
            var existingValue = _context.Values.Find(id);
            if (existingValue != null) 
            {
                existingValue.Name = value;
                _context.Entry(value).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest("Input data is not valid.");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = _context.Values.Find(id);
            if (value != null) 
            {
                _context.Entry(value).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();
        }
    }
}
