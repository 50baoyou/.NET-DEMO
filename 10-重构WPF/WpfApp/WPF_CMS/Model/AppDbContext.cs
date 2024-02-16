using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WPF_CMS.Model;

// Scaffold-DbContext 是 Entity Framework Core 中的一个命令
// 用于根据现有数据库生成实体类型和上下文类

// 数据库上下文类
/**
 * 定义：
 *      DbContext 是 Entity Framework Core 中用于与数据库进行交互的上下文类。
 *      它表示应用程序与数据库之间的会话，充当对象关系映射 (ORM) 的一部分，负责将对象模型映射到数据库模型。
 * 
 * 作用：
 *      1.数据上下文：提供对数据的访问，通过 DbContext，可以执行查询、添加、更新和删除操作，与数据库进行交互。
 *      2.对象跟踪：DbContext 通过跟踪对实体对象的更改，允许在内存中操作对象，然后以一致的方式将这些更改保存到数据库。
 *      3.配置映射：允许配置如何将实体类映射到数据库表。
 */
public partial class AppDbContext : DbContext
{
    // 数据库连接字符串，从配置文件中获取
    private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Demo"].ConnectionString;

    // 默认构造函数，一般不直接使用
    public AppDbContext()
    {
    }

    // 构造函数，接受 DbContextOptions<AppDbContext> 参数，用于配置数据库连接等选项
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // DbSet 属性，表示数据库中的表，可以通过这些属性执行数据库操作
    public virtual DbSet<Appointment> Appointments { get; set; }

    // DbSet 是一种泛型集合，它表示数据库上下文中的实体集。
    public virtual DbSet<Customer> Customers { get; set; }

    // 在此方法中配置数据库连接，使用 SQL Server 数据库
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }

    // 在此方法中配置实体类型的映射关系和数据库表的约束等
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 配置 Appointment 实体的映射和约束
        modelBuilder.Entity<Appointment>(entity =>
        {
            // 主键配置
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC07254FF936");

            // 时间字段的数据类型配置
            entity.Property(e => e.Time).HasColumnType("datetime");

            // 配置 Appointment 和 Customer 之间的外键关系
            entity.HasOne(d => d.Customer).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CustomerId)
                //.OnDelete(DeleteBehavior.Cascade) 在删除父实体时级联删除所有相关的子实体
                .HasConstraintName("FK_Appointments_Customer");
        });

        // 配置 Customer 实体的映射和约束
        modelBuilder.Entity<Customer>(entity =>
        {
            // 主键配置
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC072210D6B6");

            // 表名配置
            entity.ToTable("Customer");

            // 各属性的长度和固定长度配置
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.IdNumber)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        // 额外的模型配置，可以在此方法中添加其他的配置
        OnModelCreatingPartial(modelBuilder);
    }

    // 自定义模型配置，可在派生类中实现，定义实体和数据库的映射
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
