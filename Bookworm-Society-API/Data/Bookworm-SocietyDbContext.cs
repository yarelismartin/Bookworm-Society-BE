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
            modelBuilder.Entity<BookClub>()
                .HasOne(bc => bc.Book)          
                .WithMany()                     
                .HasForeignKey(bc => bc.BookId) 
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookClub>()
                .HasMany(bc => bc.HaveRead)  
                .WithMany(b => b.BookClubs) 
                .UsingEntity(j => j.ToTable("BookClubsHaveReadBook"));

            modelBuilder.Entity<BookClub>()
                .HasOne(bc => bc.Host)
                .WithMany(u => u.HostedBookClubs)
                .HasForeignKey(bc => bc.HostId);

            modelBuilder.Entity<BookClub>()
                .HasMany(bc => bc.Members)
                .WithMany(u => u.MemberBookClubs)
                .UsingEntity(j => j.ToTable("UserBookClubMembership"));

            modelBuilder.Entity<VotingSession>()
                .HasOne(vs => vs.WinningBook)
                .WithMany() 
                .HasForeignKey(vs => vs.WinningBookId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            modelBuilder.Entity<VotingSession>()
                .HasMany(vs => vs.VotingBooks)
                .WithMany(b => b.VotingSessions)
                .UsingEntity(j => j.ToTable("VotingSessionBooks"));



            modelBuilder.Entity<VotingSession>().HasData(VotingSessionData.VotingSessions);

            modelBuilder.Entity<User>().HasData(UserData.Users);

            modelBuilder.Entity<Review>().HasData(ReviewData.Reviews);

            modelBuilder.Entity<Post>().HasData(PostData.Posts);

            modelBuilder.Entity<Comment>().HasData(CommentData.Comments);

            modelBuilder.Entity<BookClub>().HasData(BookClubData.BookClubs);

            modelBuilder.Entity<Book>().HasData(BookData.Books);

        }
    }
}
