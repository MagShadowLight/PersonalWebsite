using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using personal_website.Server.Data;
using personal_website.Server.Models;

namespace personal_website.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioItemsController : ControllerBase
    {
        private readonly personal_websiteServerContext _context;

        public PortfolioItemsController(personal_websiteServerContext context)
        {
            _context = context;
        }

        // GET: api/PortfolioItems
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortfolioItems>>> GetPortfolioItems()
        {
            return await _context.PortfolioItems.ToListAsync();
        }

        // GET: api/PortfolioItems/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioItems>> GetPortfolioItems(int id)
        {
            var portfolioItems = await _context.PortfolioItems.FindAsync(id);

            if (portfolioItems == null)
            {
                return NotFound();
            }

            return portfolioItems;
        }

        // PUT: api/PortfolioItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortfolioItems(int id, PortfolioItems portfolioItems)
        {
            if (id != portfolioItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(portfolioItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioItemsExists(id))
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

        // POST: api/PortfolioItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PortfolioItems>> PostPortfolioItems(PortfolioItems portfolioItems)
        {

            if (portfolioItems.CategoryId != 0)
            {
                // get category from CategoryId
                var category = _context.Categories.FindAsync(portfolioItems.CategoryId);
                // put category in items
                portfolioItems.Category = await category;
            } else
            {
                return BadRequest();
            }

            _context.PortfolioItems.Add(portfolioItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortfolioItems", new { id = portfolioItems.Id }, portfolioItems);
        }

        // DELETE: api/PortfolioItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolioItems(int id)
        {
            var portfolioItems = await _context.PortfolioItems.FindAsync(id);
            if (portfolioItems == null)
            {
                return NotFound();
            }

            _context.PortfolioItems.Remove(portfolioItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PortfolioItemsExists(int id)
        {
            return _context.PortfolioItems.Any(e => e.Id == id);
        }
    }
}
