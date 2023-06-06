using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CHUBBHR.Models;

public partial class RegistroContext : DbContext
{
    public RegistroContext()
    {
    }

    public RegistroContext(DbContextOptions<RegistroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Posicion> Posicions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("server=LAPTOP-4IKMKHGF\\SQLEXPRESS; database=REGISTRO; integrated security=true; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Posicion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posicion__3213E83FA225491D");

            entity.ToTable("Posicion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Posicion1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("posicion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3213E83FA1E73461");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PosicionFk).HasColumnName("posicion_fk");

            entity.HasOne(d => d.PosicionFkNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PosicionFk)
                .HasConstraintName("FK__Usuarios__posici__4E88ABD4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
