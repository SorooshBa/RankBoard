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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RankBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BoardItem item = new BoardItem();
            flowLayoutPanel2.Controls.Add(item);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            flowLayoutPanel2.Controls.Remove(pictureBox);
            BoardItem item = new BoardItem();
            flowLayoutPanel2.Controls.Add(item);
            flowLayoutPanel2.Controls.Add(pictureBox);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            flowLayoutPanel1.Controls.Remove(pictureBox);
            TierBar item = new TierBar();
            item.flowLay = flowLayoutPanel1;
            item.Size = new Size(flowLayoutPanel1.Width - 20, 120);
            flowLayoutPanel1.Controls.Add(item);
            flowLayoutPanel1.Controls.Add(pictureBox);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in flowLayoutPanel1.Controls)
                {
                    ((TierBar)item).Size = new Size(flowLayoutPanel1.Width - 20, 140);
                }
            }
            catch
            {

            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "RBFile|*.sb";
            if(sv.ShowDialog() == DialogResult.OK)
            {
                PictureBox picBox1 = pictureBox1;
                PictureBox picBox2 = pictureBox2;
                flowLayoutPanel1.Controls.Remove(picBox2);
                flowLayoutPanel2.Controls.Remove(picBox1);
                IFormatter f = new BinaryFormatter();
                Stream str = new FileStream(sv.FileName, FileMode.Create, FileAccess.Write);
                SRBDB db = new SRBDB(flowLayoutPanel1, flowLayoutPanel2);
                f.Serialize(str, db);
                str.Close();
                flowLayoutPanel1.Controls.Add(picBox2);
                flowLayoutPanel2.Controls.Add(picBox1);
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter= "RBFile|*.sb";
            if(op.ShowDialog()==DialogResult.OK)
            {
                PictureBox pictemp1 = pictureBox1;
                PictureBox pictem2 = pictureBox2;
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                IFormatter formatter = new BinaryFormatter();
                Stream str = new FileStream(op.FileName, FileMode.Open, FileAccess.Read);
                SRBDB db = (SRBDB)formatter.Deserialize(str);
                for (int i = 0; i < db.controlsBar.Count; i++)
                {
                    TierBar temp = new TierBar();
                    temp.textt = db.controlsBar[i].textt;
                    temp.NameBackColor = db.controlsBar[i].NameBackColor;
                    temp.Size = db.controlsBar[i].size;
                    temp.flowLay = flowLayoutPanel1;
                    for (int j = 0; j < db.controlsBar[i].items.Count; j++)
                    {
                        BoardItem boardItem = new BoardItem();
                        boardItem.Image = db.controlsBar[i].items[j].image;
                        boardItem.Textt = db.controlsBar[i].items[j].text;
                        boardItem.Font = db.controlsBar[i].items[j].Font;
                        temp.addControl(boardItem);
                    }
                    flowLayoutPanel1.Controls.Add(temp);
                }
                flowLayoutPanel1.Controls.Add(pictem2);
                for (int i = 0; i < db.controlsItem.Count; i++)
                {
                    BoardItem boardItem = new BoardItem();
                    boardItem.Image = db.controlsItem[i].image;
                    boardItem.Textt = db.controlsItem[i].text;
                    boardItem.Font = db.controlsItem[i].Font;
                    flowLayoutPanel2.Controls.Add(boardItem);
                }
                flowLayoutPanel2.Controls.Add(pictemp1);
                Form1_SizeChanged(null, null);
            }
        }
    }
}
