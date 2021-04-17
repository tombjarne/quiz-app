using Lifekeys.Models.Quiz;
using Lifekeys.Models.Quiz.Questions;
using Lifekeys.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Lifekeys.Contexts
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions<QuizContext> context) : base(context)
        { }

        public QuizContext() { }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().ToTable("Quiz");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Solution>().ToTable("Solution");
            modelBuilder.Entity<Answer>().ToTable("Answer");

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired();
                entity.Property(e => e.Title)
                    .IsRequired();

                entity
                    .HasMany(s => s.Questions)
                    .WithOne(i => i.ParentQuiz)
                    .HasForeignKey(i => i.QuizId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired();
                entity.Property(e => e.QuestionText)
                    .IsRequired();
                entity.Property(e => e.Type)
                    .IsRequired();

                entity
                    .HasMany(s => s.Solutions)
                    .WithOne(i => i.Parent)
                    .HasForeignKey(i => i.QuestionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Solution>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired();

                entity
                    .HasMany(s => s.Answers)
                    .WithOne(i => i.ParentSolution)
                    .HasForeignKey(i => i.SolutionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsRequired();

                entity.Property(e => e.Value)
                    .IsRequired();
            });
        }
    }
}
