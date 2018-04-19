using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SeminarApp.Models
{
    public class TranslatedItem
    {
        public String OrignalWord { get; set; }

        public String DetectedLanguage { get; set; }

        public Boolean NonEnglishWord { get; set; }

        public string ISOName { get; set; }
    }
}
