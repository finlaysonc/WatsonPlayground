//using System;
//using System.Collections.Generic;
//using IBM.Cloud.SDK.Core.Authentication.Iam;
    //using IBM.Watson.ToneAnalyzer.v3;
    //using IBM.Watson.ToneAnalyzer.v3.Model;

//namespace NaturalLanguageProcessor
//{
//    public class ServiceExample
//    {
//        string apikey = "{apikey}";
//        string url = "{serviceUrl}";
//        private string versionDate = "{versionDate}";

//        static void Main(string[] args)
//        {
//            ServiceExample example = new ServiceExample();

//            example.Tone();
//            example.ToneChat();

//            Console.WriteLine("Examples complete. Press any key to close the application.");
//            Console.ReadKey();
//        }

//        #region Analyze Tone
//        public void Tone()
//        {
//            IamAuthenticator authenticator = new IamAuthenticator(
//                apikey: "{apikey}");

//            ToneAnalyzerService service = new ToneAnalyzerService("2017-09-21", authenticator);
//            service.SetServiceUrl("{serviceUrl}");

//            ToneInput toneInput = new ToneInput()
//            {
//                Text = "Team, I know that times are tough! Product sales have been disappointing for the past three quarters. We have a competitive product, but we need to do a better job of selling it!"
//            };

//            var result = service.Tone(
//                toneInput: toneInput
//            );

//            Console.WriteLine(result.Response);
//        }
//        #endregion

//        #region Analyze Customer Engagment Tone
//        public void ToneChat()
//        {
//            IamAuthenticator authenticator = new IamAuthenticator(
//                apikey: "{apikey}");

//            ToneAnalyzerService service = new ToneAnalyzerService("2017-09-21", authenticator);
//            service.SetServiceUrl("{serviceUrl}");

//            var utterances = new List<Utterance>()
//            {
//                new Utterance()
//                {
//                    Text = "Hello, I'm having a problem with your product.",
//                    User = "customer"
//                },
//                new Utterance()
//                {
//                    Text = "OK, let me know what's going on, please.",
//                    User = "agent"
//                },
//                new Utterance()
//                {
//                    Text = "Well, nothing is working :(",
//                    User = "customer"
//                },
//                new Utterance()
//                {
//                    Text = "Sorry to hear that.",
//                    User = "agent"
//                }
//            };

//            var result = service.ToneChat(
//                utterances: utterances
//            );

//            Console.WriteLine(result.Response);
//        }
//        #endregion
//    }
//}