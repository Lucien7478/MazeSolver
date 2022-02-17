using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class BlockObject : PositionObject
    {
        public BlockObject(int posY, int posX) : base(posX, posY) { }

        public string Source { get; set; } = "https://www.pngarts.com/files/1/Wall-Transparent-Image.png";
    }
}
