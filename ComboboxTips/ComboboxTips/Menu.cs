using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboboxTips
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void SourceBindingSample_Click(object sender, EventArgs e)
        {
            using var sourceBindingForm = new Form1();
            sourceBindingForm.ShowDialog();
        }

        private void SourceExchangeSample_Click(object sender, EventArgs e)
        {
            using var sourceExchangeForm = new Form2();
            sourceExchangeForm.ShowDialog();
        }
    }
}
