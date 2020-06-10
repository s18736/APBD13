﻿// <auto-generated />
using System;
using APBD13.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APBD13.Migrations
{
    [DbContext(typeof(ConfectioneryContext))]
    [Migration("20200607085409_orders-fixed")]
    partial class ordersfixed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APBD13.Entities.Confectionery", b =>
                {
                    b.Property<int>("IdConfecti")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PricePerite")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConfecti");

                    b.ToTable("Confectionery");
                });

            modelBuilder.Entity("APBD13.Entities.ConfectioneryOrder", b =>
                {
                    b.Property<int>("IdConfection")
                        .HasColumnType("int");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdConfection", "IdOrder");

                    b.HasIndex("IdOrder");

                    b.ToTable("ConfectioneryOrder");
                });

            modelBuilder.Entity("APBD13.Entities.Customer", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("APBD13.Entities.Employee", b =>
                {
                    b.Property<int>("IdEmpl")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEmpl");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("APBD13.Entities.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAccepted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int");

                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOrder");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdEmployee");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("APBD13.Entities.ConfectioneryOrder", b =>
                {
                    b.HasOne("APBD13.Entities.Confectionery", "Confectionery")
                        .WithMany("ConfectioneryOrders")
                        .HasForeignKey("IdConfection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD13.Entities.Order", "Order")
                        .WithMany("ConfectioneryOrders")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APBD13.Entities.Order", b =>
                {
                    b.HasOne("APBD13.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APBD13.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
