using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model;

namespace Data.Contexts
{
    public partial class mauro_sqlContext : DbContext
    {
        public mauro_sqlContext()
        {
        }

        public mauro_sqlContext(DbContextOptions<mauro_sqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountActivaty> AccountActivaty { get; set; }
        public virtual DbSet<Activaty> Activaty { get; set; }
        public virtual DbSet<Credits> Credits { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Studenthouse> Studenthouse { get; set; }
        public virtual DbSet<VwActiveStudenthouseAccount> VwActiveStudenthouseAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:maurosqlserver.database.windows.net,1433;Initial Catalog=mauro_sql;Persist Security Info=False;User ID=mauro;Password=Geheim123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Lastname).IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username).IsRequired();
            });

            modelBuilder.Entity<AccountActivaty>(entity =>
            {
                entity.ToTable("Account_Activaty");

                entity.Property(e => e.In).HasColumnType("date");

                entity.Property(e => e.Out).HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountActivaty)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account_A__Accou__2EA5EC27");

                entity.HasOne(d => d.Studenthouse)
                    .WithMany(p => p.AccountActivaty)
                    .HasForeignKey(d => d.StudenthouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Account_A__Stude__2F9A1060");
            });

            modelBuilder.Entity<Activaty>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Activaty)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activaty__Accoun__22401542");

                entity.HasOne(d => d.Studenthouse)
                    .WithMany(p => p.Activaty)
                    .HasForeignKey(d => d.StudenthouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activaty__Studen__2334397B");
            });

            modelBuilder.Entity<Credits>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.StudenthouseId })
                    .HasName("PK__Credits__BBDA99D792B96279");

                entity.HasIndex(e => new { e.AccountId, e.StudenthouseId })
                    .HasName("UQ__Credits__BBDA99D6BC0A2E90")
                    .IsUnique();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Credits)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Credits__Account__2704CA5F");

                entity.HasOne(d => d.Studenthouse)
                    .WithMany(p => p.Credits)
                    .HasForeignKey(d => d.StudenthouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Credits__Student__27F8EE98");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnName("Question")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Studenthouse)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.StudenthouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Question__Studen__1F63A897");
            });

            modelBuilder.Entity<Studenthouse>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<VwActiveStudenthouseAccount>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwActiveStudenthouseAccount");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
