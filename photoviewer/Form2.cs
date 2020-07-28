using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photoviewer
{
    public partial class Form2 : Form
    {
        int k;
        public Form2(List<string> imagedata)
        {
            InitializeComponent();
            this.imagedata = imagedata;
            k = imagedata.Count;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        int i = 0;
        private List<string> imagedata;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == k)
            {
                timer1.Stop();
            }
            else if (i < k)
            {
                pictureBox1.ImageLocation = imagedata[i];
                i++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
