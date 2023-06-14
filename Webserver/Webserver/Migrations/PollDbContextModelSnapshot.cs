﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Webserver.Context;

#nullable disable

namespace Webserver.Migrations
{
    [DbContext(typeof(PollDbContext))]
    partial class PollDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("Webserver.Model.Answers", b =>
                {
                    b.Property<int>("AnsweredID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("AnsweredID"));

                    b.Property<int>("AnswerType")
                        .HasColumnType("integer");

                    b.Property<int>("SurveyID")
                        .HasColumnType("integer");

                    b.Property<int[]>("UserID")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("AnsweredID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Webserver.Model.IntAnswer", b =>
                {
                    b.Property<int>("IntAnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("IntAnswerID"));

                    b.Property<int>("AnsweredID")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("IntAnswerID");

                    b.ToTable("intanswers");
                });

            modelBuilder.Entity("Webserver.Model.Poll", b =>
                {
                    b.Property<int>("PollID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("PollID"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

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

            modelBuilder.Entity("Webserver.Model.Question", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("id"));

                    b.Property<string>("description")
                        .HasColumnType("text");

                    b.Property<string>("heading")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("index")
                        .HasColumnType("integer");

                    b.Property<int>("survey_id")
                        .HasColumnType("integer");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Webserver.Model.QuestionsOnPoll", b =>
                {
                    b.Property<int>("QuestionOnPollId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("QuestionOnPollId"));

                    b.Property<int>("PollId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionOnPollId");

                    b.ToTable("questionsOnPolls");
                });

            modelBuilder.Entity("Webserver.Model.TextAnswer", b =>
                {
                    b.Property<int>("TextAnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("TextAnswerID"));

                    b.Property<int>("AnsweredID")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Heading")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<int>("SurveyID")
                        .HasColumnType("integer");

                    b.HasKey("TextAnswerID");

                    b.ToTable("textquestions");
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

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
