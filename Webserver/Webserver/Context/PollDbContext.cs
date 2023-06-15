using Microsoft.EntityFrameworkCore;
using Webserver.Model;

namespace Webserver.Context
{
    public class PollDbContext : DbContext
    {

        public PollDbContext(DbContextOptions<PollDbContext> option)
            : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            //To Do.
            //modelBuilder.Entity<IntAnswer>().HasOne(i => i.AnswerID).WithOne().HasForeignKey();
        }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answers> Answers { get; set; }

        public DbSet<QuestionsOnPoll> questionsOnPolls { get; set; }

        public DbSet<IntAnswer> intanswers { get; set; }

        public DbSet<TextAnswer> textquestions { get; set; }
    }
}
