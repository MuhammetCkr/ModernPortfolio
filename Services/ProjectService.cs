using System;
using ModernPortfolio.IServices;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories;

namespace ModernPortfolio.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository ?? throw new ArgumentNullException(nameof(projectRepository));
    }
    public Task<int> CreateProjectAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Project>> GetActiveProjectsAsync()
    {
        var project = await _projectRepository.GetActiveProjectsAsync();
        var result = project.OrderByDescending(p => p.CreatedAt);
        return result;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        var project = await _projectRepository.GetAllAsync();
        var result = project.OrderByDescending(p => p.CreatedAt);
        return result;
    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Project ID must be greater than zero.", nameof(id));
        }

        var result = await _projectRepository.GetByIdAsync(id);
        return result;
    }

    public Task<bool> UpdateProjectAsync(Project project)
    {
        throw new NotImplementedException();
    }

    private void ValidateProject(Project project)
    {
        if (project == null)
        {
            throw new ArgumentNullException(nameof(project), "Project cannot be null.");
        }

        if (string.IsNullOrWhiteSpace(project.Title))
        {
            throw new ArgumentException("Project title cannot be empty.", nameof(project.Title));
        }

        if (project.Title.Length > 250)
        {
            throw new ArgumentException("Project title cannot exceed 250 characters.", nameof(project.Title));
        }

        if (string.IsNullOrWhiteSpace(project.Description))
        {
            throw new ArgumentException("Project description cannot be empty.", nameof(project.Description));
        }

        if (!string.IsNullOrWhiteSpace(project.ImageUrl) && project.ImageUrl.Length > 250)
        {
            throw new ArgumentException("Project image URL cannot exceed 250 characters.", nameof(project.ImageUrl));
        }

        if (!string.IsNullOrWhiteSpace(project.ProjectUrl) && !IsValidUrl(project.ProjectUrl))
        {
            throw new ArgumentException("Project URL is not valid.", nameof(project.ProjectUrl));
        }

        if (!string.IsNullOrWhiteSpace(project.GithubUrl) && !IsValidUrl(project.GithubUrl))
        {
            throw new ArgumentException("GitHub URL is not valid.", nameof(project.GithubUrl));
        }
    }

    private bool IsValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        var result = Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
               (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        return result;
    }
}
