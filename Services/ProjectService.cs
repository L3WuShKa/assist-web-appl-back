using System;
using System.Collections.Generic;
using System.Linq;

namespace NumeleProiectului.Services
{
    public class ProjectService
    {
        private List<Project> projects;
        private List<Employee> employees;
        private List<Proposal> proposals;

        public ProjectService()
        {
            projects = new List<Project>();
            employees = new List<Employee>();
            proposals = new List<Proposal>();
        }

        public void CreateProject(string projectName, DateTime startDate, DateTime? deadlineDate, string projectStatus, string generalDescription, List<string> technologyStack, Dictionary<string, int> teamRoles)
        {
            Project project = new Project(projectName, startDate, deadlineDate, projectStatus, generalDescription, technologyStack, teamRoles);
            projects.Add(project);
        }

        public void UpdateProject(int projectId, string projectName, DateTime startDate, DateTime? deadlineDate, string projectStatus, string generalDescription, List<string> technologyStack, Dictionary<string, int> teamRoles)
        {
            Project project = projects.FirstOrDefault(p => p.ProjectId == projectId);
            if (project != null)
            {
                project.ProjectName = projectName;
                project.StartDate = startDate;
                project.DeadlineDate = deadlineDate;
                project.ProjectStatus = projectStatus;
                project.GeneralDescription = generalDescription;
                project.TechnologyStack = technologyStack;
                project.TeamRoles = teamRoles;
            }
        }

        public void DeleteProject(int projectId)
        {
            Project project = projects.FirstOrDefault(p => p.ProjectId == projectId);
            if (project != null)
            {
                projects.Remove(project);
            }
        }

        public List<Employee> FindAvailableEmployees(Project project, bool includePartiallyAvailable, int weeksToProjectCompletion, bool includeUnavailable)
        {
            // Implementarea logicii de găsire a angajaților disponibili
            throw new NotImplementedException();
        }

        public void ProposeAssignment(Employee employee, Project project, int workHours, List<string> roles, string comments)
        {
            // Implementarea logicii de propunere a asignării angajaților la proiect
            throw new NotImplementedException();
        }

        public void ProposeDeallocation(Employee employee, Project project, string deallocationReason)
        {
            // Implementarea logicii de propunere a dealocării angajaților de la proiect
            throw new NotImplementedException();
        }

        // Alte metode pentru gestionarea angajaților, propunerilor și alte operațiuni ar trebui să fie implementate aici
    }

    public class Employee
    {
        // Implementarea detaliilor despre un angajat
    }

    public class Project
    {
        // Implementarea detaliilor despre un proiect
    }

    public class Proposal
    {
        // Implementarea detaliilor despre o propunere de asignare/dezasignare
    }
}
