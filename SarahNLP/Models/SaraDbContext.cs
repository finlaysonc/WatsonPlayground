using System;
using Microsoft.EntityFrameworkCore;

namespace SarahNLP.Models
{
    public class SaraDbContext : DbContext
    {
        public SaraDbContext(DbContextOptions<SaraDbContext> options)
            : base(options)
        {
        }

        public DbSet<SmsThread> SmsThreads { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }
        public DbSet<ContentMessage> ContentMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(b => b.Craeted).HasDefaultValueSql("getutcdate()");
        }


        public static SaraDbContext CreateDatabaseOfMessages()
        {
            var options = new DbContextOptionsBuilder<SaraDbContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            var context = new SaraDbContext(options);
            {
                var message = new ContentMessage()
                {
                    ContentText = "This is an email.  How are you today?"
                };
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

                context.SmsThreads.Add(thread);
                context.ContentMessages.Add(message);
                context.SaveChanges();
                return context;
            }
        }
    }
}