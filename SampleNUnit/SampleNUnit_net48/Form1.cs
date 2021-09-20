using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SampleNUnit_net48
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<string> ReadSourceFile()
        {
            var filePath = ConfigurationManager.AppSettings["InputSource"];
            var readFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), filePath);
            var readFilePath = new Uri(readFile).AbsolutePath;

            if (File.Exists(readFilePath))
                return File.ReadAllLines(readFilePath).ToList();
            else
                return new List<string>();
        }
    }
}
