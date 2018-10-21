using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SandboxApp.Model.Domain
{
    public partial class PostgresContext : DbContext
    {
        public PostgresContext()
        {
        }

        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestSubTable> TestSubTable { get; set; }
        public virtual DbSet<TestTable> TestTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack");

            modelBuilder.Entity<TestSubTable>(entity =>
            {
                entity.HasKey(e => e.Testsubid);

                entity.ToTable("test_sub_table", "sandbox");

                entity.Property(e => e.Testsubid)
                    .HasColumnName("testsubid")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Testid).HasColumnName("testid");

                entity.Property(e => e.Testsubdate)
                    .HasColumnName("testsubdate")
                    .HasColumnType("date");

                entity.Property(e => e.Testsubdescription).HasColumnName("testsubdescription");

                entity.HasOne(d => d.Test)
                    .WithMany(p => p.TestSubTable)
                    .HasForeignKey(d => d.Testid)
                    .HasConstraintName("test_sub_table_testid_fkey");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.HasKey(e => e.Testid);

                entity.ToTable("test_table", "sandbox");

                entity.Property(e => e.Testid)
                    .HasColumnName("testid")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Testdate)
                    .HasColumnName("testdate")
                    .HasColumnType("date");

                entity.Property(e => e.Testdecimal)
                    .HasColumnName("testdecimal")
                    .HasColumnType("numeric(10,2)");

                entity.Property(e => e.Testdescription).HasColumnName("testdescription");

                entity.Property(e => e.Testnumber).HasColumnName("testnumber");
            });
        }
    }
}
