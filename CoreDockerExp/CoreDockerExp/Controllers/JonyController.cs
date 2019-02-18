using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreDockerExp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDockerExp.Controllers
{
    [Route("api/[controller]")]
    public class JonyController : Controller
    {

        private readonly JonyContext _context;

        public JonyController(JonyContext context)
        {
            _context = context;

            if (_context.Jonys.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Jonys.Add(new JonyModel { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/jony
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JonyModel>>> GetAllJonys()
        {
            return await _context.Jonys.ToListAsync();
        }

        // GET: api/jony/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JonyModel>> GetJonyItem(long id)
        {
            var JonyModel = await _context.Jonys.FindAsync(id);

            if (JonyModel == null)
            {
                return NotFound();
            }

            return JonyModel;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
