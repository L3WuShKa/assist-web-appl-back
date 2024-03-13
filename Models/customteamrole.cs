using System.ComponentModel.DataAnnotations;

namespace YourBackendProject.Models
{
    public class CustomTeamRole
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        public string Name { get; set; }

        // ID-ul organizației care a creat rolul echipei personalizat
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        // Descrierea rolului echipei personalizat
        public string Description { get; set; }

        // Metoda pentru actualizarea numelui și descrierii rolului echipei personalizat
        public void UpdateRole(string newName, string newDescription)
        {
            Name = newName;
            Description = newDescription;
        }
    }
}
