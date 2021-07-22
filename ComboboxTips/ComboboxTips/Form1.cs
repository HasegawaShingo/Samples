using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace ComboboxTips
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// コンボボックスに設定するソース
        /// </summary>
        private readonly Dictionary<string, string> ComboboxSource;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ComboboxSource = new Dictionary<string, string> { { string.Empty, string.Empty } };
        }

        /// <summary>
        /// 画面起動時にコンボボックス設定をします。
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 設定ファイルからコンボボックスのデータソースを取得して、ディクショナリに格納します。
            var comboSources = (NameValueCollection)ConfigurationManager.GetSection("SourceList");

            foreach(string item in comboSources)
            {
                ComboboxSource.Add(item, comboSources[item]);
            }

            // ディクショナリをコンボボックスに設定します。
            ComboBox1.DataSource = ComboboxSource.ToList();
            ComboBox1.DisplayMember = "key";
            ComboBox1.ValueMember = "value";
        }

        /// <summary>
        /// 選択時に選択されたkeyに対するvalueを取得してラベルに設定します。
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Label1.Text = $"value -> {ComboBox1.SelectedValue}";
        }
    }
}
