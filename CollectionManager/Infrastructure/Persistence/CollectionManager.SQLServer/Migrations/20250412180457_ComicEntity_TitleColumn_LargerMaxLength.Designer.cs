﻿// <auto-generated />
using System;
using CollectionManager.SQLServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollectionManager.SQLServer.Migrations
{
    [DbContext(typeof(CollectionManagerDbContext))]
    [Migration("20250412180457_ComicEntity_TitleColumn_LargerMaxLength")]
    partial class ComicEntity_TitleColumn_LargerMaxLength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CollectionManager.SQLServer.Entities.Collectibles.ComicEntity", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"));

                    b.Property<bool>("IsOwned")
                        .HasColumnType("bit");

                    b.Property<string>("Issues")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly>("Published")
                        .HasColumnType("date");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("Volume")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Comics");
                });
#pragma warning restore 612, 618
        }
    }
}
