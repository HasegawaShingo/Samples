using System;

namespace CSVExportTips.BusinessLogic.Entities
{
    public class SourceEntity
    {
        [CSVExport(1, "管理番号")]
        public int SourceID { get; set; }

        public DateTime RegistDate { get; set; }

        [CSVExport(2,"苗字")]
        public string FirstName { get; set; } = string.Empty;

        [CSVExport(3,"名前")]
        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        [CSVExport(5,"数学の偏差値")]
        public int MathematicalDeviationValue { get; set; }

        [CSVExport(6,"科学の偏差値")]
        public int ScienceDeviationValue { get; set; }

        [CSVExport(8,"英語の偏差値")]
        public int EnglishDeviationValue { get; set; }

        [CSVExport(4,"国語の偏差値")]
        public int JapaneseDeviationValue { get; set; }

        [CSVExport(7,"社会の偏差値")]
        public int SocialDeviationValue { get; set; }
    }
}
