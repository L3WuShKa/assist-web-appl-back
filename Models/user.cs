using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*
reprezintă un utilizator și include detalii precum nume, email, parolă, 
rol și alte informații relevante, precum și metode pentru gestionarea
 abilităților și alte funcționalități legate de utilizatori.
*/
namespace YourBackendProject.Models
{
    public enum UserRole
    {
        Admin,
        Employee
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public UserRole Role { get; set; }

        // Relație cu Organizație
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        // Proprietate calculată pentru numele complet al utilizatorului
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        // Lista de abilități ale utilizatorului
        public ICollection<Skill> Skills { get; set; }

        // Data la care a fost creat utilizatorul
        public DateTime CreatedAt { get; set; }

        // Metoda pentru adăugarea unei abilități utilizatorului
        public void AddSkill(Skill skill)
        {
            Skills.Add(skill);
        }

        // Metoda pentru ștergerea unei abilități utilizatorului
        public void RemoveSkill(Skill skill)
        {
            Skills.Remove(skill);
        }
    }
}
