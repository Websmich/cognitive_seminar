using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarApp.Models
{
    public class EvaluatedSentiment
    {
        public string Sentence { get; set; }

        public double Score { get; set; }

        public string SentimentOpinion
        {
            get {
                string opinion = "";
                if (Score <= 20)
                {
                    opinion = "This comment seems very negative.";
                }
                else if (Score > 20 && Score <= 40)
                {
                    opinion = "This comment seems kind of negative";
                }
                else if (Score > 40 && Score <= 60)
                {
                    opinion = "This comment seems neutral";
                }
                else if (Score > 60 && Score <= 80)
                {
                    opinion = "This comment seems kind of positive";
                }
                else
                {
                    opinion = "This comment seems very positive";

                }

                return opinion;
            }
        }
    }
}
