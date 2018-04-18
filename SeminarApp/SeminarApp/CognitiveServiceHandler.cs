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

        public TranslatedItem DetectLanguage(String wordToDetect)
        {
            // First, create the client 
            ITextAnalyticsAPI client = new TextAnalyticsAPI();

            client.AzureRegion = AzureRegions.Westcentralus;

            client.SubscriptionKey = SUBSCRIPTION_KEY;

            LanguageBatchResult result = client.DetectLanguage(
                new BatchInput(
                    new List<Input>()
                    {
                        new Input("1", wordToDetect)
                    }));

            // transform the results into a recognizeable model

            TranslatedItem word = new TranslatedItem { OrignalWord = wordToDetect, DetectedLanguage = result.Documents[0].DetectedLanguages[0].Name, NonEnglishWord = false };

            if (result.Documents[0].DetectedLanguages[0].Name != "English")
            {
                word.NonEnglishWord = true;
            }

            return word;
        }
    }
}
