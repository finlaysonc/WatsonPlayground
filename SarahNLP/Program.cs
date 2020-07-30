using System;
using System.Linq;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using Microsoft.EntityFrameworkCore;
using SarahNLP.Models;


//https://cloud.ibm.com/apidocs/tone-analyzer?_ga=2.205140304.1779029142.1595879069-1213115.1595453892&cm_mc_uid=86657345270115215799647&cm_mc_sid_50200000=99038091596009222315&cm_mc_sid_52640000=64833321596009424242&code=dotnet-standard#analyze-general-tone
namespace SarahNLP
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var db = SaraDbContext.CreateContextToLocalDb();
            db.Database.EnsureDeleted();
            db.Database.Migrate();
            db.SeedData();
            WatsonToneAnalyzer analyzer = new WatsonToneAnalyzer();

            analyzer.ProcessMessages(db);
        }
    }
}