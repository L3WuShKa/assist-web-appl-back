using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourBackendProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department description is required")]
        public string Description { get; set; }

        // Data la care a fost creat departamentul
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ID-ul organizației la care aparține departamentul
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        // ID-ul managerului departamentului
        public int ManagerId { get; set; }
        public User Manager { get; set; }

        // Lista angajaților din departament
        public ICollection<User> Employees { get; set; }

        // Metoda pentru adăugarea unui angajat în departament
        public void AddEmployee(User employee)
        {
            Employees.Add(employee);
        }

        // Metoda pentru ștergerea unui angajat din departament
        public void RemoveEmployee(User employee)
        {
            Employees.Remove(employee);
        }
    }
}
