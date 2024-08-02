﻿// <auto-generated />
using System;
using System.Diagnostics.CodeAnalysis;
using HealthMed.AgendaConsulta.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthMed.AgendaConsulta.Infra.Migrations
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240802182051_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HealthMed.AgendaConsulta.Domain.Entities.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fim")
                        .HasColumnType("DATETIME2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("DATETIME2");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consulta", (string)null);
                });

            modelBuilder.Entity("HealthMed.AgendaConsulta.Domain.Entities.Medico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NumeroCRM")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)");

                    b.HasKey("Id");

                    b.ToTable("Medico", (string)null);
                });

            modelBuilder.Entity("HealthMed.AgendaConsulta.Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("Id");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("HealthMed.AgendaConsulta.Domain.Entities.Consulta", b =>
                {
                    b.HasOne("HealthMed.AgendaConsulta.Domain.Entities.Medico", null)
                        .WithMany("Consultas")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HealthMed.AgendaConsulta.Domain.Entities.Paciente", null)
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HealthMed.AgendaConsulta.Domain.Entities.Medico", b =>
                {
                    b.OwnsOne("HealthMed.AgendaConsulta.Domain.Entities.ValueObject.Credencial", "Credencial", b1 =>
                        {
                            b1.Property<int>("MedicoId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)");

                            b1.Property<string>("Senha")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)");

                            b1.HasKey("MedicoId");

                            b1.ToTable("MedicoCredencial", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MedicoId");
                        });

                    b.OwnsOne("HealthMed.AgendaConsulta.Domain.Entities.ValueObject.HorarioExpediente", "HorarioExpediente", b1 =>
                        {
                            b1.Property<int>("MedicoId")
                                .HasColumnType("int");

                            b1.Property<TimeOnly>("FimDomingo")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("FimQuarta")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("FimQuinta")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("FimSabado")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("FimSegunda")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("FimSexta")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("FimTerca")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("InicioDomingo")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("InicioQuarta")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("InicioQuinta")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("InicioSabado")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("InicioSegunda")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("InicioSexta")
                                .HasColumnType("TIME");

                            b1.Property<TimeOnly>("InicioTerca")
                                .HasColumnType("TIME");

                            b1.Property<bool>("TrabalhaDomingo")
                                .HasColumnType("BIT");

                            b1.Property<bool>("TrabalhaQuarta")
                                .HasColumnType("BIT");

                            b1.Property<bool>("TrabalhaQuinta")
                                .HasColumnType("BIT");

                            b1.Property<bool>("TrabalhaSabado")
                                .HasColumnType("BIT");

                            b1.Property<bool>("TrabalhaSegunda")
                                .HasColumnType("BIT");

                            b1.Property<bool>("TrabalhaSexta")
                                .HasColumnType("BIT");

                            b1.Property<bool>("TrabalhaTerca")
                                .HasColumnType("BIT");

                            b1.HasKey("MedicoId");

                            b1.ToTable("MedicoHorarioExpediente", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MedicoId");
                        });

                    b.Navigation("Credencial")
                        .IsRequired();

                    b.Navigation("HorarioExpediente");
                });

            modelBuilder.Entity("HealthMed.AgendaConsulta.Domain.Entities.Paciente", b =>
                {
                    b.OwnsOne("HealthMed.AgendaConsulta.Domain.Entities.ValueObject.Credencial", "Credencial", b1 =>
                        {
                            b1.Property<int>("PacienteId")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)");

                            b1.Property<string>("Senha")
                                .IsRequired()
                                .HasColumnType("VARCHAR(100)");

                            b1.HasKey("PacienteId");

                            b1.ToTable("PacienteCredencial", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("PacienteId");
                        });

                    b.Navigation("Credencial")
                        .IsRequired();
                });

            modelBuilder.Entity("HealthMed.AgendaConsulta.Domain.Entities.Medico", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("HealthMed.AgendaConsulta.Domain.Entities.Paciente", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
