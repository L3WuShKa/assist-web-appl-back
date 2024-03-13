using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourBackendProject.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Team name is required")]
        public string Name { get; set; }

        // Lista de membri ai echipei
        public ICollection<User> Members { get; set; }

        // ID-ul proiectului asociat echipei
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        // Metoda pentru adăugarea unui membru la echipă
        public void AddMember(User member)
        {
            Members.Add(member);
        }

        // Metoda pentru ștergerea unui membru din echipă
        public void RemoveMember(User member)
        {
            Members.Remove(member);
        }
    }
}
