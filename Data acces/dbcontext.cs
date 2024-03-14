using Microsoft.EntityFrameworkCore;

namespace YourProject.DataLayer
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        // Define DbSet properties for your entities
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TeamRole> TeamRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity relationships and constraints
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Organization)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OrganizationId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Skills)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.EmployeeId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.TeamRoles)
                .WithOne(tr => tr.Project)
                .HasForeignKey(tr => tr.ProjectId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            // Add any other configurations here

            base.OnModelCreating(modelBuilder);
        }
    }
}
