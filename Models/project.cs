using System;
using System.Collections.Generic;

namespace TeamFinder.Models
{
    public class Project
    {
        public string Name { get; set; }
        public ProjectPeriod Period { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public ProjectStatus Status { get; set; }
        public string Description { get; set; }
        public List<string> TechnologyStack { get; set; }
        public Dictionary<string, int> TeamRoles { get; set; }
        public List<ProjectMember> TeamMembers { get; set; }

        public Project(string name, ProjectPeriod period, DateTime startDate, DateTime? deadline, ProjectStatus status, string description, List<string> technologyStack, Dictionary<string, int> teamRoles)
        {
            Name = name;
            Period = period;
            StartDate = startDate;
            Deadline = deadline;
            Status = status;
            Description = description;
            TechnologyStack = technologyStack;
            TeamRoles = teamRoles;
            TeamMembers = new List<ProjectMember>();
        }

        public void UpdateProject(string name, ProjectPeriod period, DateTime startDate, DateTime? deadline, string description, List<string> technologyStack, Dictionary<string, int> teamRoles)
        {
            Name = name;
            Period = period;
            StartDate = startDate;
            Deadline = deadline;
            Description = description;
            TechnologyStack = technologyStack;
            TeamRoles = teamRoles;
        }

        public void DeleteProject()
        {
            // Implementarea logicii pentru ștergerea proiectului
        }
    }

    public class ProjectMember
    {
        public string UserId { get; set; }
        public string Role { get; set; }
        public int WorkHoursPerDay { get; set; }
        public string Comments { get; set; }
    }

    public enum ProjectPeriod
    {
        Fixed,
        Ongoing
    }

    public enum ProjectStatus
    {
        NotStarted,
        Starting,
        InProgress,
        Closing,
        Closed
    }
}
