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
    public class PortfolioItemImagesController : ControllerBase
    {
        private readonly personal_websiteServerContext _context;

        public PortfolioItemImagesController(personal_websiteServerContext context)
        {
            _context = context;
        }

        // GET: api/PortfolioItemImages
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PortfolioItemImages>>> GetPortfolioItemImages()
        {
            return await _context.PortfolioItemImages.ToListAsync();
        }

        // GET: api/PortfolioItemImages/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<PortfolioItemImages>> GetPortfolioItemImages(int id)
        {
            var portfolioItemImages = await _context.PortfolioItemImages.FindAsync(id);

            if (portfolioItemImages == null)
            {
                return NotFound();
            }

            return portfolioItemImages;
        }

        // PUT: api/PortfolioItemImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortfolioItemImages(int id, PortfolioItemImages portfolioItemImages)
        {
            if (id != portfolioItemImages.Id)
            {
                return BadRequest();
            }

            _context.Entry(portfolioItemImages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioItemImagesExists(id))
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

        // POST: api/PortfolioItemImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PortfolioItemImages>> PostPortfolioItemImages(PortfolioItemImages portfolioItemImages)
        {
            _context.PortfolioItemImages.Add(portfolioItemImages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortfolioItemImages", new { id = portfolioItemImages.Id }, portfolioItemImages);
        }

        // DELETE: api/PortfolioItemImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolioItemImages(int id)
        {
            var portfolioItemImages = await _context.PortfolioItemImages.FindAsync(id);
            if (portfolioItemImages == null)
            {
                return NotFound();
            }

            _context.PortfolioItemImages.Remove(portfolioItemImages);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PortfolioItemImagesExists(int id)
        {
            return _context.PortfolioItemImages.Any(e => e.Id == id);
        }
    }
}
