using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? DeadlineDate { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public List<string> TechnologyStack { get; set; }
    public Dictionary<string, int> TeamRoles { get; set; }
}

public class TeamMember
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Dictionary<string, int> Skills { get; set; }
    public List<string> AssignedProjects { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public int OrganizationId { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ManagerId { get; set; }
    public List<int> MemberIds { get; set; }
}

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public List<int> DepartmentIds { get; set; }
}

public class SkillAssignment
{
    public int UserId { get; set; }
    public int SkillId { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
}

public class ProjectAssignment
{
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public Dictionary<string, int> Roles { get; set; }
    public int WorkHoursPerDay { get; set; }
    public string Comments { get; set; }
}

public class DeallocationProposal
{
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public string Reason { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly ProjectRepository _repository;

    public ProjectController(ProjectRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public IActionResult CreateProject(Project project)
    {
        _repository.CreateProject(project);
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetProject(int id)
    {
        var project = _repository.GetProjectById(id);
        if (project == null)
            return NotFound();
        return Ok(project);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProject(int id, Project project)
    {
        if (id != project.Id)
            return BadRequest();
        _repository.UpdateProject(project);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProject(int id)
    {
        _repository.DeleteProject(id);
        return Ok();
    }

    [HttpPost("assign")]
    public IActionResult AssignMemberToProject(ProjectAssignment assignment)
    {
        _repository.AssignMemberToProject(assignment);
        return Ok();
    }

    [HttpPost("deallocation")]
    public IActionResult ProposeDeallocation(DeallocationProposal proposal)
    {
        _repository.ProposeDeallocation(proposal);
        return Ok();
    }
}

public class ProjectRepository
{
    private readonly List<Project> _projects;

    public ProjectRepository()
    {
        _projects = new List<Project>();
    }

    public void CreateProject(Project project)
    {
        // Implementare creare proiect
    }

    public Project GetProjectById(int id)
    {
        // Implementare obținere proiect după ID
    }

    public void UpdateProject(Project project)
    {
        // Implementare actualizare proiect
    }

    public void DeleteProject(int id)
    {
        // Implementare ștergere proiect
    }

    public void AssignMemberToProject(ProjectAssignment assignment)
    {
        // Implementare atribuire membru proiect
    }

    public void ProposeDeallocation(DeallocationProposal proposal)
    {
        // Implementare propunere dealocare membru proiect
    }
}
