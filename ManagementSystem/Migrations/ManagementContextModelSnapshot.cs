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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            FirstName = "Dincer",
                            LastName = "Teknoloji",
                            PasswordHash = new byte[] { 11, 54, 62, 240, 159, 165, 184, 150, 168, 114, 83, 20, 142, 97, 71, 182, 100, 171, 169, 16, 205, 16, 7, 251, 84, 237, 243, 76, 117, 235, 46, 226, 17, 88, 82, 212, 112, 64, 155, 240, 63, 69, 146, 217, 32, 194, 35, 2, 119, 182, 34, 135, 143, 33, 10, 184, 24, 62, 131, 182, 235, 177, 81, 99 },
                            PasswordSalt = new byte[] { 132, 225, 102, 92, 223, 144, 89, 34, 201, 70, 254, 48, 247, 32, 115, 109, 186, 132, 232, 94, 124, 40, 202, 53, 197, 146, 231, 211, 126, 72, 179, 96, 30, 85, 82, 7, 42, 213, 204, 142, 121, 132, 24, 42, 127, 152, 131, 128, 53, 168, 88, 153, 13, 116, 182, 8, 69, 249, 181, 197, 197, 223, 187, 194, 189, 122, 178, 12, 124, 250, 166, 210, 204, 54, 100, 124, 39, 59, 145, 189, 119, 233, 8, 93, 113, 189, 161, 67, 185, 203, 57, 29, 136, 91, 197, 234, 14, 199, 17, 192, 243, 157, 71, 186, 238, 174, 237, 63, 85, 78, 62, 67, 177, 249, 107, 12, 121, 186, 56, 203, 177, 166, 230, 1, 163, 75, 223, 80 },
                            UserName = "admindincer",
                            UserType = 2
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Kemal",
                            LastName = "Sen",
                            PasswordHash = new byte[] { 11, 54, 62, 240, 159, 165, 184, 150, 168, 114, 83, 20, 142, 97, 71, 182, 100, 171, 169, 16, 205, 16, 7, 251, 84, 237, 243, 76, 117, 235, 46, 226, 17, 88, 82, 212, 112, 64, 155, 240, 63, 69, 146, 217, 32, 194, 35, 2, 119, 182, 34, 135, 143, 33, 10, 184, 24, 62, 131, 182, 235, 177, 81, 99 },
                            PasswordSalt = new byte[] { 132, 225, 102, 92, 223, 144, 89, 34, 201, 70, 254, 48, 247, 32, 115, 109, 186, 132, 232, 94, 124, 40, 202, 53, 197, 146, 231, 211, 126, 72, 179, 96, 30, 85, 82, 7, 42, 213, 204, 142, 121, 132, 24, 42, 127, 152, 131, 128, 53, 168, 88, 153, 13, 116, 182, 8, 69, 249, 181, 197, 197, 223, 187, 194, 189, 122, 178, 12, 124, 250, 166, 210, 204, 54, 100, 124, 39, 59, 145, 189, 119, 233, 8, 93, 113, 189, 161, 67, 185, 203, 57, 29, 136, 91, 197, 234, 14, 199, 17, 192, 243, 157, 71, 186, 238, 174, 237, 63, 85, 78, 62, 67, 177, 249, 107, 12, 121, 186, 56, 203, 177, 166, 230, 1, 163, 75, 223, 80 },
                            UserName = "userkemal",
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
