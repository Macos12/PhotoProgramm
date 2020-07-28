using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;

namespace photoviewer
{
    public partial class Form1 : Form
    {
        data add;
        OleDbConnection connection = new OleDbConnection();
        Boolean a,b,c;
        string value1, value2, nameofpic;
        Image imgoriginal,img1;
        Bitmap sourceBitmap;
        public Form1()
        {
            InitializeComponent();
            add = new data();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=pictures.accdb;Persist Security Info=False;";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            display_data();
            value1 = dataGridView1.Rows[0].Cells[1].Value.ToString();
            nameofpic = value1;
            value2 = dataGridView1.Rows[0].Cells[2].Value.ToString();
            sourceBitmap = new Bitmap(value1);
            dataGridView1.Columns[0].Visible = false;
            pictureBox1.ImageLocation = value1;
            richTextBox1.Text = value2;
            sourceBitmap.Dispose();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)//proboli perigrafis 
        {
            if (b == false)
            {
                richTextBox1.Visible = true;
                b = true;
            }
            else
            {
                richTextBox1.Visible = false;
                b = false;
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)//pataei to menu strip gia na apothikeysi me diaforetiko onoma
        {
            groupBox1.Visible = true;
            textBox1.Text = Path.GetFileNameWithoutExtension(value1);//emfanizei to textbox1 to hdh yparxwn onoma tis eikonas
            textBox2.Text = value2;//emfanizei to description tis eikonas  
        }
        int i = 0;//metritis gia na emfanizei tis eikones
        private void button3_Click(object sender, EventArgs e)//next button
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox2.Visible = false;
            groupBox1.Visible = false;
            pictureBox1.Width = 735;
            pictureBox1.Height = 440;
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                pictureBox1.Width = 1186;
                pictureBox1.Height = 702;
            }
            display_data();
            i++;
            if (i == dataGridView1.Rows.Count - 1)//3ekinaw apo i 0 kai ftanw mexri mia seira parapanw apo thn vash wste na mpei kai stin teleutaia kai meta na paei i=0 ktlp
            {                                    //count-1=4
                i = 0;
            }
            value1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
            nameofpic = value1;
            value2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
            sourceBitmap = new Bitmap(value1);
            pictureBox1.ImageLocation = value1;
            richTextBox1.Text = value2;
            sourceBitmap.Dispose();
        }
        
