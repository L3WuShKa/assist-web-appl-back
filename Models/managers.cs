using System.ComponentModel.DataAnnotations;

namespace YourBackendProject.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Manager's first name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Manager's last name is required")]
        public string LastName { get; set; }

        // ID-ul departamentului condus de manager
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Metoda pentru actualizarea numelui managerului
        public void UpdateName(string newFirstName, string newLastName)
        {
            FirstName = newFirstName;
            LastName = newLastName;
        }
    }
}
