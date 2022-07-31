using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RankBoard
{
    [Serializable]
    public partial class BoardItem : UserControl
    {
        public BoardItem()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrl_MouseDown);
        }
        public Image Image { get { return pictureBox1.Image; } set { pictureBox1.Image = value; } }
        public String ImageLocation { get { return pictureBox1.ImageLocation; } set { pictureBox1.ImageLocation = value; } }
        public Font TextFont { get { return label1.Font; } set { label1.Font = value; } }
        public PictureBox pictureBox { get { return pictureBox1; } }
        public String Textt { get { return label1.Text; } set { label1.Text = value; } }
        private void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).DoDragDrop(this, DragDropEffects.Move);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = true;
            textBox1.Text= label1.Text;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label1.Text=textBox1.Text;
            textBox1.Visible = false;
            label1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter= "Image Files| *.jpg; *.jpeg; *.png; *.gif; *.tif; ";
            if(op.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = op.FileName;
            }
        }
    }
}
