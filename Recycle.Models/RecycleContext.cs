﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Recycle.Models
{
    public partial class RecycleContext : DbContext
    {
        public RecycleContext()
        {
        }

        public RecycleContext(DbContextOptions<RecycleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<GarbageCollectionPoint> GarbageCollectionPoints { get; set; }
        public virtual DbSet<GarbageTypeSet> GarbageTypeSets { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<TypeOfGarbage> TypeOfGarbages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLExpress;Database=Recycle;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Middlename).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Role");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Client");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(2550);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GarbageCollectionPoint>(entity =>
            {
                entity.ToTable("GarbageCollectionPoint");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Building).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.HasOne(d => d.IdCompanyNavigation)
                    .WithMany(p => p.GarbageCollectionPoints)
                    .HasForeignKey(d => d.IdCompany)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GarbageCollectionPoint_Company");
            });

            modelBuilder.Entity<GarbageTypeSet>(entity =>
            {
                entity.HasKey(e => new { e.IdGarbageCollectionPoint, e.IdTypeOfGarbage });

                entity.ToTable("GarbageTypeSet");

                entity.HasOne(d => d.IdGarbageCollectionPointNavigation)
                    .WithMany(p => p.GarbageTypeSets)
                    .HasForeignKey(d => d.IdGarbageCollectionPoint)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GarbageTypeSet_GarbageCollectionPoint");

                entity.HasOne(d => d.IdTypeOfGarbageNavigation)
                    .WithMany(p => p.GarbageTypeSets)
                    .HasForeignKey(d => d.IdTypeOfGarbage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GarbageTypeSet_TypeOfGarbage");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<TypeOfGarbage>(entity =>
            {
                entity.ToTable("TypeOfGarbage");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}