using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSVExportTips.BusinessLogic
{
    public static class ExportCSV
    {
        /// <summary>
        /// エンティティの文字列リストをCSVとして出力します。
        /// ヘッダー用文字列リストが設定されている場合は、先頭行にヘッダーテキストを出力します。
        /// </summary>
        /// <param name="destinationFilePath">保存先ファイルパスを指定してください。すでに存在する場合は上書きをします。</param>
        /// <param name="exportSources">出力対象のエンティティリスト（各カラムを文字列リストに格納）を指定してください。</param>
        /// <param name="headerSorces">ヘッダー用文字列リストを指定してください。</param>
        /// <returns>ファイル出力が成功した場合にtrue、失敗下場合にfalseを返します。</returns>
        public static bool ExportCSVFile(string destinationFilePath, List<List<string>> exportSources, List<string> headerSorces)
        {
            if (string.IsNullOrWhiteSpace(destinationFilePath))
                throw new ArgumentNullException(nameof(destinationFilePath));

            if(exportSources==null||exportSources.Count==0)
                throw new ArgumentNullException(nameof(exportSources));

            var builder = new StringBuilder();

            if (headerSorces != null || headerSorces.Count != 0)
                builder.AppendLine(string.Join(',', headerSorces));

            foreach (var entity in exportSources)
                builder.AppendLine(string.Join(',', entity));

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            File.WriteAllText(destinationFilePath, builder.ToString(), Encoding.GetEncoding("shift_jis"));

            return File.Exists(destinationFilePath);
        }
    }
}
