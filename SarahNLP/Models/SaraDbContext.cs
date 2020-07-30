﻿using System;
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

        const string connection =
            "Server=(localdb)\\MSSQLLocalDB;Database=Sara;Trusted_Connection=True;";

        /// <summary>
        /// The message types are modeled as Table Per Hierarchy w/ a concrete base class, Message
        /// </summary>
        public DbSet<Message> Messages { get; set; }

        public DbSet<SmsThread> SmsThreads { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }

        public DbSet<ContentMessage> ContentMessages { get; set; }
        public DbSet<ToneScore> ToneScores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(connection);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .Property(b => b.Craeted).HasDefaultValueSql("getutcdate()");
        }


        public static SaraDbContext CreateContextToLocalDb()
        {
            var options = new DbContextOptionsBuilder<SaraDbContext>()
                .UseSqlServer(connection)
                .Options;
            return new SaraDbContext(options);
        }

        public static SaraDbContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<SaraDbContext>()
                .UseInMemoryDatabase("SaraDb")
                .Options;
            return new SaraDbContext(options);
        }

        public void SeedData()
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

            SmsThreads.Add(thread);
            ContentMessages.Add(message);
            SaveChanges();
        }
    }
}