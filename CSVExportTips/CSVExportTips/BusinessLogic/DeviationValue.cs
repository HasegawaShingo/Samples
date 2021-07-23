using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using CSVExportTips.BusinessLogic.Entities;

namespace CSVExportTips.BusinessLogic
{
    public class DeviationValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool TestCSV()
        {
            // 動作確認用のエンティティを作成します。
            var entities = new List<SourceEntity>()
            {
                { new SourceEntity{ SourceID=1, RegistDate=DateTime.Now, Age=16, FirstName="ichiro", LastName="yamada",
                    EnglishDeviationValue=50, JapaneseDeviationValue=50, MathematicalDeviationValue=50, ScienceDeviationValue=50, SocialDeviationValue=50} },
                { new SourceEntity{ SourceID=2, RegistDate=DateTime.Now, Age=15, FirstName="jiro", LastName="suzuki",
                    EnglishDeviationValue=60, JapaneseDeviationValue=45, MathematicalDeviationValue=55, ScienceDeviationValue=55, SocialDeviationValue=40} },
                { new SourceEntity{ SourceID=3, RegistDate=DateTime.Now, Age=16, FirstName="saburo", LastName="honda",
                    EnglishDeviationValue=45, JapaneseDeviationValue=40, MathematicalDeviationValue=60, ScienceDeviationValue=60, SocialDeviationValue=40} },
                { new SourceEntity{ SourceID=4, RegistDate=DateTime.Now, Age=17, FirstName="shiro", LastName="matsuda",
                    EnglishDeviationValue=65, JapaneseDeviationValue=65, MathematicalDeviationValue=60, ScienceDeviationValue=65, SocialDeviationValue=65} },
                { new SourceEntity{ SourceID=5, RegistDate=DateTime.Now, Age=14, FirstName="goro", LastName="toyoda",
                    EnglishDeviationValue=40, JapaneseDeviationValue=45, MathematicalDeviationValue=45, ScienceDeviationValue=40, SocialDeviationValue=40} }
            };

            // CSVExportAttributeが設定されたプロパティを取得します。
            var exportProperties = typeof(SourceEntity).GetProperties().Where(e => Attribute.IsDefined(e, typeof(CSVExportAttribute))).ToList();

            // 出力するプロパティが無ければ処理終了します。
            if (exportProperties == null || exportProperties.Count == 0)
                return false;

            // OutputIDの値で並び替えます。
            exportProperties = exportProperties.OrderBy(e => ((CSVExportAttribute)Attribute.GetCustomAttribute(e, typeof(CSVExportAttribute))).OutputID).ToList();

            // ヘッダーテキストを取得します。
            var headerTextList = exportProperties.Select(e => ((CSVExportAttribute)Attribute.GetCustomAttribute(e, typeof(CSVExportAttribute))).ColumnsHeaderText).ToList();

            // 出力対象の実データを取得します。
            var exportVales = new List<List<string>>();
            foreach(var entity in entities)
            {
                var element = exportProperties.Select(e => typeof(SourceEntity).GetProperty(e.Name).GetValue(entity).ToString()).ToList();
                exportVales.Add(element);
            }

            // 出力先のファイルパスを設定します。
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "exportCSV.csv");

            // 出力します。
            return ExportCSV.ExportCSVFile(filePath, exportVales, headerTextList);
        }
    }
}
