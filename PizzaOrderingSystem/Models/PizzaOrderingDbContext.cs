using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PizzaOrderingSystem.Models;

public partial class PizzaOrderingDbContext : DbContext
{
    public PizzaOrderingDbContext()
    {
    }

    public PizzaOrderingDbContext(DbContextOptions<PizzaOrderingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Pizza> Pizzas { get; set; }

    public virtual DbSet<Topping> Toppings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.61.18.20;Initial Catalog=PizzaOrderingDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4884B4963DE");

            entity.HasIndex(e => e.UserName, "UQ__Admins__C9F284560A89AB23").IsUnique();

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B842362778");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534E6889925").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .HasColumnName("LName");
            entity.Property(e => e.PassWord).HasMaxLength(20);
            entity.Property(e => e.PhoneNo).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF102F2C714");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.UserName, "UQ__Employee__C9F28456DC0AF8F7").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BranchCode).HasMaxLength(20);
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.Fname)
                .HasMaxLength(20)
                .HasColumnName("FName");
            entity.Property(e => e.Lname)
                .HasMaxLength(20)
                .HasColumnName("LName");
            entity.Property(e => e.PassWord).HasMaxLength(100);
            entity.Property(e => e.PhoneNo).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF05DC0E74");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryDateTime).HasColumnType("datetime");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.OrderStatus).HasMaxLength(50);
            entity.Property(e => e.PizzaId).HasColumnName("PizzaID");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            //entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.CustomerId)
            //    .HasConstraintName("FK__Order__CustomerI__3F466844");

            //entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.EmployeeId)
            //    .HasConstraintName("FK__Order__EmployeeI__403A8C7D");

            //entity.HasOne(d => d.Pizza).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.PizzaId)
            //    .HasConstraintName("FK__Order__PizzaID__412EB0B6");
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.HasKey(e => e.PizzaId).HasName("PK__Pizza__0B6012FDF29DD249");

            entity.ToTable("Pizza");

            entity.Property(e => e.PizzaId).HasColumnName("PizzaID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(100)
                .HasColumnName("ImageURL");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Topping>(entity =>
        {
            entity.HasKey(e => e.ToppingId).HasName("PK__Toppings__EE02CCE51FAA7092");

            entity.Property(e => e.ToppingId).HasColumnName("ToppingID");
            entity.Property(e => e.ToppingName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
