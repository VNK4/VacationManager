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
        public VacationManagerDbContext()
        {
            
        }

        public VacationManagerDbContext(DbContextOptions<VacationManagerDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace with your server address
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-HJSDM9L\SQLEXPRESS;Database=VacationManagerDb;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(v => v.Vacations).WithOne(v => v.Applicant).HasForeignKey(m => m.ApplicantID);
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<Team>().HasOne(t => t.TeamLeader).WithMany().HasForeignKey(t => t.TeamLeaderId);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole("CEO") { NormalizedName = "CEO" },
                new IdentityRole("TeamLead") { NormalizedName = "TEAMLEAD" },
                new IdentityRole("Developer") { NormalizedName = "DEVELOPER" },
                new IdentityRole("Unassigned") { NormalizedName = "UNASSIGNED" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Vacation> Vacations { get; set; }
        
        public DbSet<User> Users { get; set; }

    }
}
