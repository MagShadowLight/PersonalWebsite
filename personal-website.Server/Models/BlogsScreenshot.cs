using System;

namespace personal_website.Server.Models;

public class BlogsScreenshot
{
    public int BlogsScreenshotId { get; set; }
    public string Path { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Blogs? Blogs { get; set; }
}
