using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeminarApp.Models;

namespace SeminarApp.Controllers
{
    public class CogController : Controller
    {
        CognitiveServiceHandler _handler;

        public CogController()
        {
            _handler = new CognitiveServiceHandler();
        }

        [HttpPost]
        public TranslatedItem DetectLanguage(string word)
        {

            return _handler.DetectLanguage(word);

        }

        [HttpPost]
        public EvaluatedSentiment SentimentEvaluation(string word)
        {
            return _handler.SentimentEvaluation(word);
        }
    }
}