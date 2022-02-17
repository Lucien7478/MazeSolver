using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MazeSolver
{
    public class Playground : BaseViewModel
    {
        public int Rows { get; set; } = 5;
        public int Columns { get; set; } = 5;
        public Player Player { get; set; }
        public List<BlockObject> BlockObjects { get; set; } = new List<BlockObject>();
        public Goal Goal { get; set; }

        public Playground(int rows, int columns, Player player, Goal goal) : base(null)
        {
            this.Rows = rows;
            this.Columns = columns;
            SetPlayer(player);
            this.Goal = goal;           
        }

        public Playground(int rows, int columns, Player player, 
            List<BlockObject> blockObjects, Goal goal) : base(null)
        {
            this.Rows = rows;
            this.Columns = columns;
            SetPlayer(player);
            this.BlockObjects = blockObjects;
            this.Goal = goal;
        }

        public Playground(Player player) : base(null)
        {
            this.Player = player;
        }

        public Playground(Player player, List<BlockObject> blockObjects, Goal goal) : base(null)
        {
            SetPlayer(player);
            this.BlockObjects = blockObjects;
            this.Goal = goal;
        }

        private void SetPlayer(Player player)
        {            
            this.Player = player;
            player.SetPlayGround(this);
        }

        public bool CheckState()
        {
            if(Player.PosX >= Columns || Player.PosY >= Rows 
                || Player.PosX < 0 || Player.PosY < 0) throw new Exception("Verloren!");
            foreach (BlockObject blockObject in BlockObjects)
            {
                 if (Player.Compare(blockObject)) throw new Exception("Verloren!");
            }
            if (Player.Compare(Goal)) return true;
            return false;
        }
    }
}