        private void button1_Click(object sender, EventArgs e)//previous button
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox2.Visible = false;
            groupBox1.Visible = false;
            pictureBox1.Width = 735;
            pictureBox1.Height = 440;
            if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                pictureBox1.Width = 1186;
                pictureBox1.Height = 702;
            }
            display_data();
            //douleuei kala
            i--;
            if (i == -1)
            {
                i = dataGridView1.Rows.Count-2;//count-2=3
            } 
            value1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
            nameofpic = value1;
            value2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
            sourceBitmap = new Bitmap(value1);
            pictureBox1.ImageLocation = value1;
            richTextBox1.Text = value2;
            sourceBitmap.Dispose();
        }
        //aristerostrofi peristrofi
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
            pictureBox1.Refresh();
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            if (System.IO.File.Exists(nameofpic))
                System.IO.File.Delete(nameofpic);
            bmp1.Save(nameofpic);
            bmp1.Dispose();
        }
        //de3iostrofi peristrofi
        private void button4_Click(object sender, EventArgs e)
        {
           
           pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
           pictureBox1.Refresh();
           Bitmap bmp1 = new Bitmap(pictureBox1.Image);
           if (System.IO.File.Exists(nameofpic))
               System.IO.File.Delete(nameofpic);
           bmp1.Save(nameofpic);
           bmp1.Dispose();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (a==false)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;//orizw san streched alla ws zoom gia na fainetai kalytera
                pictureBox1.Width = 709;
                pictureBox1.Height = 499;
                if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
                {
                    pictureBox1.Width = 1186;
                    pictureBox1.Height = 702;
                }
                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;//to megethos ths eikonas me ta filtra
                a = true;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;//orizw san normal alla ws center gia na fainetai kalytera  //*****exei apoepilexthei to checkbox apo streched
                pictureBox1.Width = 709;
                pictureBox1.Height = 499;
                if (this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
                {
                    pictureBox1.Width = 1186;
                    pictureBox1.Height = 702;
                }
                pictureBox2.BackgroundImageLayout = ImageLayout.Center;// to megethos ths eikonas me ta filtra                    //*****
                a = false;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox2.BackgroundImage = pictureBox1.Image.CopyAsGrayscale(); //klisi tis synartisis grayscale pou vrisketai sthn klasi filters
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox2.BackgroundImage = pictureBox1.Image.CopyAsSepiaTone(); //klisi tis synartisis grayscale pou vrisketai sthn klasi filters
        }
        //Update button
        private void button3_Click_1(object sender, EventArgs e)//save button groupbox
        {
            string newimagename = textBox1.Text + Path.GetExtension(value1);
            if (File.Exists(Path.GetFileNameWithoutExtension(newimagename)+Path.GetExtension(newimagename)))
            {
                MessageBox.Show("The name of picture exists.Please try again.");
            }
            else
            {
                connection.Open();
                String query1 = "update Table1 set pictures='" + textBox1.Text + Path.GetExtension(value1) + "',description='" + textBox2.Text + "'where pictures='" + value1 + "'";
                OleDbCommand cmd = new OleDbCommand(query1, connection);
                OleDbDataReader rdr = cmd.ExecuteReader();
                Image sv = pictureBox1.Image;
                sv.Save(newimagename);
                MessageBox.Show("The data saved");
                connection.Close();
                display_data();
                value2 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                richTextBox1.Text = value2;
            }
            
        }
        public void display_data()
        {
            connection.Open();
            String query = "SELECT *FROM Table1";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);
            dataGridView1.DataSource = scores;
            connection.Close();
        }
        List<string> imagedata = new List<string>();//pairnei thn 1h deyterh sthlh me tis eikones vashs gia na thn perasei sthn form2
        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)//koumpi parousiasis
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)//pairnaw thn sthlh pou periexei ta onomata twn eikonwn se lista me skopo na ta perasw sthn forma 2
            {
                imagedata.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
            Form2 f2 =new Form2(imagedata);
            f2.ShowDialog();
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)//proboli mikroterwn eikonwn
        {
            display_data();
            int dias=dataGridView1.Rows.Count - 1;
            if (c == false)
            {
                panel1.Visible = false;
                int k = 30;//a3onas x
                int z = 250;//a3onas y
                int s = 2;
                PictureBox[] Smallpictureboxes = new PictureBox[dias];

                for (int j = 0; j < dias; j++)

                {
                    Smallpictureboxes[j] = new PictureBox();

                    Smallpictureboxes[j].Name = "ItemNum_" + j.ToString();
                    if (s == j)//s==2
                    {
                        Smallpictureboxes[j].Location = new Point(k, z);
                        k = 30;//a3onas x
                        z += 70;//a3onas y
                        s += 3;
                    }
                    else
                    {
                        Smallpictureboxes[j].Location = new Point(k, z);
                        k += 70;
                    }

                    Smallpictureboxes[j].Size = new Size(50, 50);
                    Smallpictureboxes[j].ImageLocation = dataGridView1.Rows[j].Cells[1].Value.ToString();
                    Smallpictureboxes[j].Visible = true;
                    Smallpictureboxes[j].SizeMode = PictureBoxSizeMode.Zoom;
                    this.Controls.Add(Smallpictureboxes[j]);
                }
                c = true;
            }
            else
            {
                panel1.Visible = true;
                c = false;
            }
        }

        int x =0;//voithaei gia to ean exw thn arxikh eikona gia to zoom out 
        int l=0;
        private void button6_Click(object sender, EventArgs e)//zoom in
        {
            if (pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                x++;
                Size newSize = new Size((int)(pictureBox1.Image.Width + 10), (int)(pictureBox1.Image.Height + 10));
                Bitmap bmp = new Bitmap(pictureBox1.Image, newSize);
                pictureBox1.Image = bmp;
            }
            else
            {
                if (this.WindowState == System.Windows.Forms.FormWindowState.Normal)
                {
                    if (pictureBox1.Height <= 585)
                    {
                        pictureBox1.Height += 10;
                        pictureBox1.Width += 10;
                    }
                }
                else if(this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
                {
                    if (pictureBox1.Height <= 850)
                    {
                        l++;
                        pictureBox1.Height += 10;
                        pictureBox1.Height += 10;
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)//zoom out
        {

            if (pictureBox1.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                if (x > 0)
                {
                    x--;
                    Size newSize = new Size((int)(pictureBox1.Image.Width - 10), (int)(pictureBox1.Image.Height - 10));
                    Bitmap bmp = new Bitmap(pictureBox1.Image, newSize);
                    pictureBox1.Image = bmp;
                    
                }
                if (x == 0)
                {
                    pictureBox1.ImageLocation = value1;
                }
            }
            else
            {
                if (this.WindowState == System.Windows.Forms.FormWindowState.Normal)
                {
                    if (pictureBox1.Width > 735)
                    {
                        pictureBox1.Height -= 10;
                        pictureBox1.Width -= 10;
                    }
                }
                else if(this.WindowState == System.Windows.Forms.FormWindowState.Maximized)
                {
                    if (pictureBox1.Height > 702)
                    {
                        l--;
                        pictureBox1.Height -= 10;
                        pictureBox1.Width -= 10;
                    }
                    if (l == 0)
                    {
                        pictureBox1.Width = 1186;
                        pictureBox1.Height = 702;
                        pictureBox1.ImageLocation = value1;
                    }
                }
            }
            
        }
    }
}
