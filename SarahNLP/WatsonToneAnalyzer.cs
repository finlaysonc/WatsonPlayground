using System;
using System.Collections.Generic;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http;
using IBM.Watson.ToneAnalyzer.v3;
using IBM.Watson.ToneAnalyzer.v3.Model;

namespace SarahNLP
{
    public class WatsonToneAnalyzer
    {
        public ToneAnalyzerService ToneAnaluyzer { get; }

        public WatsonToneAnalyzer()
        {
            IamAuthenticator authenticator = new IamAuthenticator(
                apikey: "v5A8Bi-pEFpofuaFlqAFgwOtLe-wBVsn1z4WT6JiHyeE"
            );

            ToneAnaluyzer = new ToneAnalyzerService("2017-09-21", authenticator);
            ToneAnaluyzer.SetServiceUrl(
                "https://api.us-south.tone-analyzer.watson.cloud.ibm.com/instances/94200b79-e762-4114-9d4f-9797fb3526d8");
        }

        /// <summary>
        /// Analyze general tone.
        ///
        /// Use the general-purpose endpoint to analyze the tone of your input content. The service analyzes the content
        /// for emotional and language tones. The method always analyzes the tone of the full document; by default, it
        /// also analyzes the tone of each individual sentence of the content.
        ///
        /// You can submit no more than 128 KB of total input content and no more than 1000 individual sentences in
        /// JSON, plain text, or HTML format. The service analyzes the first 1000 sentences for document-level analysis
        /// and only the first 100 sentences for sentence-level analysis.
        ///
        /// Per the JSON specification, the default character encoding for JSON content is effectively always UTF-8; per
        /// the HTTP specification, the default encoding for plain text and HTML is ISO-8859-1 (effectively, the ASCII
        /// character set). When specifying a content type of plain text or HTML, include the `charset` parameter to
        /// indicate the character encoding of the input text; for example: `Content-Type: text/plain;charset=utf-8`.
        /// For `text/html`, the service removes HTML tags and analyzes only the textual content.
        ///
        /// **See also:** [Using the general-purpose
        /// endpoint](https://cloud.ibm.com/docs/tone-analyzer?topic=tone-analyzer-utgpe#utgpe).
        /// </summary>
        /// <param name="toneInput">JSON, plain text, or HTML input that contains the content to be analyzed. For JSON
        /// input, provide an object of type `ToneInput`.</param>
        /// <param name="contentType">The type of the input. A character encoding can be specified by including a
        /// `charset` parameter. For example, 'text/plain;charset=utf-8'. (optional)</param>
        /// <param name="sentences">Indicates whether the service is to return an analysis of each individual sentence
        /// in addition to its analysis of the full document. If `true` (the default), the service returns results for
        /// each sentence. (optional, default to true)</param>
        /// <param name="contentLanguage">The language of the input text for the request: English or French. Regional
        /// variants are treated as their parent language; for example, `en-US` is interpreted as `en`. The input
        /// content must match the specified language. Do not submit content that contains both languages. You can use
        /// different languages for **Content-Language** and **Accept-Language**.
        /// * **`2017-09-21`:** Accepts `en` or `fr`.
        /// * **`2016-05-19`:** Accepts only `en`. (optional, default to en)</param>
        /// <param name="acceptLanguage">The desired language of the response. For two-character arguments, regional
        /// variants are treated as their parent language; for example, `en-US` is interpreted as `en`. You can use
        /// different languages for **Content-Language** and **Accept-Language**. (optional, default to en)</param>
        /// <returns><see cref="ToneAnalysis" />ToneAnalysis</returns>

        public DetailedResponse<ToneAnalysis> ProcessTone(ToneInput toneInput, string contentType = null,
            bool? sentences = null,
            string contentLanguage = null, string acceptLanguage = null)
        {
            var result = ToneAnaluyzer.Tone(toneInput: toneInput, sentences: false);
            Console.WriteLine(result.Response);
            return result;
        }

        public void AnalyzeTones()
        {
            ToneInput toneInput = new ToneInput()
            {
                Text =
                    "Team, I know that times are tough! Product sales have been disappointing for the past three quarters. We have a competitive product, but we need to do a better job of selling it!"
            };
            var result = ProcessTone(toneInput);
            Console.WriteLine(result.Response);
        }

    }
}

/// <summary>
/// Analyze customer-engagement tone.
///
/// Use the customer-engagement endpoint to analyze the tone of customer service and customer support
/// conversations. For each utterance of a conversation, the method reports the most prevalent subset of the
/// following seven tones: sad, frustrated, satisfied, excited, polite, impolite, and sympathetic.
///
/// If you submit more than 50 utterances, the service returns a warning for the overall content and analyzes
/// only the first 50 utterances. If you submit a single utterance that contains more than 500 characters, the
/// service returns an error for that utterance and does not analyze the utterance. The request fails if all
/// utterances have more than 500 characters. Per the JSON specification, the default character encoding for
/// JSON content is effectively always UTF-8.
///
/// **See also:** [Using the customer-engagement
/// endpoint](https://cloud.ibm.com/docs/tone-analyzer?topic=tone-analyzer-utco#utco).
/// </summary>
/// <param name="utterances">An object that contains the content to be analyzed.</param>
/// <param name="contentLanguage">The language of the input text for the request: English or French. Regional
/// variants are treated as their parent language; for example, `en-US` is interpreted as `en`. The input
/// content must match the specified language. Do not submit content that contains both languages. You can use
/// different languages for **Content-Language** and **Accept-Language**.
/// * **`2017-09-21`:** Accepts `en` or `fr`.
/// * **`2016-05-19`:** Accepts only `en`. (optional, default to en)</param>
/// <param name="acceptLanguage">The desired language of the response. For two-character arguments, regional
/// variants are treated as their parent language; for example, `en-US` is interpreted as `en`. You can use
/// different languages for **Content-Language** and **Accept-Language**. (optional, default to en)</param>
/// <returns><see cref="UtteranceAnalyses" />UtteranceAnalyses</returns>
//public DetailedResponse<UtteranceAnalyses> ToneChat(List<Utterance> utterances, string contentLanguage = null,
//    string acceptLanguage = null)
//{
//}

//    public void ToneChat()
//    {
//    IamAuthenticator authenticator = new IamAuthenticator(
//        apikey: "{apikey}");

//    ToneAnalyzerService service = new ToneAnalyzerService("2017-09-21", authenticator);
//    service.SetServiceUrl("{serviceUrl}");
//    service.Tone(To)
//        var utterances = new List<Utterance>()
//    {
//        new Utterance()
//        {
//            Text = "Hello, I'm having a problem with your product.",
//            User = "customer"
//        },
//        new Utterance()
//        {
//            Text = "OK, let me know what's going on, please.",
//            User = "agent"
//        },
//        new Utterance()
//        {
//            Text = "Well, nothing is working :(",
//            User = "customer"
//        },
//        new Utterance()
//        //{
//            Text = "Sorry to hear that.",
//            User = "agent"
//        }
//    };

//    var result = service.ToneChat(
//        utterances: utterances
//    );

//    Console.WriteLine(result.Response);
//    }


//    public void AnalyzeDatabase()
//    {
//    }
//}

//}