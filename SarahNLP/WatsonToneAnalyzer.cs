//using System;
//using System.Collections.Generic;
//using System.Linq;
//using IBM.Cloud.SDK.Core.Authentication.Iam;
//using IBM.Cloud.SDK.Core.Http;
//using IBM.Watson.ToneAnalyzer.v3;
//using IBM.Watson.ToneAnalyzer.v3.Model;
//using SarahNLP.Models;
//using Newtonsoft.Json;
//using ServiceStack.Text;
//using ToneScore = SarahNLP.Models.ToneScore;

//namespace SarahNLP
//{
//    public class WatsonToneAnalyzer
//    {
//        public ToneAnalyzerService ToneAnalyzer { get; }

//        public WatsonToneAnalyzer()
//        {
//            IamAuthenticator authenticator = new IamAuthenticator(
//                apikey: "v5A8Bi-pEFpofuaFlqAFgwOtLe-wBVsn1z4WT6JiHyeE"
//            );

//            ToneAnalyzer = new ToneAnalyzerService("2017-09-21", authenticator);
//            ToneAnalyzer.SetServiceUrl(
//                "https://api.us-south.tone-analyzer.watson.cloud.ibm.com/instances/94200b79-e762-4114-9d4f-9797fb3526d8");
//        }

//        /// <summary>
//        /// Processes all messages stored in the db
//        /// </summary>
//        /// <param name="db"></param>
//        public void ProcessMessages(SaraDbContext db)
//        {
//            foreach (var message in db.Messages)
//            {
//                ProcessMessage(message);
//            }
//        }

//        /// <summary>
//        /// Processes an individual message
//        /// </summary>
//        /// <param name="m"></param>
//        /// <returns></returns>
//        public Message ProcessMessage(Message m)
//        {
//            Console.WriteLine($"Processing message of type {m.GetType().Name} with id: {m.MessageId}");
//            if (m is ContentMessage contentMessage)
//            {
//                DetailedResponse<ToneAnalysis> result = AnalyzeTone(contentMessage);
//                foreach (IBM.Watson.ToneAnalyzer.v3.Model.ToneScore toneScore in result.Result.DocumentTone.Tones)
//                {
//                    m.ToneScores.Add(new ToneScore()
//                    {
//                        Score = toneScore.Score,
//                        ToneName = toneScore.ToneName,
//                        ToneType = ToneType.Document
//                    });
//                }
//            }

//            else if (m is SmsThread thread)
//            {
//                DetailedResponse<UtteranceAnalyses> result = AnalyzeToneChat(thread);
//                foreach (var ua in result.Result.UtterancesTone)
//                {
//                    var smsMessage = thread.SmsMessages.Single(x => x.MessageText == ua.UtteranceText);
//                    foreach (var ts in ua.Tones)
//                    {
//                        smsMessage.ToneScores.Add(new ToneScore()
//                        {
//                            Score = ts.Score,
//                            ToneName = ts.ToneName,
//                            ToneType = ToneType.Utterance
//                        });
//                    }
//                }

//                result.PrintDump();
//            }

//            return m;
//        }

//        public DetailedResponse<ToneAnalysis> AnalyzeTone(ContentMessage message)
//        {
//            var result = ToneAnalyzer.Tone(new ToneInput() {Text = message.ContentText}, sentences: false);
//            return result;
//        }

//        public DetailedResponse<UtteranceAnalyses> AnalyzeToneChat(SmsThread thread)
//        {
//            var utterances = thread.SmsMessages.OrderBy(y => y.Created)
//                .Select(x => new Utterance()
//                {
//                    User = x.User,
//                    Text = x.MessageText
//                }).ToList();

//            var result = ToneAnalyzer.ToneChat(
//                utterances: utterances
//            );

//            return result;
//        }
//    }
//}