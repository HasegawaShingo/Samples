using System;

namespace CSVExportTips.BusinessLogic
{
    /// <summary>
    /// CSV出力対象のプロパティに付与するカスタム属性です。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class CSVExportAttribute : Attribute
    {
        /// <summary>
        /// CSVへの出力順です。
        /// </summary>
        public int OutputID { get; private set; }
        /// <summary>
        /// カラムのヘッダーテキストです。
        /// </summary>
        public string ColumnsHeaderText { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="outputID">CSVへの出力順を指定してください。</param>
        /// <param name="columnHeaderText">カラムのヘッダーテキストを指定してください。</param>
        public CSVExportAttribute(int outputID, string columnHeaderText)
        {
            OutputID = outputID;
            ColumnsHeaderText = columnHeaderText;
        }
    }
}
