using System;
using System.Collections.Generic;
using it_comp.Modeks;
using Microsoft.EntityFrameworkCore;

namespace it_comp;

public partial class ItCompanyContext : DbContext
{
    public ItCompanyContext()
    {
    }

    public ItCompanyContext(DbContextOptions<ItCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Proirite> Proirites { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectEmploye> ProjectEmployes { get; set; }

    public virtual DbSet<ProjectType> ProjectTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Modeks.Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=it_company;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PositionName).HasColumnName("position_name");
        });

        modelBuilder.Entity<Proirite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proirites_pkey");

            entity.ToTable("proirites");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PriorityName).HasColumnName("priority_name");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateStart).HasColumnName("date_start");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Meneger).HasColumnName("meneger");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Status).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_projects_status");
        });

        modelBuilder.Entity<ProjectEmploye>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_employes_pkey");

            entity.ToTable("project_employes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Eployee).HasColumnName("eployee");
            entity.Property(e => e.ProjectTypesId).HasColumnName("project_types_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.ProjectTypes).WithMany(p => p.ProjectEmployes)
                .HasForeignKey(d => d.ProjectTypesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_project_members_type");

            entity.HasOne(d => d.Role).WithMany(p => p.ProjectEmployes)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_project_members_role");
        });

        modelBuilder.Entity<ProjectType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("project_types_pkey");

            entity.ToTable("project_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeName).HasColumnName("type_name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName).HasColumnName("role_name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StatusName).HasColumnName("status_name");
        });

        modelBuilder.Entity<Modeks.Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tasks_pkey");

            entity.ToTable("tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfCreate).HasColumnName("date_of_create");
            entity.Property(e => e.DateOfEnd).HasColumnName("date_of_end");
            entity.Property(e => e.Descripton).HasColumnName("descripton");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TaskName).HasColumnName("task_name");

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tasks_priority");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("fk_tasks_project");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tasks_status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Fio).HasColumnName("fio");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PositionId).HasColumnName("position_id");

            entity.HasOne(d => d.Position).WithMany(p => p.Users)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_users_position");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
