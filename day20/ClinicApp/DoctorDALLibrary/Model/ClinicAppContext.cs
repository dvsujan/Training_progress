using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClinicDALLibrary.Model;

public partial class ClinicAppContext : DbContext
{
    public ClinicAppContext()
    {
    }

    public ClinicAppContext(DbContextOptions<ClinicAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=794GBX3\\INSTANCE_1;Integrated Security=true;Initial Catalog=ClinicApp;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_ap");

            entity.ToTable("Appointment");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DocId).HasColumnName("docId");
            entity.Property(e => e.PatId).HasColumnName("patId");
            entity.Property(e => e.Reason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reason");

            entity.HasOne(d => d.Doc).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DocId)
                .HasConstraintName("fk_doc");

            entity.HasOne(d => d.Pat).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatId)
                .HasConstraintName("fk_pt");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_doc");

            entity.ToTable("Doctor");

            entity.Property(e => e.Age)
                .HasColumnType("datetime")
                .HasColumnName("age");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("dob");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("specialization");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_pt");

            entity.ToTable("patient");

            entity.Property(e => e.Age)
                .HasColumnType("datetime")
                .HasColumnName("age");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("dob");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
