using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleSortByScore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var listEntities = CreateEntities();
            ScoreDataGridview.DataSource = listEntities;


            ScoreDataGridview.MultiSelect = false;
            foreach(DataGridViewColumn column in ScoreDataGridview.Columns)
            {
                if (column.Name == nameof(SampleEntity.Name) ||
                    column.Name == nameof(SampleEntity.Age) ||
                    column.Name == nameof(SampleEntity.Class))
                {
                    continue;
                }
                column.Visible = false;
            }

            ScoreDataGridview.ClearSelection();
            IsInitializedDataGridview = true;
        }

        private List<SampleEntity> CreateEntities()
        {
            var result = new List<SampleEntity>();

            var entity = new SampleEntity()
            {
                Name = "たなか　いちろう",
                Age = 12,
                Class = "1-1",
                ScoreA = 40.0F,
                ScoreB = 80.1F,
                ScoreC = 75.0F,
                ScoreD = 30.0F,
                ScoreE = 80.0F
            };
            result.Add(entity);

            entity = new SampleEntity()
            {
                Name = "すずき　じろう",
                Age = 11,
                Class = "1-2",
                ScoreA = 90.2F,
                ScoreB = 85.0F,
                ScoreC = 90.2F,
                ScoreD = 70.0F,
                ScoreE = 80.0F
            };
            result.Add(entity);

            return result;
        }

        private bool IsInitializedDataGridview = false;
        private int CurrentRowIndex = -1;

        private void ScoreDataGridview_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsInitializedDataGridview)
                return;

            if (ScoreDataGridview.CurrentRow.Index == CurrentRowIndex)
                return;
            else
                CurrentRowIndex = ScoreDataGridview.CurrentRow.Index;

            var entity = ScoreDataGridview.CurrentRow.DataBoundItem as SampleEntity;

            var scoreDictionary = new Dictionary<string, double>();
            scoreDictionary.Add(nameof(entity.ScoreA), entity.ScoreA);
            scoreDictionary.Add(nameof(entity.ScoreB), entity.ScoreB);
            scoreDictionary.Add(nameof(entity.ScoreC), entity.ScoreC);
            scoreDictionary.Add(nameof(entity.ScoreD), entity.ScoreD);
            scoreDictionary.Add(nameof(entity.ScoreE), entity.ScoreE);

            // Topを取得
            var topScore = scoreDictionary.OrderByDescending(elem => elem.Value).First();
            var topScores = new List<string>();
            topScores.Add(topScore.Key);

            // Topと比較
            foreach(var item in scoreDictionary)
            {
                if (item.Key == topScore.Key)
                    continue;

                if (item.Value == topScore.Value)
                    topScores.Add(item.Key);
            }

            // label表示
            A.Text = scoreDictionary[nameof(entity.ScoreA)].ToString("F");
            B.Text = scoreDictionary[nameof(entity.ScoreB)].ToString("F");
            C.Text = scoreDictionary[nameof(entity.ScoreC)].ToString("F");
            D.Text = scoreDictionary[nameof(entity.ScoreD)].ToString("F");
            E.Text = scoreDictionary[nameof(entity.ScoreE)].ToString("F");

            // スコア表示
            TopScoreLabel.Text = string.Join(", ", topScores);

            // 色付け
            var ScoreLabels = new List<Label>
            {
                 A, B, C, D, E
            };

            // 色初期化
            foreach (Label item in ScoreLabels)
                item.BackColor = SystemColors.Control;

            foreach(var item in topScores)
            {
                foreach(Label label in ScoreLabels)
                {
                    if (item.Contains(label.Name))
                        label.BackColor = Color.LightPink;
                }
            }
        }
    }

    public class SampleEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Class { get; set; }
        public double ScoreA { get; set; }
        public double ScoreB { get; set; }
        public double ScoreC { get; set; }
        public double ScoreD { get; set; }
        public double ScoreE { get; set; }
    }
}
