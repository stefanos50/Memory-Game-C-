using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace telikiergasia1
{
    public partial class Form1 : Form
    {
        int Ttime,tries;
        string UsingImagesFrom = "Default";
        List<UserImages> ImagesList;
        List<PlayersData> PlayersList;
        string[] PicturesArray = {"asterias.png", "feashell.png", "fish1.png", "fish2.png", "fish3.png", "fish4.png", "fish6.png", "fish7.png"
        , "fish8.png", "fish9.png", "fish10.png", "fish12.png"};
        List<PictureBox> pbList = new List<PictureBox>();
        void EnableDisableButtons(string action)
        {
            if(action == "Enable")
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }
        }
        void UpdateFile()
        {
            string[] NewFileData = new string[PlayersList.Count];
            for(int i=0;i< PlayersList.Count;i++)
            {
                NewFileData[i] = PlayersList[i].PName+PlayersList[i].PTries;
            }
            File.WriteAllLines("PlayerTries.txt", NewFileData);
        }
            void InitializeFileData()
        {
            PlayersList = new List<PlayersData>();
            string[] Filelines = File.ReadAllLines("PlayerTries.txt");
            for(int i = 0; i < Filelines.Length; i++)
            {
                string[] tmpArray;
                string AllTriesWithSpace="",Pname="";
                tmpArray = Filelines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for(int k = 0; k < tmpArray.Length; k++)
                {
                    if (k == 0)
                        Pname = tmpArray[k];
                    else
                        AllTriesWithSpace += " "+tmpArray[k];
                }
                PlayersList.Add(new PlayersData()
                    .AddPName(Pname)
                    .AddPTries(AllTriesWithSpace));
            }
        }
        void FoundEverything()
        {
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13
            , pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24};
            bool flag = true;
            for(int i = 0; i < 24; i++)
            {
                if(boxes[i].Enabled == true)
                {
                    flag = false;
                }
            }
            if (flag)
            {
                TotalTime.Stop();
                pictureBox25.Enabled = true;
                EnableDisableButtons("Enable");
                bool foundplayer=false;
                for(int i = 0; i < PlayersList.Count; i++) {
                    if (PlayersList[i].PName == textBox1.Text)
                    {
                        PlayersList[i].AddTrie(" "+tries.ToString());
                        foundplayer = true;
                    }
                }
                if (foundplayer)
                {
                    UpdateFile();
                }
                else
                {
                    PlayersList.Add(new PlayersData()
                    .AddPName(textBox1.Text)
                    .AddPTries((" "+tries.ToString())));
                    UpdateFile();
                }
                textBox1.Enabled = true;
                MessageBox.Show("Game is over everything is matched" + Environment.NewLine + "Total time to complete: " + Ttime+" seconds" + Environment.NewLine + "Total tries to complete: " + tries);
            }
        }
        void ChangeBackground()
        {
            ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string imagepath = ofd.FileName;
                try
                {
                    Image Newimage = new Bitmap(@imagepath);
                    this.BackgroundImage = Newimage;
                }
                catch (System.ArgumentException)
                {
                    MessageBox.Show("The file given is not an image","Error");
                }
            }
        }
        void ChangeCursor(string CurPath)
        {
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13
            , pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24};
            if (CurPath == "fishhook.ico")
            {
                try
                {
                    Cursor myCursor = new Cursor(CurPath);
                    for (int i = 0; i < boxes.Length; i++)
                    {
                        boxes[i].Cursor = myCursor;
                    }
                }
                catch (System.IO.FileNotFoundException){}
            }
            else
            {
                ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CurPath = ofd.FileName;
                    try
                    {
                        Cursor myCursor = new Cursor(CurPath);
                        for (int i = 0; i < boxes.Length; i++)
                        {
                            boxes[i].Cursor = myCursor;
                        }
                    }
                    catch (System.ArgumentException)
                    {
                        MessageBox.Show("The file given is not an .ico image", "Error");
                    }
                }
            }
        }
        void IfTheyMatch()
        {
            if(pbList.Count == 2)
            {
                if(!(pbList[0].Name == pbList[1].Name))
                {
                    for(int i = 0; i < 100000000; i++) { }
                    pbList[0].BackgroundImage = pbList[0].Image;
                    pbList[0].Image = Properties.Resources.Screenshot_5;
                    pbList[1].BackgroundImage = pbList[1].Image;
                    pbList[1].Image = Properties.Resources.Screenshot_5;
                    pbList[0].Enabled = true;
                    pbList[1].Enabled = true;
                }
                tries++;
                label4.Text = tries.ToString();
                pbList.Clear();
                FoundEverything();
            }
        }
        void loadPics(string action)
        {
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13
            , pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24};
            List<int> check = new List<int>();
            int randompicturebox;
            string[] CommonPicturesArray = new string[12];
            if(action == "Default")
            {
                for(int i = 0; i < 12; i++)
                {
                    CommonPicturesArray[i] = "fishesPic\\" + PicturesArray[i];
                }
            }
            else
            {
                int index = 0;
                foreach (UserImages NewIm in ImagesList)
                {
                    if (NewIm.IsImage == true)
                    {
                        CommonPicturesArray[index] = NewIm.DirPath+"\\"+NewIm.ImageName;
                        index++;
                    }
                    
                }
            }
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    do
                    {
                        Random rnd = new Random();
                        randompicturebox = rnd.Next(boxes.Length);

                    } while (check.Contains(randompicturebox));
                        check.Add(randompicturebox);
                    try
                    {
                        boxes[randompicturebox].BackgroundImage = Image.FromFile(@CommonPicturesArray[i]);
                        boxes[randompicturebox].Name = PicturesArray[i];
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        MessageBox.Show("Missing photo from folder,"+CommonPicturesArray[i], "WARNING"); 
                    }
                    
                }

            }

        }
        void UpdateNewPictures(string path)
        {
            if(path != " ")
            {
                ImagesList = new List<UserImages>();
                string[] FilesInDir = Directory.GetFiles(@path);
                for(int i = 0; i < FilesInDir.Length; i++)
                {
                    bool isIm;
                    string fname = Path.GetFileName(FilesInDir[i]);
                    if (FilesInDir[i].EndsWith(".png")|| FilesInDir[i].EndsWith(".jpg") || FilesInDir[i].EndsWith(".gif") || FilesInDir[i].EndsWith(".jpg") || FilesInDir[i].EndsWith(".jpeg") || FilesInDir[i].EndsWith(".bmp") || FilesInDir[i].EndsWith(".wmf"))//picturebox acceptable formats for images
                    {
                        isIm = true;
                    }
                    else
                    {
                        isIm = false;
                    }
                    ImagesList.Add(new UserImages()
                               .addDirPath(path)
                               .AddImageName(fname)
                               .AddIsImage(isIm));

                }
                int counter=0;
                foreach (UserImages NewIm in ImagesList)
                {
                    if (NewIm.IsImage == true)
                        counter++;
                } 
                if(counter == 12)
                {
                    UsingImagesFrom = "UserPics";
                    loadPics("UserPics");
                }
                else
                {
                    MessageBox.Show("File must contain 12 images", "Error");
                }
            }

        }
        void DirectoryPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            DialogResult result = fbd.ShowDialog();
            string resultPath =" ";
            if (result == DialogResult.OK)
            {
                resultPath = fbd.SelectedPath;
            }
            UpdateNewPictures(resultPath);
        }
        void DisableEnable(string action)
        {
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13
            , pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24};
            for (int i = 0; i < 24; i++)
            {
                if (action == "Enable")
                {
                    boxes[i].Enabled = true;
                }
                else
                {
                    boxes[i].Enabled = false;
                }
            }
        }
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisableEnable("Disable");
            string path = "PlayerTries.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            InitializeFileData();
            ChangeCursor("fishhook.ico");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var picbox = (PictureBox)sender;
            picbox.Image = picbox.BackgroundImage;
            picbox.BackgroundImage = Properties.Resources.Screenshot_5;
            pbList.Add(picbox);
            picbox.Enabled = false;
            IfTheyMatch();
        }

        private void TotalTime_Tick(object sender, EventArgs e)
        {
            Ttime += 1;
            label2.Text = Ttime.ToString();
        }
        void CoverTheAnswer()
        {
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13
            , pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19, pictureBox20, pictureBox21, pictureBox22, pictureBox23, pictureBox24};
            for(int i = 0; i < 24; i++)
            {
                boxes[i].Image = Properties.Resources.Screenshot_5;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeBackground();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.sea;
            UsingImagesFrom = "Default";
            loadPics("Default");
            ChangeCursor("fishhook.ico");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryPath();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            TotalTime.Stop();
            textBox1.Enabled = true;
            Ttime = 0;
            tries = 0;
            label4.Text = tries.ToString();
            label2.Text = Ttime.ToString();
            EnableDisableButtons("Enable");
            CoverTheAnswer();
            loadPics(UsingImagesFrom);
            DisableEnable("Disable");
            pictureBox25.Enabled = true;
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(PlayersList);
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeCursor(" ");
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                Ttime = 0;
                tries = 0;
                label4.Text = tries.ToString();
                label2.Text = Ttime.ToString();
                CoverTheAnswer();
                TotalTime.Start();
                DisableEnable("Enable");
                pictureBox25.Enabled = false;
                textBox1.Enabled = false;
                loadPics(UsingImagesFrom);
                EnableDisableButtons("Disable");
            }
            else
            {
                MessageBox.Show("Please give a Player name!!", "Cant start the game");
            }
        }
    }
}
