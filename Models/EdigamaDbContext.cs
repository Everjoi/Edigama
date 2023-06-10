using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Edigama.Models;

public partial class EdigamaDbContext : DbContext
{
    public EdigamaDbContext()
    {
    }

    public EdigamaDbContext(DbContextOptions<EdigamaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EdigamaDb;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC073FF7CA73");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534355557AE").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
