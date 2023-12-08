﻿// <auto-generated />
using System;
using InstallmentPolicy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InstallmentPolicy.Migrations
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

            modelBuilder.Entity("InstallmentPolicy.Models.Installment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created_On")
                        .HasColumnType("datetime2");

                    b.Property<int>("Installment_No")
                        .HasColumnType("int");

                    b.Property<int>("PID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Paydate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Policy_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Premium")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PID");

                    b.ToTable("InstallmentPolicy");
                });

            modelBuilder.Entity("Policy.Models.MasterPolicy", b =>
                {
                    b.Property<int>("PID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PID"));

                    b.Property<string>("Created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Customer_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_Of_Birth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id_Card")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plan_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Policy_Id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Premium")
                        .HasColumnType("real");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Updated_By")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PID");

                    b.ToTable("MasterPolicy");
                });

            modelBuilder.Entity("InstallmentPolicy.Models.Installment", b =>
                {
                    b.HasOne("Policy.Models.MasterPolicy", "MasterPolicy")
                        .WithMany("Installments")
                        .HasForeignKey("PID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterPolicy");
                });

            modelBuilder.Entity("Policy.Models.MasterPolicy", b =>
                {
                    b.Navigation("Installments");
                });
#pragma warning restore 612, 618
        }
    }
}