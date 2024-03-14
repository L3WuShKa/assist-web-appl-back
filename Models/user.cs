using System;
using System.Collections.Generic;

namespace TeamFinder.Models
{
    // Definirea claselor pentru entitățile din sistem
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Organization Organization { get; set; }
        public Role Role { get; set; }
        // Alte proprietăți și metode relevante pentru utilizator

        public User(string name, string email, string password, Organization organization, Role role)
        {
            Name = name;
            Email = email;
            Password = password;
            Organization = organization;
            Role = role;
        }
    }

    public class Organization
    {
        public string Name { get; set; }
        public string HeadquartersAddress { get; set; }
        public List<Department> Departments { get; set; }
        // Alte proprietăți și metode relevante pentru organizație

        public Organization(string name, string headquartersAddress)
        {
            Name = name;
            HeadquartersAddress = headquartersAddress;
            Departments = new List<Department>();
        }
    }

    public class Department
    {
        public string Name { get; set; }
        public DepartmentManager Manager { get; set; }
        public List<Employee> Members { get; set; }
        // Alte proprietăți și metode relevante pentru departament

        public Department(string name, DepartmentManager manager)
        {
            Name = name;
            Manager = manager;
            Members = new List<Employee>();
        }
    }

    public class Project
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public ProjectStatus Status { get; set; }
        public List<string> TechnologyStack { get; set; }
        public Dictionary<string, int> TeamRoles { get; set; }
        public List<Employee> TeamMembers { get; set; }
        // Alte proprietăți și metode relevante pentru proiect

        public Project(string name, DateTime startDate, DateTime deadline, ProjectStatus status, List<string> technologyStack, Dictionary<string, int> teamRoles)
        {
            Name = name;
            StartDate = startDate;
            Deadline = deadline;
            Status = status;
            TechnologyStack = technologyStack;
            TeamRoles = teamRoles;
            TeamMembers = new List<Employee>();
        }
    }

    // Definirea enumerațiilor și altor tipuri necesare
    public enum Role
    {
        Employee,
        OrganizationAdmin,
        DepartmentManager,
        ProjectManager
    }

    public enum ProjectStatus
    {
        NotStarted,
        Starting,
        InProgress,
        Closing,
        Closed
    }

    // Implementarea funcționalităților specifice cerințelor
    public class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // Alte proprietăți și metode relevante pentru abilități

        public Skill(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class NotificationManager
    {
        // Implementare pentru gestionarea notificărilor
    }

    public class StatsManager
    {
        // Implementare pentru gestionarea statisticilor
    }
}
