using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entity_Framework_Queries.Entities
{
    public partial class Linq_QueriesContext : DbContext
    {
        public Linq_QueriesContext()
        {
        }

        public Linq_QueriesContext(DbContextOptions<Linq_QueriesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DboAuthor> DboAuthors { get; set; } = null!;
        public virtual DbSet<DboCourse> DboCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<DboAuthor>(entity =>
            {
                entity.ToTable("dbo.Author");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(45);
            });

            modelBuilder.Entity<DboCourse>(entity =>
            {
                entity.ToTable("dbo.Courses");

                entity.HasIndex(e => e.AuthorId, "AuthorId_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(45);

                entity.Property(e => e.FullPrice).HasMaxLength(45);

                entity.Property(e => e.Name).HasMaxLength(45);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.DboCourses)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("AuthorId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
