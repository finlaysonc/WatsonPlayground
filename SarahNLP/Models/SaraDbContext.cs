using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace SarahNLP.Models
{
    public class SaraDbContext : DbContext
    {
        public SaraDbContext()
        {
        }

        public SaraDbContext(DbContextOptions<SaraDbContext> options)
            : base(options)
        {
        }

        private static readonly string SqlConnection = ConfigurationManager.AppSettings["ConnectionString"];

        /// <summary>
        /// The message types are modeled as Table Per Hierarchy w/ a concrete base class (Message)
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        public DbSet<SmsThread> SmsThreads { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }

        public DbSet<ContentMessage> ContentMessages { get; set; }
        public DbSet<ToneScore> ToneScores { get; set; }


        //for Migrations
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(SqlConnection);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(b => b.Created).HasDefaultValueSql("getutcdate()");
        }


        public static SaraDbContext CreateContextToLocalDb()
        {
            Console.WriteLine(SqlConnection);
            var options = new DbContextOptionsBuilder<SaraDbContext>()
                .UseSqlServer(SqlConnection)
                .Options;
            return new SaraDbContext(options);
        }

        public void SeedData()
        {
            var message = new ContentMessage()
            {
                ContentText = "Skiing is a fun way to active in the winter months.  Growing up in Boston, we attempted to ski - but it was more like ice skating. When I moved to Montana, I learned that skiing on real snow is a different sport than what I learned in Boston.  It's a lot more fun."
            };
            ContentMessages.Add(message);


            var thread = new SmsThread();
            thread.SmsMessages.Add(new SmsMessage()
            {
                MessageText = "Hello, I'm having a problem with your product.",
                User = "customer",
            });

            thread.SmsMessages.Add(new SmsMessage()
            {
                MessageText = "OK, let me know what's going on, please.",
                User = "agent",
            });

            thread.SmsMessages.Add(new SmsMessage()
            {
                MessageText = "Well, nothing is working :(.",
                User = "customer",
            });
            thread.SmsMessages.Add(new SmsMessage()
            {
                MessageText = "Sorry to hear that",
                User = "agent",
            });
            SmsThreads.Add(thread);

            SaveChanges();
        }
    }
}