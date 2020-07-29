using System;
using IBM.Cloud.SDK.Core.Authentication.Iam;

//https://cloud.ibm.com/apidocs/tone-analyzer?_ga=2.205140304.1779029142.1595879069-1213115.1595453892&cm_mc_uid=86657345270115215799647&cm_mc_sid_50200000=99038091596009222315&cm_mc_sid_52640000=64833321596009424242&code=dotnet-standard#analyze-general-tone
namespace SarahNLP
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            WatsonToneAnalyzer analyzer = new WatsonToneAnalyzer();
            analyzer.AnalyzeTones();

            //IamAuthenticator authenticator = new IamAuthenticator(
            //    apikey: "v5A8Bi-pEFpofuaFlqAFgwOtLe-wBVsn1z4WT6JiHyeE"
            //);

            //ToneAnalyzerService toneAnalyzer = new ToneAnalyzerService("2017-09-21", authenticator);
            //toneAnalyzer.SetServiceUrl(
            //    "https://api.us-south.tone-analyzer.watson.cloud.ibm.com/instances/94200b79-e762-4114-9d4f-9797fb3526d8");

            //ToneInput toneInput = new ToneInput()
            //{
            //    Text =
            //        "Team, I know that times are tough! Product sales have been disappointing for the past three quarters. We have a competitive product, but we need to do a better job of selling it!"
            //};

            //var result = toneAnalyzer.Tone(
            //    toneInput: toneInput
            //);

            //Console.WriteLine(result.Response);
        }
    }
}