﻿// <auto-generated />
using System;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ManagementSystem.Migrations
{
    [DbContext(typeof(ManagementContext))]
    partial class ManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ManagementSystem.Models.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ManagementSystem.Models.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Egzoz Gazı Ölçümü"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fren Testi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Far Ayarı"
                        });
                });

            modelBuilder.Entity("ManagementSystem.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Kemal",
                            LastName = "Sen",
                            PasswordHash = new byte[] { 185, 56, 221, 43, 126, 88, 221, 75, 125, 165, 58, 195, 116, 141, 96, 199, 162, 96, 164, 157, 4, 210, 28, 116, 180, 235, 169, 161, 206, 51, 244, 157, 211, 172, 118, 113, 198, 235, 18, 240, 145, 195, 89, 241, 125, 18, 237, 234, 201, 223, 105, 113, 71, 153, 58, 25, 81, 129, 212, 54, 159, 173, 14, 173 },
                            PasswordSalt = new byte[] { 222, 219, 100, 21, 14, 171, 170, 3, 164, 20, 44, 170, 16, 250, 250, 135, 175, 19, 196, 112, 19, 247, 66, 56, 206, 220, 210, 228, 249, 118, 155, 93 },
                            UserName = "kemlsen",
                            UserType = 2
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Ahmet",
                            LastName = "Hassan",
                            PasswordHash = new byte[] { 185, 56, 221, 43, 126, 88, 221, 75, 125, 165, 58, 195, 116, 141, 96, 199, 162, 96, 164, 157, 4, 210, 28, 116, 180, 235, 169, 161, 206, 51, 244, 157, 211, 172, 118, 113, 198, 235, 18, 240, 145, 195, 89, 241, 125, 18, 237, 234, 201, 223, 105, 113, 71, 153, 58, 25, 81, 129, 212, 54, 159, 173, 14, 173 },
                            PasswordSalt = new byte[] { 222, 219, 100, 21, 14, 171, 170, 3, 164, 20, 44, 170, 16, 250, 250, 135, 175, 19, 196, 112, 19, 247, 66, 56, 206, 220, 210, 228, 249, 118, 155, 93 },
                            UserName = "ahassan",
                            UserType = 1
                        });
                });

            modelBuilder.Entity("ManagementSystem.Models.Entities.Appointment", b =>
                {
                    b.HasOne("ManagementSystem.Models.Entities.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManagementSystem.Models.Entities.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ManagementSystem.Models.Entities.Service", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("ManagementSystem.Models.Entities.User", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
