using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;


namespace DataLayer
{
    public class VacationManagerDbContext : IdentityDbContext
    {
        public VacationManagerDbContext() { }

        public VacationManagerDbContext(DbContextOptions<VacationManagerDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=IVAN-VIPER\\SQLEXPRESS;Database=VacationManagerDb;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer("Server=IVANMLADENOV\\SQLEXPRESS;Database=VacationManagerDb;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(v => v.Vacations).WithOne(v => v.Applicant).HasForeignKey(m => m.ApplicantID);
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();

            //modelBuilder.Entity<Team>().HasOne(t => t.Project).WithMany().HasForeignKey(t => t.ProjectId);
            modelBuilder.Entity<Team>().HasOne(t => t.TeamLeader).WithMany().HasForeignKey(t => t.TeamLeaderId);
            //modelBuilder.Entity<Team>().HasMany(t => t.Users).WithOne(); //New thing i added for conection between Team and User



            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole("CEO") { NormalizedName = "CEO" },
                new IdentityRole("TeamLead") { NormalizedName = "TEAMLEAD" },
                new IdentityRole("Developer") { NormalizedName = "DEVELOPER" }
                //,new IdentityRole("Unassigned") { NormalizedName = "UNASSIGNED" }
                );
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser("Admin") { NormalizedUserName = "ADMIN"});

            //modelBuilder.Entity<User>().HasRequired(u => u.Team).WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Vacation> Vacations { get; set; }

    }
}
