﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SudokuSolver.Data;

#nullable disable

namespace SudokuSolver.Migrations
{
    [DbContext(typeof(SudokuSolverContext))]
    partial class SudokuSolverContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SudokuSolver.Models.SudokuModel", b =>
                {
                    b.Property<int>("PuzzleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PuzzleId"));

                    b.Property<DateTime?>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostUserId")
                        .HasColumnType("int");

                    b.Property<string>("Puzzle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PuzzleId");

                    b.HasIndex("PostUserId");

                    b.ToTable("Puzzles");
                });

            modelBuilder.Entity("SudokuSolver.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SudokuSolver.Models.SudokuModel", b =>
                {
                    b.HasOne("SudokuSolver.Models.User", "PostUser")
                        .WithMany("PuzzlesSolved")
                        .HasForeignKey("PostUserId");

                    b.Navigation("PostUser");
                });

            modelBuilder.Entity("SudokuSolver.Models.User", b =>
                {
                    b.Navigation("PuzzlesSolved");
                });
#pragma warning restore 612, 618
        }
    }
}