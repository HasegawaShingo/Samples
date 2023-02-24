using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SampleDataGridView
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// データソースのエンティティリスト
        /// </summary>
        private List<SourceEntity> SourceEntities;

        /// <summary>
        /// データグリッドビューが初期化済みか否か
        /// </summary>
        private bool IsInitializedDataGridview = false;

        /// <summary>
        /// データグリッドビューの現在の選択行
        /// </summary>
        private int CurrentRowIndex = -1;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Application.Idle += Application_Idle;
        }

        bool isProcessing = false;

        private void Application_Idle(object sender, EventArgs e)
        {
            isProcessing = false;
        }

        /// <summary>
        /// データグリッドビューにエンティティリストを設定して、見た目を整えます。
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void BindButton_Click(object sender, EventArgs e)
        {
            if (isProcessing)
                return;
            else
                isProcessing = true;

            var currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            // エンティティリストを作成
            if (SourceEntities != null)
                SourceEntities = null;

            SourceEntities = CreateDataSource(10000);

            // datagridviewにエンティティリストを設定
            SourceList.DataSource = SourceEntities;

            // datagridviewの見た目を編集
            DataGridViewDisplaySetting();

            // 選択の解除
            SourceList.ClearSelection();

            // データグリッドビュー初期化終了宣言
            IsInitializedDataGridview = true;

            Cursor.Current = currentCursor;
        }

        /// <summary>
        /// お試し用のエンティティリストを作成
        /// ちなみに、偶数行のstatusに済みを入れます。
        /// </summary>
        /// <param name="createNumber">作成するレコード数を指定してください。</param>
        /// <returns>エンティティリストを返します。</returns>
        private static List<SourceEntity> CreateDataSource(int createNumber)
        {
            var result = new List<SourceEntity>();

            for (int i = 0; i < createNumber; i++)
            {
                var entity = new SourceEntity()
                {
                    Id = i,
                    Name = $"Name{i}",
                    Age = i + 1,
                    ScoreA = i + 2,
                    ScoreB = i + 3,
                    ScoreC = i + 4,
                    ScoreD = i + 5,
                    ScoreE = i + 6,
                    Status = string.Empty
                };

                // 偶数行の場合に値を設定する
                if (i % 2 == 0)
                    entity.Status = "済み";

                result.Add(entity);
            }

            return result;
        }

        /// <summary>
        /// データグリッドビューの見た目を整えます。
        /// </summary>
        /// <returns></returns>
        private bool DataGridViewDisplaySetting()
        {
            // スコアプロパティを非表示
            foreach(DataGridViewColumn column in SourceList.Columns)
            {
                if (column.Name.Contains("Score"))
                    column.Visible = false;
            }

            // ヘッダーテキストの設定
            SourceList.Columns["ID"].HeaderText = "管理番号";
            SourceList.Columns["Name"].HeaderText = "氏名";
            SourceList.Columns["Age"].HeaderText = "年齢";
            SourceList.Columns["Status"].HeaderText = "確認状況";

            // カラムの幅を自動調整
            SourceList.AutoResizeColumns();

            return true;
        }

        /// <summary>
        /// データグリッドビューの選択行が変わった時に、画面内のスコア表示を切り替えます。
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SourceList_SelectionChanged(object sender, EventArgs e)
        {
            if (!IsInitializedDataGridview)
                return;

            isProcessing = true;

            if (CurrentRowIndex == SourceList.CurrentRow.Index)
                return;

            CurrentRowIndex = SourceList.CurrentRow.Index;
            int scoreA = Convert.ToInt32(SourceList.CurrentRow.Cells["ScoreA"].Value);
            int scoreB = Convert.ToInt32(SourceList.CurrentRow.Cells["ScoreB"].Value);
            int scoreC = Convert.ToInt32(SourceList.CurrentRow.Cells["ScoreC"].Value);
            int scoreD = Convert.ToInt32(SourceList.CurrentRow.Cells["ScoreD"].Value);
            int scoreE = Convert.ToInt32(SourceList.CurrentRow.Cells["ScoreE"].Value);
            A.Text = scoreA.ToString();
            B.Text = scoreB.ToString();
            C.Text = scoreC.ToString();
            D.Text = scoreD.ToString();
            E.Text = scoreE.ToString();

            AverageScore.Text = ((scoreA + scoreB + scoreC + scoreD + scoreE) / 5).ToString();
        }

        /// <summary>
        /// 平均得点とステータスを更新します。
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // datagridviewのデータソースを操作すれば、バインド元のオブジェクトも値が更新される。便利！
            // datagridviewのセルに値を設定しているから、一覧部品の見た目もすぐに更新される。
            SourceList.CurrentRow.Cells["ScoreAverage"].Value = Convert.ToInt32(AverageScore.Text);
            SourceList.CurrentRow.Cells["Status"].Value = "済み";

            // 変更をしたRowをオブジェクトとして取得することも可能。オブジェクトからファイルに書き出しができるね。
            var entity = (SourceEntity)SourceList.CurrentRow.DataBoundItem;
        }

        /// <summary>
        /// 平均得点とステータスを更新します。
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void SaveButton2_Click(object sender, EventArgs e)
        {
            // こっちは逆にバインド先の情報を書き換える場合
            // 一覧部品の見た目はすぐに更新されない。
            var entity = (SourceEntity)SourceList.CurrentRow.DataBoundItem;
            entity.ScoreAverage = Convert.ToInt32(AverageScore.Text);
            entity.Status = "済み";

            // refreshならカーソル位置も変わらず、一覧を更新することができる。
            SourceList.Refresh();
        }

        /// <summary>
        /// データグリッドビューのstatusによって表示を切り替えます。
        /// チェックあり：済み以外のみを表示
        /// チェックなし：すべてのレコードを表示
        /// </summary>
        /// <param name="sender">イベント発行元オブジェクト</param>
        /// <param name="e">イベントデータ</param>
        private void StatusViewChangeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (SourceEntities == null)
                return;

            IsInitializedDataGridview = false;

            if ((sender as CheckBox).Checked)
            {
                // 絞り込み表示用にエンティティリストを絞します。
                var notFinishEntities = SourceEntities.Where(elem => elem.Status != "済み").ToList();
                SourceList.DataSource = notFinishEntities;
            }
            else
            {
                // 元のエンティティリストを再設定します。
                SourceList.DataSource = SourceEntities;
            }

            SourceList.ClearSelection();
            IsInitializedDataGridview = true;
        }
    }

    /// <summary>
    /// お試し用のエンティティ
    /// </summary>
    public class SourceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int ScoreA { get; set; }
        public int ScoreB { get; set; }
        public int ScoreC { get; set; }
        public int ScoreD { get; set; }
        public int ScoreE { get; set; }
        public string Status { get; set; } = string.Empty;
        public int ScoreAverage { get; set; }
    }
}
