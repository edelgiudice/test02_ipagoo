﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace HRApplicationTool.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<HRApplicationTool.Models.SkillModel> SkillModels { get; set; }

        public System.Data.Entity.DbSet<HRApplicationTool.Models.ApplicationModel> ApplicationModels { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SkillModel>()
            .HasKey(t => t.SkillID);
            modelBuilder.Entity<ApplicationModel>()
            .HasKey(t => t.ApplicationID);

            modelBuilder.Entity<SkillModel>()
            .HasMany(t => t.Applications)
            .WithMany(t => t.Skills)
             .Map(m =>
             {
                 m.ToTable("SkillApplication");
                 m.MapLeftKey("SkillID");
                 m.MapRightKey("ApplicationID");
             });
           
        }
    }
}