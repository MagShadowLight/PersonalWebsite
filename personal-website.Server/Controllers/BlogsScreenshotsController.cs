using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class BlogsScreenshotsController : ControllerBase
    {
        private readonly personal_websiteServerContext _context;
        private readonly IWebHostEnvironment _environment;

        public BlogsScreenshotsController(personal_websiteServerContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/BlogsScreenshots
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogsScreenshot>>> GetBlogsScreenshot()
        {
            return await _context.BlogsScreenshot.ToListAsync();
        }

        // GET: api/BlogsScreenshots/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogsScreenshot>> GetBlogsScreenshot(int id)
        {
            var blogsScreenshot = await _context.BlogsScreenshot.FindAsync(id);

            if (blogsScreenshot == null)
            {
                return NotFound();
            }

            return blogsScreenshot;
        }

        // PUT: api/BlogsScreenshots/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogsScreenshot(int id, BlogsScreenshot blogsScreenshot)
        {
            if (id != blogsScreenshot.BlogsScreenshotId)
            {
                return BadRequest();
            }

            _context.Entry(blogsScreenshot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogsScreenshotExists(id))
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

        // POST: api/BlogsScreenshots
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogsScreenshot>> PostBlogsScreenshot(BlogsScreenshot blogsScreenshot)
        {
            _context.BlogsScreenshot.Add(blogsScreenshot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogsScreenshot", new { id = blogsScreenshot.BlogsScreenshotId }, blogsScreenshot);
        }
        [HttpPost("upload")]
        public async Task<ActionResult<BlogsScreenshot>> UploadBlogsScreenshot(IFormFile file, [FromForm] string? description)
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

            var blogsScreenshot = new BlogsScreenshot
            {
                Path = filePath,
                Description = description ?? Path.GetFileNameWithoutExtension(file.FileName)
            };

            _context.BlogsScreenshot.Add(blogsScreenshot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogsScreenshot", new { id = blogsScreenshot.BlogsScreenshotId }, blogsScreenshot);
        }

        // DELETE: api/BlogsScreenshots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogsScreenshot(int id)
        {
            var blogsScreenshot = await _context.BlogsScreenshot.FindAsync(id);
            if (blogsScreenshot == null)
            {
                return NotFound();
            }

            _context.BlogsScreenshot.Remove(blogsScreenshot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogsScreenshotExists(int id)
        {
            return _context.BlogsScreenshot.Any(e => e.BlogsScreenshotId == id);
        }
    }
}
