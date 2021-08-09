using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace ComboboxTips
{
    public partial class Form2 : Form
    {
        private Dictionary<string, string> CategoryDictionary;
        private Dictionary<string, string> AllItemDictionary;

        /// <summary>
        /// 
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form2_Load(object sender, EventArgs e)
        {
            CategoryDictionary = CreateCategoryDictionay();
            AllItemDictionary = CreateAllItemDictionary();

            CategoryCombobox.DataSource = CategoryDictionary.ToList();
            CategoryCombobox.DisplayMember = "value";
            CategoryCombobox.ValueMember = "key";
        }

        /// <summary>
        /// カテゴリーコンボボックスで選択されたカテゴリーのアイテムのみを、コンボボックスのソースとして設定します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryCombobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedValue = ((ComboBox)sender).SelectedValue.ToString();
            if (!string.IsNullOrEmpty(selectedValue))
            {
                var itemDictionary = AllItemDictionary.Where(elem => elem.Key.StartsWith(selectedValue)).ToList();
                var firstItem = new KeyValuePair<string, string>(string.Empty, string.Empty);
                itemDictionary.Insert(0, firstItem);

                ItemCombobox.DataSource = itemDictionary;
                ItemCombobox.DisplayMember = "value";
                ItemCombobox.ValueMember = "key";
            }
        }

        /// <summary>
        /// カテゴリーの辞書を作成します。
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> CreateCategoryDictionay()
        {
            return new Dictionary<string, string>
            {
                {string.Empty, string.Empty },
                { "10", "野菜" },
                { "20", "果物"},
                { "30", "にく" },
                { "40", "さかな" },
                { "50", "おかし" }
            };
        }

        /// <summary>
        /// 各カテゴリーに属するすべてのアイテム辞書を作成します。
        /// </summary>
        /// <returns></returns>
        private Dictionary<string,string> CreateAllItemDictionary()
        {
            return new Dictionary<string, string>
            {
                { "10001", "きゅうり" },
                { "10002", "にんじん" },
                { "10003", "たまねぎ" },
                { "10004", "だいこん" },
                { "10005", "かぼちゃ" },
                { "10006", "なす" },
                { "10007", "にんにく" },
                { "10008", "ピーマン" },
                { "10009", "パプリカ" },
                { "10010", "アボカド" },
                { "20001", "りんご" },
                { "20002", "パイナップル" },
                { "20003", "バナナ" },
                { "20004", "なし" },
                { "20005", "ぶどう" },
                { "20006", "ドラゴンフルーツ" },
                { "20007", "もも" },
                { "20008", "すいか" },
                { "20009", "めろん" },
                { "20010", "いちご" },
                { "30001", "ももにく" },
                { "30002", "むねにく" },
                { "30003", "たん" },
                { "30004", "はつ" },
                { "30005", "レバー" },
                { "30006", "サーロイン" },
                { "30007", "ロース" },
                { "30008", "テール" },
                { "30009", "リブロース" },
                { "30010", "サーロイン" },
                { "40001", "しゃけ" },
                { "40002", "ほっけ" },
                { "40003", "ししゃも" },
                { "40004", "たら" },
                { "40005", "たちうお" },
                { "40006", "マグロ" },
                { "40007", "すずき" },
                { "40008", "とびうお" },
                { "40009", "シーラ" },
                { "40010", "かつお" },
                { "50001", "チョコレート" },
                { "50002", "ビスケット" },
                { "50003", "ショートケーキ" },
                { "50004", "モンブラン" },
                { "50005", "ポテトチップス" },
                { "50006", "あめ" },
                { "50007", "クッキー" },
                { "50008", "バームクーヘン" },
                { "50009", "シュークリーム" },
                { "50010", "ぐみ" },
            };
        }


    }
}
