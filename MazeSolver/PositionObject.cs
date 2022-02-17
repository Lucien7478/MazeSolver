using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver
{
    public class PositionObject : BaseViewModel
    {

        public PositionObject(int posX, int posY) : base(null)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        public int PosX { get; set; }
        public int PosY { get; set; }

        public bool Compare(PositionObject positionObject) =>
            positionObject.PosY == PosY && positionObject.PosX == PosX;
    }
}