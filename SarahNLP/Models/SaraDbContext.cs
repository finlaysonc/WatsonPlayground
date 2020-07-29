using Microsoft.EntityFrameworkCore;

namespace SarahNLP.Models
{
    public class SaraDbContext : DbContext
    {
        public SaraDbContext(DbContextOptions<SaraDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }

        public void SeedDatabase()
        {
            //    ToneInput toneInput = new ToneInput()
            //    {
            //        Text =
            //            "Team, I know that times are tough! Product sales have been disappointing for the past three quarters. We have a competitive product, but we need to do a better job of selling it!"
            //    };

            //    var result = toneAnalyzer.Tone(
            //        toneInput: toneInput
            //    );

            //    Console.WriteLine(result.Response);


            //    var options = new DbContextOptionsBuilder<SaraDbContext>()
            //        .UseInMemoryDatabase(databaseName: "Test")
            //        .Options;



            //    using (var context = new SaraDbContext(options))
            //    {
            //        var message = new Message()
            //        {
            //            MessageType = MessageType.Email,
            //            MessageText = "This is an email.  How are you today?"
            //        };
            //        message = new Message()
            //        {
            //            MessageType = MessageType.Email,
            //            MessageText = "This is an email.  How are you today again?"
            //        };

            //        context.Messages.Add(message);
            //        context.SaveChanges();
            //    }
            //}
            //}
        }
    }
}