﻿// <auto-generated />
using System;
using CHUBBHR.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CHUBBHR.Migrations
{
    [DbContext(typeof(RegistroContext))]
    partial class RegistroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CHUBBHR.Models.Posicion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Posicion1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("posicion");

                    b.HasKey("Id")
                        .HasName("PK__Posicion__3213E83FA225491D");

                    b.ToTable("Posicion", (string)null);
                });

            modelBuilder.Entity("CHUBBHR.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PosicionFk")
                        .HasColumnType("int")
                        .HasColumnName("posicion_fk");

                    b.HasKey("Id")
                        .HasName("PK__Usuarios__3213E83FA1E73461");

                    b.HasIndex("PosicionFk");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CHUBBHR.Models.Usuario", b =>
                {
                    b.HasOne("CHUBBHR.Models.Posicion", "PosicionFkNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("PosicionFk")
                        .HasConstraintName("FK__Usuarios__posici__4E88ABD4");

                    b.Navigation("PosicionFkNavigation");
                });

            modelBuilder.Entity("CHUBBHR.Models.Posicion", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
