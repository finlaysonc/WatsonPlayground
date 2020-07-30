using System;
using System.Configuration;
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
            //db.Database.EnsureDeleted();
            //db.Database.Migrate();
            //db.SeedData();

            //var apiKey="v5A8Bi-pEFpofuaFlqAFgwOtLe-wBVsn1z4WT6JiHyeE";
            //var url = "https://api.us-south.tone-analyzer.watson.cloud.ibm.com/instances/94200b79-e762-4114-9d4f-9797fb3526d8";
            WatsonToneAnalyzer analyzer = new WatsonToneAnalyzer(
                ConfigurationManager.AppSettings["WatsonToneAnalyzerApiKey"],
                ConfigurationManager.AppSettings["WatsonToneAnalyzerUrl"]);;
            analyzer.ProcessMessages(db);
        }
    }
}