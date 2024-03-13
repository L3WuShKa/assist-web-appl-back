using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourBackendProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Project details are required")]
        public string Details { get; set; }

        // Data la care a fost creat proiectul
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Lista de departamente asociate proiectului
        public ICollection<Department> Departments { get; set; }

        // Lista de utilizatori asociată proiectului
        public ICollection<User> Users { get; set; }

        // Lista de roluri de echipă personalizate asociate proiectului
        public ICollection<CustomTeamRole> CustomTeamRoles { get; set; }
    }
}
