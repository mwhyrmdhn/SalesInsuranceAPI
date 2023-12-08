﻿// <auto-generated />
using System;
using Master.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Master.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Master.Models.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MID")
                        .HasColumnType("int");

                    b.Property<int>("ResponseCode")
                        .HasColumnType("int");

                    b.Property<string>("ResponseDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MID");

                    b.ToTable("ActivityLog");
                });

            modelBuilder.Entity("Master.Models.MasterUser", b =>
                {
                    b.Property<int>("MID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MID"));

                    b.Property<string>("Created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_On")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Updated_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Level")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MID");

                    b.ToTable("MUser");
                });

            modelBuilder.Entity("Master.Models.ActivityLog", b =>
                {
                    b.HasOne("Master.Models.MasterUser", "MasterUser")
                        .WithMany("ActivityLog")
                        .HasForeignKey("MID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterUser");
                });

            modelBuilder.Entity("Master.Models.MasterUser", b =>
                {
                    b.Navigation("ActivityLog");
                });
#pragma warning restore 612, 618
        }
    }
}
