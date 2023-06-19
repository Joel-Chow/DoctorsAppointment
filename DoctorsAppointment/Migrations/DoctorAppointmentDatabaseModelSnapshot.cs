﻿// <auto-generated />
using System;
using DoctorsAppointment.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DoctorsAppointment.Migrations
{
    [DbContext(typeof(DoctorAppointmentDatabase))]
    partial class DoctorAppointmentDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Doctors_Appointment_Db")
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DoctorsAppointment.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PaitentId")
                        .HasColumnType("uuid");

                    b.Property<string>("PaitentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SlotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Appointments", "Doctors_Appointment_Db");
                });

            modelBuilder.Entity("DoctorsAppointment.Entities.DoctorAvailability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<string>("DoctorName")
                        .HasColumnType("text");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("DoctorAvailabilities", "Doctors_Appointment_Db");
                });
#pragma warning restore 612, 618
        }
    }
}
