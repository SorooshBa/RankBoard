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
    public partial class TierBar : UserControl
    {
        public TierBar()
        {
            InitializeComponent();
            
        }
        public Color NameBackColor { get { return txtTierName.BackColor; } set { txtTierName.BackColor = value; } }
        public FlowLayoutPanel flowLay { get; set; }
        public String textt { get { return txtTierName.Text; } set { txtTierName.Text = value; } }
        public void addControl(Control c)
        {
            flowPanel.Controls.Add(c);
        }
        public void removeControl(Control c)
        {
            flowPanel.Controls.Remove(c);
        }
        public Control GetControl(int Index)
        {
            return flowPanel.Controls[Index];
        }
        public int ControlsCount { get { return flowPanel.Controls.Count; } }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                NameBackColor = colorDialog.Color;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            TierBar tierBar = this;
            flowLay.Controls.Remove(tierBar);
        }

        private void flowPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flowPanel_DragDrop(object sender, DragEventArgs e)
        {
            BoardItem item = (BoardItem)e.Data.GetData(typeof(BoardItem));
            addControl(item);
        }
    }
}
