using System.ComponentModel.DataAnnotations;

namespace YourBackendProject.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required(ErrorMessage = "Skill name is required")]
        public string Name { get; set; }

        // Descrierea abilității
        public string Description { get; set; }

        // Nivelul de competență asociat abilității (de exemplu, avansat, intermediar, începător)
        public string Level { get; set; }

        // ID-ul utilizatorului asociat abilității
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
