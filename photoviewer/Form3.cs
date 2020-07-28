using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photoviewer
{
    public partial class Form3 : Form
    {
        data data = new data();
        public Form3()
        {
            InitializeComponent();
            
        }
        string picname;
        string descriptionpic;
        public void get_values_of_variables()
        {
            picname = textBox1.Text;
            descriptionpic = textBox2.Text;
            data = new data(picname, descriptionpic);
        }
        private void button1_Click(object sender, EventArgs e)//save button
        {
            get_values_of_variables();
            if (textBox1.Text != "")
            {
                data.add(picname,descriptionpic);
                MessageBox.Show("Data saved");
                this.Close();
            }
            else
            {
                MessageBox.Show("Choose image");
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter= "JPG Files(*.jpg) | *.jpg| PNG Files(*.png) | *.png | JPEG Files (*.jpeg) | *.jpeg";
            dialog.InitialDirectory = @"C:\";
            dialog.Title = "Please select an image file to encrypt.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string title_image = dialog.FileName;
                string title2_image = @Path.GetFileNameWithoutExtension(title_image)+"2"+Path.GetExtension(title_image);
                string sourcepath = @Path.GetDirectoryName(title_image).ToString();
                string targetpath = Application.StartupPath;
                string sourcefile = Path.Combine(sourcepath, title_image);
                string destfile = Path.Combine(targetpath, title2_image);
                File.Copy(sourcefile, destfile, true);
                textBox1.Text = destfile;
            }
        }
    }
}
