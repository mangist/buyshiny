using Microsoft.EntityFrameworkCore;
using System;

namespace JH.BuyShiny.Database
{
    public class BuyShinyContext : DbContext
    {
        public DbSet<Timezone> Timezones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
        public DbSet<UserVerify> UserVerifies { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostRead> PostReads { get; set; }
        public DbSet<PostVote> PostVotes { get; set; }

        public DbSet<Reply> Replies { get; set; }
        public DbSet<ReplyRead> ReplyReads { get; set; }

        public BuyShinyContext(DbContextOptions<BuyShinyContext> options)
            : base(options)
                { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostRead>().HasKey(e => new { e.PostId, e.UserId });
            modelBuilder.Entity<PostVote>().HasKey(e => new { e.PostId, e.UserId });

            modelBuilder.Entity<ReplyRead>().HasKey(e => new { e.ReplyId, e.UserId });
            modelBuilder.Entity<ReplyVote>().HasKey(e => new { e.ReplyId, e.UserId });

            modelBuilder.Entity<UserRole>().HasKey(e => new { e.UserId, e.RoleId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
