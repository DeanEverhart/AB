﻿// <auto-generated />
using System;
using AB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AB.Migrations
{
    [DbContext(typeof(ABContext))]
    [Migration("20230523154201_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AB.Models.A", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("One")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Three")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Two")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("A");
                });

            modelBuilder.Entity("AB.Models.B", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AId")
                        .HasColumnType("int");

                    b.Property<string>("One")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Three")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Two")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AId");

                    b.ToTable("B");
                });

            modelBuilder.Entity("AB.Models.B", b =>
                {
                    b.HasOne("AB.Models.A", "A")
                        .WithMany("B")
                        .HasForeignKey("AId");

                    b.Navigation("A");
                });

            modelBuilder.Entity("AB.Models.A", b =>
                {
                    b.Navigation("B");
                });
#pragma warning restore 612, 618
        }
    }
}
