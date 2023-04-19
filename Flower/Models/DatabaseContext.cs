using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Flower.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC072AD114B5");

            entity.ToTable("Account");

            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasMany(d => d.Roles).WithMany(p => p.Accounts)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AccountRo__RoleI__59063A47"),
                    l => l.HasOne<Account>().WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__AccountRo__Accou__5812160E"),
                    j =>
                    {
                        j.HasKey("AccountId", "RoleId").HasName("PK__AccountR__8C320947F266C158");
                        j.ToTable("AccountRole");
                    });
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07753CE8E8");

            entity.ToTable("Category");

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3214EC077215BF76");

            entity.ToTable("Invoice");

            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Payment)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__Account__403A8C7D");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ProductId }).HasName("PK__InvoiceD__1CD666D98D9916BB");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceDe__Invoi__5070F446");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceDe__Produ__5165187F");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07FF2037B5");

            entity.ToTable("Product");

            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Categor__4CA06362");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC07AE18CCD7");

            entity.ToTable("Role");

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
