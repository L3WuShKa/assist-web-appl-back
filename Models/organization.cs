using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourBackendProject.Models
{
    public class Organization
    {
        // ID-ul organizației
        [Key]
        public int OrganizationId { get; set; }

        // Numele organizației, necesar
        [Required(ErrorMessage = "Please provide the organization name")]
        public string Name { get; set; }

        // Adresa sediului central al organizației, necesară
        [Required(ErrorMessage = "Please provide the headquarters address")]
        public string HeadquartersAddress { get; set; }

        // Data și ora la care a fost creată organizația, implicită setată la momentul actual
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Lista utilizatorilor care fac parte din organizație
        public ICollection<User> Users { get; set; }

        // Metoda pentru adăugarea unui utilizator la organizație
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        // Metoda pentru ștergerea unui utilizator din organizație
        public void RemoveUser(User user)
        {
            Users.Remove(user);
        }
    }
}
