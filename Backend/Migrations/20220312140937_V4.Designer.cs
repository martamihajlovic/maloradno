﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace WebProj.Migrations
{
    [DbContext(typeof(BookLibraryContext))]
    [Migration("20220312140937_V4")]
    partial class V4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int?>("BookCollectionID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("BookCollectionID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("Models.BookCollection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("NumOfBooks")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BookCollection");
                });

            modelBuilder.Entity("Models.BookCollectionSpoj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookCollectionID")
                        .HasColumnType("int");

                    b.Property<int?>("BookID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BookCollectionID");

                    b.HasIndex("BookID");

                    b.ToTable("BookCollectionSpoj");
                });

            modelBuilder.Entity("Models.BookGenreSpoj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookID")
                        .HasColumnType("int");

                    b.Property<int?>("GenreID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("GenreID");

                    b.ToTable("BookGenreSpoj");
                });

            modelBuilder.Entity("Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Models.Book", b =>
                {
                    b.HasOne("Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.BookCollection", null)
                        .WithMany("Books")
                        .HasForeignKey("BookCollectionID");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Models.BookCollectionSpoj", b =>
                {
                    b.HasOne("Models.BookCollection", "BookCollection")
                        .WithMany()
                        .HasForeignKey("BookCollectionID");

                    b.HasOne("Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookID");

                    b.Navigation("Book");

                    b.Navigation("BookCollection");
                });

            modelBuilder.Entity("Models.BookGenreSpoj", b =>
                {
                    b.HasOne("Models.Book", "Book")
                        .WithMany("Genres")
                        .HasForeignKey("BookID");

                    b.HasOne("Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreID");

                    b.Navigation("Book");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Models.Book", b =>
                {
                    b.Navigation("Genres");
                });

            modelBuilder.Entity("Models.BookCollection", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Models.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
