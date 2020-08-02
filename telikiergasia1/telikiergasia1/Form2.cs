using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telikiergasia1
{
    public partial class Form2 : Form
    {
        List<PlayersData> F2PlayersList;
        void FindBest10()
        {
            var NameTrieList = new List<KeyValuePair<int, string>>();
            foreach (PlayersData pd in F2PlayersList)
            {
                string[] tmpArray;
                tmpArray = pd.PTries.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tmpArray.Length; i++)
                {
                    try
                    {
                        NameTrieList.Add(new KeyValuePair<int, string>(int.Parse(tmpArray[i]), pd.PName));
                    }
                    catch (System.FormatException) { }
                }
            }
            NameTrieList.Sort((x, y) => x.Key.CompareTo(y.Key));
            for (int j=0;j<10;j++)
            {
                richTextBox1.AppendText(NameTrieList[j].Value+"   "+NameTrieList[j].Key+Environment.NewLine);
            }
        }
        public Form2(List<PlayersData> ListFromForm1)
        {
            InitializeComponent();
            F2PlayersList = ListFromForm1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FindBest10();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
            FindBest10();
        }
    }
}
