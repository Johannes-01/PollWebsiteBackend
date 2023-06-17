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


        public DbSet<Answer> Answers { get; set; }

        public DbSet<QuestionsOnPoll> QuestionsOnPolls { get; set; }

        public DbSet<Textanswer> Textanswer { get; set; }

        public DbSet<IntAnswer> IntAnswer { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
