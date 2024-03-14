using System;
using System.Collections.Generic;

namespace YourNamespace.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<string> Skills { get; set; }
        public List<Project> Projects { get; set; }
        public List<string> Notifications { get; set; }
        public Role Role { get; set; }
        public Department Department { get; set; }

        public Employee(string name, string email, string password, Role role, Department department)
        {
            Name = name;
            Email = email;
            Password = password;
            Skills = new List<string>();
            Projects = new List<Project>();
            Notifications = new List<string>();
            Role = role;
            Department = department;
        }

        public void UpdateSkills(List<string> newSkills)
        {
            Skills.AddRange(newSkills);
        }

        public void ReceiveNotification(string notification)
        {
            Notifications.Add(notification);
        }

        public void AssignToProject(Project project)
        {
            Projects.Add(project);
            project.AddMember(this);
        }

        public void RemoveFromProject(Project project)
        {
            Projects.Remove(project);
            project.RemoveMember(this);
        }
//ok
    }
}
