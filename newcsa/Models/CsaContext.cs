using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace newcsa.Models;

public partial class CsaContext : DbContext
{
    public CsaContext()
    {
    }

    public CsaContext(DbContextOptions<CsaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Meassage> Meassages { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=placements;uid=sa;pwd=Root123$;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meassage>(entity =>
        {
            entity.HasKey(e => e.MsgId).HasName("PK__meassage__9CA9728D7CE642FC");

            entity.ToTable("meassage");

            entity.Property(e => e.MsgId).HasColumnName("msg_id");
            entity.Property(e => e.MsgData)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Msg_Data");
            entity.Property(e => e.StdId).HasColumnName("std_id");

            entity.HasOne(d => d.Std).WithMany(p => p.Meassages)
                .HasForeignKey(d => d.StdId)
                .HasConstraintName("FK__meassage__std_id__398D8EEE");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StdId).HasName("PK__student__0B0245BA35A63A60");

            entity.ToTable("student");

            entity.Property(e => e.StdId)
                .ValueGeneratedNever()
                .HasColumnName("std_id");
            entity.Property(e => e.Branch)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("branch");
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.YOP).HasColumnName("y_o_p");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
