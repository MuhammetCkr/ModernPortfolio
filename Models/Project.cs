using System;

namespace ModernPortfolio.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string? ProjectUrl { get; set; }
    public string? GithubUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}
