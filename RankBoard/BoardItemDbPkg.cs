using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankBoard
{
    [Serializable]
    internal class BoardItemDbPkg
    {
        public Image image { get; set; }
        public String text { get; set; }
        public Font Font { get; set; }
        public BoardItemDbPkg(Image image, string text, Font font)
        {
            this.image = image;
            this.text = text;
            Font = font;
        }
    }
}
