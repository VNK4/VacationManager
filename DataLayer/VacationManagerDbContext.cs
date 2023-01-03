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
                optionsBuilder.UseSqlServer("Server=IVANMLADENOV\\SQLEXPRESS;Database=VacationManagerDb;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer("Server=IVANMLADENOV\\SQLEXPRESS;Database=VacationManagerDb;Trusted_Connection=True;");



            //after  adding migration do:
            //In .NET Core I changed the onDelete option to ReferencialAction.NoAction

            //constraints: table =>
            //{
            //    table.PrimaryKey("PK_Schedule", x => x.Id);
            //    table.ForeignKey(
            //        name: "FK_Schedule_Teams_HomeId",
            //        column: x => x.HomeId,
            //        principalTable: "Teams",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.NoAction);
            //    table.ForeignKey(
            //        name: "FK_Schedule_Teams_VisitorId",
            //        column: x => x.VisitorId,
            //        principalTable: "Teams",
            //        principalColumn: "Id",
            //        onDelete: ReferentialAction.NoAction);
            //});

                //migrationBuilder.AddForeignKey( 
                    //name: "FK-AspnetUsers_Teams_TeamId"
                // i tuk:
                //TeamLeaderId
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(v => v.Vacations).WithOne(v => v.Applicant).HasForeignKey(m => m.ApplicantID);
            modelBuilder.Entity<User>().HasIndex(u => u.FirstName).IsUnique();

            //modelBuilder.Entity<Team>().HasOne(t => t.Project).WithMany().HasForeignKey(t => t.ProjectId);
            modelBuilder.Entity<Team>().HasOne(t => t.TeamLeader).WithMany().HasForeignKey(t => t.TeamLeaderId);



            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole("CEO") { NormalizedName = "CEO" },
                new IdentityRole("TeamLead") { NormalizedName = "TEAMLEAD" },
                new IdentityRole("Developer") { NormalizedName = "DEVELOPER" }
                //,new IdentityRole("Unassigned") { NormalizedName = "UNASSIGNED" }
                );
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser("Admin") { NormalizedUserName = "ADMIN"});

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Project> Projects { get; set; }

    }
}
