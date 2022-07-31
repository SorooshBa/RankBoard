using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RankBoard
{
    [Serializable]
    internal class SRBDB
    {

        public List<TierBarDbPKG> controlsBar=new List<TierBarDbPKG>();
        public List<BoardItemDbPkg> controlsItem=new List<BoardItemDbPkg>();
        public SRBDB(FlowLayoutPanel f1 , FlowLayoutPanel f2)
        {
            for (int i = 0; i < f1.Controls.Count; i++)
            {
                List<BoardItemDbPkg> list = new List<BoardItemDbPkg>();
                TierBar temp = (TierBar)f1.Controls[i];
                for (int j = 0; j < temp.ControlsCount; j++)
                {
                    BoardItem item = (BoardItem)temp.GetControl(j);
                    BoardItemDbPkg boardItemDbPkg = new BoardItemDbPkg(item.Image, item.Textt, item.TextFont);
                    list.Add(boardItemDbPkg);
                }
                controlsBar.Add(new TierBarDbPKG(temp.textt,temp.NameBackColor, temp.Size, list));
            }
            //------------------------
            
            for (int i = 0; i < f2.Controls.Count; i++)
            {
                BoardItem item = (BoardItem)f2.Controls[i];
                BoardItemDbPkg boardItemDbPkg = new BoardItemDbPkg(item.Image, item.Textt, item.TextFont);
                controlsItem.Add(boardItemDbPkg);
            }
        }
    }
}
