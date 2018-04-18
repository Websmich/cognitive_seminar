using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using SeminarApp.Models;

namespace SeminarApp.Controllers
{
    public class HomeController : Controller
    {

        private static string SUBSCRIPTION_KEY = "0f490b17c8eb40d38616b51c3be9d170";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Translate(String translateWord)
        {
            // First, create the client 
            ITextAnalyticsAPI client = new TextAnalyticsAPI();

            client.AzureRegion = AzureRegions.Westcentralus;

            client.SubscriptionKey = SUBSCRIPTION_KEY;

            LanguageBatchResult result = client.DetectLanguage(
                new BatchInput(
                    new List<Input>()
                    {
                        new Input("1", translateWord)
                    }));

            // transform the results into a recognizeable model

            TranslatedItem word = new TranslatedItem { OrignalWord = translateWord, DetectedLanguage = result.Documents[0].DetectedLanguages[0].Name, NonEnglishWord = false};


            // If the word is NOT in english, translate it automatically
            if (result.Documents[0].DetectedLanguages[0].Name != "English")
            {
                String shortFormName = result.Documents[0].DetectedLanguages[0].Iso6391Name;
                word.NonEnglishWord = true;
            }


            return View(word);
        }

    }
}
