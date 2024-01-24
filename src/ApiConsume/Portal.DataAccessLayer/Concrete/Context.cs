using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portal.EntityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>//identity kütüphanesinde Guid formatıyla değil, int formatıyla id değeri gelsin diye keye int dedik.
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-C4RG7G4\\SQLEXPRESS; database=PortalDB; integrated security=true; TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<AppUser>().HasOne(x => x.AppUserProfile).WithOne(x=>x.AppUser).HasForeignKey
            builder.Entity<UserEducation>()
       .HasKey(bc => new { bc.Id, bc.EducationId });

            builder.Entity<UserEducation>()
                .HasOne(bc => bc.AppUser)
                .WithMany(b => b.UserEducations)
                .HasForeignKey(bc => bc.Id);

            builder.Entity<UserEducation>()
                .HasOne(bc => bc.Education)
                .WithMany(c => c.UserEducations)
                .HasForeignKey(bc => bc.EducationId);


        



        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserProfile> AppUserProfiles { get; set; }
        
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherInfo> TeacherInfos { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }








    }
}
