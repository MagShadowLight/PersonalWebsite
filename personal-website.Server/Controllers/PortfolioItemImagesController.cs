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
        private readonly IWebHostEnvironment _environment;

        public PortfolioItemImagesController(personal_websiteServerContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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
        [HttpPost("upload")]
        public async Task<ActionResult<PortfolioItemImages>> UploadPortfolioItemImages(IFormFile file, [FromForm] string? name, [FromForm] string? description)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file was uploaded.");
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

            if (!allowedExtensions.Contains(extension))
            {
                return BadRequest("Only JPG, PNG, GIF, and WEBP images are allowed.");
            }

            var imagesDirectory = Path.Combine(_environment.ContentRootPath, "Images");
            Directory.CreateDirectory(imagesDirectory);

            var originalName = Path.GetFileNameWithoutExtension(file.FileName);
            var safeName = string.Join("-", originalName.Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries)).Trim();
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            var fileName = $"{(string.IsNullOrWhiteSpace(safeName) ? "image" : safeName)}-{timestamp}{extension}";
            var filePath = Path.Combine(imagesDirectory, fileName);

            await using (var stream = System.IO.File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            var portfolioItemImages = new PortfolioItemImages
            {
                Name = string.IsNullOrWhiteSpace(name) ? Path.GetFileNameWithoutExtension(file.FileName) : name,
                Description = description ?? string.Empty,
                Path = Path.Combine("Images", fileName).Replace("\\", "/"),
                FileSize = file.Length
            };

            _context.PortfolioItemImages.Add(portfolioItemImages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPortfolioItemImages", new { id = portfolioItemImages.Id }, portfolioItemImages);
        }

        private bool PortfolioItemImagesExists(int id)
        {
            return _context.PortfolioItemImages.Any(e => e.Id == id);
        }
    }
}
