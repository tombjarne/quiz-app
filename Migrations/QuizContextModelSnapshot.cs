// <auto-generated />
using System;
using Lifekeys.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lifekeys.Migrations
{
    [DbContext(typeof(QuizContext))]
    partial class QuizContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Lifekeys.Models.Quiz.Answer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("QuestionId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("SolutionId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SolutionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Questions.Question", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<bool?>("IsTrue")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("QuizId")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Quiz", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Solution", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("QuestionId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Solution");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Answer", b =>
                {
                    b.HasOne("Lifekeys.Models.Quiz.Questions.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");

                    b.HasOne("Lifekeys.Models.Quiz.Solution", "ParentSolution")
                        .WithMany("Answers")
                        .HasForeignKey("SolutionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentSolution");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Questions.Question", b =>
                {
                    b.HasOne("Lifekeys.Models.Quiz.Quiz", "ParentQuiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ParentQuiz");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Solution", b =>
                {
                    b.HasOne("Lifekeys.Models.Quiz.Questions.Question", "Parent")
                        .WithMany("Solutions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Questions.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Lifekeys.Models.Quiz.Solution", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
