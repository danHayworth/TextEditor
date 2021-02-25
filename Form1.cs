using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace NewProject2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string lastFileName = "";

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextReader dan;
            opnTextFile.Filter = "Text Files(*.txt)|*.txt|" + "All Files(*.*)|*.*";
            opnTextFile.ShowDialog();
            lastFileName = opnTextFile.FileName;
            if (opnTextFile.FileName != "")
            {
                try
                {
                    dan = File.OpenText(opnTextFile.FileName);
                    txtEditor.Text = dan.ReadToEnd();
                    dan.Close();
                }

                catch (Exception nica)
                {
                    MessageBox.Show("Nada");
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        }
        private void SaveAs()
        {
            SaveFileDialog savText = new SaveFileDialog();
            savText.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            savText.ShowDialog();
            lastFileName = savText.FileName;
            if (savText.FileName != "")
            {
                using (StreamWriter outputFile = new StreamWriter(savText.OpenFile()))
                {
                    foreach (string line in txtEditor.Lines)
                        outputFile.WriteLine(line);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lastFileName != "")
            {
                using (StreamWriter outputFile = new StreamWriter(lastFileName))
                {
                    foreach (string line in txtEditor.Lines)
                        outputFile.WriteLine(line);
                }
            }
            else
            {
                SaveAs();
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            txtEditor.Text = "";
            lastFileName = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void mnuWordWrap_Click(object sender, EventArgs e)
        {
            mnuWordWrap.Checked = !mnuWordWrap.Checked;
            txtEditor.Select(0, 0);
        }
    }

    
}
