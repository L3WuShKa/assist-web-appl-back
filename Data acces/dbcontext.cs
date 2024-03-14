using Microsoft.EntityFrameworkCore;

namespace NumeProiect.Data
{
    public class NumeProiectContext : DbContext
    {
        public NumeProiectContext(DbContextOptions<NumeProiectContext> options)
            : base(options)
        {
        }

        // Entități pentru tabelele din baza de date
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }
        // Adăugați aici și alte DbSet-uri pentru alte entități necesare în aplicația dvs.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurări pentru schema bazei de date
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Project>().ToTable("Projects");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Skill>().ToTable("Skills");
            modelBuilder.Entity<ProjectAssignment>().ToTable("ProjectAssignments");

            // Definiți relațiile între entități
            modelBuilder.Entity<ProjectAssignment>()
                .HasOne(pa => pa.User)
                .WithMany(u => u.ProjectAssignments)
                .HasForeignKey(pa => pa.UserId);

            modelBuilder.Entity<ProjectAssignment>()
                .HasOne(pa => pa.Project)
                .WithMany(p => p.ProjectAssignments)
                .HasForeignKey(pa => pa.ProjectId);

            modelBuilder.Entity<UserSkill>()
                .HasKey(us => new { us.UserId, us.SkillId });

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.Skill)
                .WithMany(s => s.UserSkills)
                .HasForeignKey(us => us.SkillId);
        }
    }

    // Entități pentru tabelele din baza de date
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        // Alte proprietăți pentru utilizator, cum ar fi email, parola, etc.
        public List<ProjectAssignment> ProjectAssignments { get; set; }
        public List<UserSkill> UserSkills { get; set; }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        // Alte proprietăți pentru proiect, cum ar fi descrierea, perioada, etc.
        public List<ProjectAssignment> ProjectAssignments { get; set; }
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        // Alte proprietăți pentru departament, cum ar fi descrierea, managerul departamentului, etc.
    }

    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        // Alte proprietăți pentru skill, cum ar fi descrierea, categoria, etc.
        public List<UserSkill> UserSkills { get; set; }
    }

    public class ProjectAssignment
    {
        public int ProjectAssignmentId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        // Alte proprietăți pentru atributele atribuirii proiectului, cum ar fi rolul, orele de lucru, etc.
        public User User { get; set; }
        public Project Project { get; set; }
    }

    public class UserSkill
    {
        public int UserId { get; set; }
        public int SkillId { get; set; }
        public int Level { get; set; }
        // Alte proprietăți pentru atributele relației utilizator-skill, cum ar fi experiența, etc.
        public User User { get; set; }
        public Skill Skill { get; set; }
    }
}
