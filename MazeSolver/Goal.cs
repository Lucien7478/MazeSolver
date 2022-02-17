using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MazeSolver
{
    public class Goal : PositionObject
    {
        public Goal(int posX, int posY) : base(posX, posY) { }

        public String Source { get; set; } = "https://img.icons8.com/ios/452/goal.png";
    }
}