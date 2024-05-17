using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Contexts
{
    public class RequestTrackerContext:DbContext
    {
        public RequestTrackerContext(DbContextOptions options):base(options)
        {
        
        }
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestSolution> RequestSolutions { get; set; }
        public DbSet<SolutionFeedback> Feedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000,2,12), Phone = "9876543321", Image = "" },
                new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002,3,24), Phone = "9988776655", Image = "" }
                );
            modelBuilder.Entity<Request>().HasKey(r => r.RequestNumber);
            modelBuilder.Entity<SolutionFeedback>().HasKey(r => r.FeedbackId);


        
            modelBuilder.Entity<RequestSolution>()
                .HasOne(rs => rs.RequestRaised)
                .WithMany(r => r.RequestSolutions)
                .HasForeignKey(rs => rs.RequestId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<RequestSolution>()
                .HasOne(rs => rs.SolvedByEmployee)
                .WithMany(e => e.SolutionsProvided)
                .HasForeignKey(rs => rs.SolvedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            modelBuilder.Entity<SolutionFeedback>()
                .HasOne(sf => sf.Solution)
                .WithMany(s => s.Feedbacks)
                .HasForeignKey(sf => sf.SolutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            modelBuilder.Entity<SolutionFeedback>()
              .HasOne(sf => sf.FeedbackByEmployee)
              .WithMany(e => e.FeedbacksGiven)
              .HasForeignKey(sf => sf.FeedbackBy)
              .OnDelete(DeleteBehavior.Restrict)
              .IsRequired();
        }
    }
}
