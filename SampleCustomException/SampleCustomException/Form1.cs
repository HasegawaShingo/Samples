using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SampleCustomException
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var sample = new SampleClass();
                sample.CreateHogeHogeException();
            }
            catch(HogeHogeException)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new DirectoryNotFoundException("hogehoge directory");
        }
    }
}
