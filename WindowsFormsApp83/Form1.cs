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

namespace WindowsFormsApp83
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Image> fn = new List<Image>();
        
        int syc = 60;
        int dogru = 0;
        int yanlis = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            fn.Add(Properties.Resources.maymun_gunu);
            fn.Add(Properties.Resources.indir);
            fn.Add(Properties.Resources.evrimagaci_org_public_content_media_a189a67fd74c2ff771ce1e0fcba79850);
            fn.Add(Properties.Resources.animal_planet_100_parca_baby_chimp_puzzle_21);
            button1.Visible = false;
            button2.Visible = false;
            label1.Visible = false;
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox)
                {
                    PictureBox gc = (PictureBox)c;
                    gc.Visible = false;
                }
            }
            label2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            label1.Visible = true;
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox)
                {
                    PictureBox gc = (PictureBox)c;
                    gc.Visible = true;
                }
            }
            label2.Visible = true;
            Random r = new Random();
            foreach (Control c in this.Controls)
            {
                if (c is PictureBox)
                {
                    PictureBox gc = (PictureBox)c;
                    gc.Image = (fn[r.Next(fn.Count)]);
                    gc.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = syc.ToString();
            syc--;
            if (syc == -1)
            {
                timer1.Enabled = false;
                MessageBox.Show("Doğru Sayınız : "+dogru.ToString()+"    "+"Yanlış Sayınız: "+yanlis.ToString());
                this.Close();
            }
        }
        static bool karsilastir(PictureBox a, PictureBox b)
        {
            Bitmap b1 = new Bitmap(a.Image);
            Bitmap b2 = new Bitmap(b.Image);
            for (int i = 0; i < a.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    Color c = b1.GetPixel(i, j);
                    Color c2 = b2.GetPixel(i, j);
                    if (c != c2) return false;
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (karsilastir(pictureBox1, pictureBox2))
            {
                dogru++;
            }
            else yanlis++;
            Random r = new Random();
            pictureBox1.Image = pictureBox2.Image;
            pictureBox2.Image = pictureBox3.Image;
            pictureBox3.Image = pictureBox4.Image;
            pictureBox4.Image = pictureBox5.Image;
            int index = r.Next(fn.Count() - 1);
            pictureBox5.Image = (fn[index]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!karsilastir(pictureBox1, pictureBox2))
            {
                dogru++;
            }
            else yanlis++;
            Random r = new Random();
            pictureBox1.Image = pictureBox2.Image;
            pictureBox2.Image = pictureBox3.Image;
            pictureBox3.Image = pictureBox4.Image;
            pictureBox4.Image = pictureBox5.Image;
            int index = r.Next(fn.Count() - 1);
            pictureBox5.Image = (fn[index]);
        }
    }
}
