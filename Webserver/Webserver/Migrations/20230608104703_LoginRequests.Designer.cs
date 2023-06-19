﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Webserver.Context;

#nullable disable

namespace Webserver.Migrations
{
    [DbContext(typeof(PollDbContext))]
    [Migration("20230608104703_LoginRequests")]
    partial class LoginRequests
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("LoginRequest", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("LoginId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginId");

                    b.ToTable("LoginRequests");
                });

            modelBuilder.Entity("Webserver.Model.Answered", b =>
                {
                    b.Property<int>("AnsweredID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("AnsweredID"));

                    b.Property<int>("SurveyID")
                        .HasColumnType("integer");

                    b.Property<int[]>("UserID")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("AnsweredID");

                    b.HasIndex("SurveyID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Webserver.Model.Poll", b =>
                {
                    b.Property<int>("PollID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("PollID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("PollID");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("Webserver.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("UserID"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PollID")
                        .HasColumnType("integer");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.HasIndex("PollID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Webserver.Model.Answered", b =>
                {
                    b.HasOne("Webserver.Model.Poll", "Poll")
                        .WithMany()
                        .HasForeignKey("SurveyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("Webserver.Model.User", b =>
                {
                    b.HasOne("Webserver.Model.Poll", null)
                        .WithMany("Voters")
                        .HasForeignKey("PollID");
                });

            modelBuilder.Entity("Webserver.Model.Poll", b =>
                {
                    b.Navigation("Voters");
                });
#pragma warning restore 612, 618
        }
    }
}