﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using app.Entidades;

#nullable disable

namespace app.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmpresaUsuario", b =>
                {
                    b.Property<string>("EmpresasCnpj")
                        .HasColumnType("character varying(14)")
                        .HasColumnName("CnpjEmpresa");

                    b.Property<int>("UsuariosId")
                        .HasColumnType("integer")
                        .HasColumnName("IdUsuario");

                    b.HasKey("EmpresasCnpj", "UsuariosId");

                    b.HasIndex("UsuariosId");

                    b.ToTable("UsuarioEmpresa", (string)null);
                });

            modelBuilder.Entity("app.Entidades.Empresa", b =>
                {
                    b.Property<string>("Cnpj")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int[]>("UFs")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("Cnpj");

                    b.HasIndex("Cnpj")
                        .IsUnique();

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("app.Entidades.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Uf")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Municipio");
                });

            modelBuilder.Entity("app.Entidades.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Tipo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Perfis");
                });

            modelBuilder.Entity("app.Entidades.PerfilPermissao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PerfilId")
                        .HasColumnType("uuid");

                    b.Property<int>("Permissao")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("PerfilPermissoes");
                });

            modelBuilder.Entity("app.Entidades.RedefinicaoSenha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IdUsuario")
                        .HasColumnType("integer");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("RedefinicaoSenha");
                });

            modelBuilder.Entity("app.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<Guid?>("PerfilId")
                        .HasColumnType("uuid");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("TokenAtualizacao")
                        .HasColumnType("text");

                    b.Property<DateTime?>("TokenAtualizacaoExpiracao")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UfLotacao")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("MunicipioId");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("EmpresaUsuario", b =>
                {
                    b.HasOne("app.Entidades.Empresa", null)
                        .WithMany()
                        .HasForeignKey("EmpresasCnpj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Entidades.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UsuariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("app.Entidades.PerfilPermissao", b =>
                {
                    b.HasOne("app.Entidades.Perfil", "Perfil")
                        .WithMany("PerfilPermissoes")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("app.Entidades.RedefinicaoSenha", b =>
                {
                    b.HasOne("app.Entidades.Usuario", "Usuario")
                        .WithMany("RedefinicaoSenha")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("app.Entidades.Usuario", b =>
                {
                    b.HasOne("app.Entidades.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId");

                    b.HasOne("app.Entidades.Perfil", "Perfil")
                        .WithMany("Usuarios")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Municipio");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("app.Entidades.Perfil", b =>
                {
                    b.Navigation("PerfilPermissoes");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("app.Entidades.Usuario", b =>
                {
                    b.Navigation("RedefinicaoSenha");
                });
#pragma warning restore 612, 618
        }
    }
}
