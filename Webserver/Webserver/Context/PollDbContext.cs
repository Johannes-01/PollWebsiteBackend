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

        public DbSet<Poll> Poll { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Answer> Answer { get; set; }

        public DbSet<QuestionsOnPoll> QuestionOnPoll { get; set; }

        public DbSet<Question> Question { get; set; }
    }
}
