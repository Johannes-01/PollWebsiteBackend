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
        }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Answered> Answers { get; set;}

        public DbSet<LoginRequest> LoginRequests { get; set; }


    }
}
