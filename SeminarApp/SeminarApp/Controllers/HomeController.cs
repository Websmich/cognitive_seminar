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
        CognitiveServiceHandler _handler;

        public HomeController()
        {
            _handler = new CognitiveServiceHandler();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Translate(String translateWord)
        {
            TranslatedItem word = _handler.DetectLanguage(translateWord);
            return View(word);
        }

        public IActionResult Sentiment(String sentence)
        {
            EvaluatedSentiment sentiment = _handler.SentimentEvaluation(sentence);
            return View(sentiment);
        }

    }
}
