using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MazeSolver
{
    public class Player : PlayerMain
    {
        public String Source { get; set; } = "https://www.pinclipart.com/picdir/big/560-5603624_fighter-jet-clip-art.png";

        public void SetPlayGround(Playground playground)
        {
            this.playground = playground;
        }       

        public Player(int posX, int posY) : base(posX, posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        public Player() : base(0, 0) { }

        public bool Reset { get; set; }
    }

    public enum Direction : int
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3,
        None = 4,
    }
}
