using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleReadWriteFile.BusinessLogic.Entities
{
    public class ExamResultsEntity
    {
        public int ManageID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int JapaneseScore { get; set; }
        public int EnglishScore { get; set; }
        public int MathScore { get; set; }
        public int ScienceScore { get; set; }
        public int SocialScore { get; set; }
        public double AverageScore { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
