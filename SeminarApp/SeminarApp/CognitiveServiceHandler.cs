using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using SeminarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarApp
{
    public class CognitiveServiceHandler
    {
        private static string SUBSCRIPTION_KEY = "0f490b17c8eb40d38616b51c3be9d170";

        ITextAnalyticsAPI _client;

        public CognitiveServiceHandler()
        {
            // initialize client
            _client = new TextAnalyticsAPI();
            _client.AzureRegion = AzureRegions.Westcentralus;
            _client.SubscriptionKey = SUBSCRIPTION_KEY;
        }

        public TranslatedItem DetectLanguage(String wordToDetect)
        {
            LanguageBatchResult result = _client.DetectLanguage(
                new BatchInput(
                    new List<Input>()
                    {
                        new Input("1", wordToDetect)
                    }));

            // transform the results into a recognizeable model

            TranslatedItem word = new TranslatedItem { OrignalWord = wordToDetect, DetectedLanguage = result.Documents[0].DetectedLanguages[0].Name, NonEnglishWord = false, ISOName = result.Documents[0].DetectedLanguages[0].Iso6391Name };

            if (result.Documents[0].DetectedLanguages[0].Name != "English")
            {
                word.NonEnglishWord = true;
            }

            return word;
        }

        public EvaluatedSentiment SentimentEvaluation(string word)
        {
            // Translate the sentence to detect what lgnauge it is

            TranslatedItem sentence = DetectLanguage(word);

            SentimentBatchResult result = _client.Sentiment(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                          new MultiLanguageInput(sentence.ISOName, "0", sentence.OrignalWord),
                        }));

            EvaluatedSentiment sentiment = new EvaluatedSentiment { Sentence = word, Score = (double)result.Documents[0].Score * 100 };
            return sentiment;
        }
    }
}
