﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskAngular.Auth.api.DbContextApp;

namespace TaskAngular.Auth.api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Task4Core.Models.Collection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirsList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstField")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemCount")
                        .HasColumnType("int");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("SecondFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondFiled")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdFieldName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdFiled")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdList")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Task4Core.Models.Item", b =>
                {
                    b.Property<int>("IDItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentsCount")
                        .HasColumnType("int");

                    b.Property<bool>("FirstField_Bool")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FirstField_Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("FirstField_Int")
                        .HasColumnType("int");

                    b.Property<string>("FirstField_String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCollection")
                        .HasColumnType("int");

                    b.Property<string>("Likes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LikesCount")
                        .HasColumnType("int");

                    b.Property<string>("NameItem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SecondField_Bool")
                        .HasColumnType("bit");

                    b.Property<DateTime>("SecondField_Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("SecondField_Int")
                        .HasColumnType("int");

                    b.Property<string>("SecondField_String")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ThirdField_Bool")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ThirdField_Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ThirdField_Int")
                        .HasColumnType("int");

                    b.Property<string>("ThirdField_String")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDItem");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TaskAngular.Auth.api.Models.Account", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}