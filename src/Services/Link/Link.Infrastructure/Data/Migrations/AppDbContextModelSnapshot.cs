﻿// <auto-generated />
using System;
using Link.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Link.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Link.Core.Entities.AliasCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Link.Core.Entities.AliasLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("AliasUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(max)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<byte>("Favorite")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasColumnType("TINYINT")
                        .HasDefaultValue((byte)0);

                    b.Property<string>("OriginalUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Links", (string)null);
                });

            modelBuilder.Entity("Link.Core.Entities.AliasLink", b =>
                {
                    b.HasOne("Link.Core.Entities.AliasCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
