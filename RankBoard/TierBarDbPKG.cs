using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankBoard
{
    [Serializable]
    internal class TierBarDbPKG
    {
        public String textt { get; set; }
        public Color NameBackColor { get; set; }
        public Size size { get; set; }
        public List<BoardItemDbPkg> items = new List<BoardItemDbPkg>();
        public TierBarDbPKG(String textt,Color nameBackColor, Size size, List<BoardItemDbPkg> items)
        {
            this.textt = textt;
            NameBackColor = nameBackColor;
            this.size = size;
            this.items = items;
        }
    }
}
