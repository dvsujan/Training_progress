using ClinicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.contexts
{
    public class ClinicAppContext:DbContext
    {
        public ClinicAppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "Dr. Ram",
                    Speciality = "General Physician",
                    Experience = 10
                },
                new Doctor
                {
                    Id = 2,
                    Name = "Dr. Bhim",
                    Speciality = "Dermatologist",
                    Experience = 5
                },
                new Doctor
                {
                    Id = 3,
                    Name = "Dr. Som",
                    Speciality = "Cardiologist",
                    Experience = 15
                }
               );
        }
    }
}
