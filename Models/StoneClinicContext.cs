using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoneClinic.Models
{
    public partial class StoneClinicContext : DbContext
    {
        public StoneClinicContext()
        {
        }

        public StoneClinicContext(DbContextOptions<StoneClinicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminDatum> AdminData { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Doctordetail> Doctordetails { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=StoneClinic;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminDatum>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_uname");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.Dateofvisit).HasColumnType("date");

                entity.Property(e => e.Specialization)
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctordetail>(entity =>
            {
                entity.HasKey(e => e.Doctorid)
                    .HasName("PK_Docid");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VisitingHours)
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Fname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("sex");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
