using Bookworm_Society_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookworm_Society_API.Data
{
    public class Bookworm_SocietyDbContext : DbContext

    {
        public DbSet<VotingSession> VotingSessions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }
        public DbSet<Book> Books { get; set; }

        public Bookworm_SocietyDbContext(DbContextOptions<Bookworm_SocietyDbContext> context) : base(context) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<VotingSession>().HasData(VotingSessionData.VotingSessions);

            //  modelBuilder.Entity<User>().HasData(UserData.Users);

            //  modelBuilder.Entity<Review>().HasData(ReviewData.Reviews);

            // modelBuilder.Entity<Post>().HasData(PostData.Posts);

            //  modelBuilder.Entity<Comment>().HasData(CommentData.Comments);

            // modelBuilder.Entity<BookClub>().HasData(BookClubData.BookClubs);

            // modelBuilder.Entity<Book>().HasData(BookData.Books);

        }
    }
}
