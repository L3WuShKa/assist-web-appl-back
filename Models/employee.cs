using System;
using System.Collections.Generic;

namespace TeamFinder.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectProposal> ProjectProposals { get; set; }
        public List<Project> AssignedProjects { get; set; }

        // Constructor
        public Employee()
        {
            Skills = new List<Skill>();
            ProjectProposals = new List<ProjectProposal>();
            AssignedProjects = new List<Project>();
        }

        // Metodă pentru adăugarea unei abilități
        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }

        // Metodă pentru adăugarea unei propuneri de proiect
        public void AddProjectProposal(ProjectProposal proposal)
        {
            ProjectProposals.Add(proposal);
        }

        // Metodă pentru acceptarea unei propuneri de proiect
        public void AcceptProjectProposal(ProjectProposal proposal)
        {
            ProjectProposals.Remove(proposal);
            AssignedProjects.Add(proposal.Project);
        }

        // Metodă pentru respingerea unei propuneri de proiect
        public void RejectProjectProposal(ProjectProposal proposal)
        {
            ProjectProposals.Remove(proposal);
        }
    }
}
