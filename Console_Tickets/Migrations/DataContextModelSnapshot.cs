﻿// <auto-generated />
using System;
using Console_Tickets.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Console_Tickets.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Console_Tickets.Models.Entitites.CommentEntity", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("TicketId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Console_Tickets.Models.Entitites.CustomerEntity", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("char(13)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Console_Tickets.Models.Entitites.TicketEntity", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TicketId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Console_Tickets.Models.Entitites.CommentEntity", b =>
                {
                    b.HasOne("Console_Tickets.Models.Entitites.TicketEntity", "Ticket")
                        .WithMany("Comments")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Console_Tickets.Models.Entitites.TicketEntity", b =>
                {
                    b.HasOne("Console_Tickets.Models.Entitites.CustomerEntity", "Customer")
                        .WithMany("Tickets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Console_Tickets.Models.Entitites.CustomerEntity", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Console_Tickets.Models.Entitites.TicketEntity", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
