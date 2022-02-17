using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace MazeSolver
{
    public class PlayerMain : PositionObject
    {
        public PlayerMain(int posX, int posY) : base(posX, posY) { }

        protected Playground playground;
        public Direction Orientation { get; set; }

        public bool PosXMoved { get; set; }
        public bool PosYMoved { get; set; }
        public bool Rotated { get; set; }
        public Visibility PlayerVisible { get; set; } = Visibility.Visible;

        public int Steps { get; set; } = 1;

        private int _degree = 0;

        public int Degree
        {
            get
            {
                switch (Orientation)
                {
                    case Direction.North:
                        _degree = 0;
                        break;
                    case Direction.South:
                        _degree = 180;
                        break;
                    case Direction.East:
                        _degree = 90;
                        break;
                    case Direction.West:
                        _degree = 270;
                        break;
                    default:
                        _degree = 0;
                        break;

                }
                return _degree;
            }
        }

        public async Task MoveForward(int amount)
        {
            Move(amount);
            await Task.Delay(600);
            if (playground != null && playground.CheckState())
                MessageBox.Show("Gewonnen! Steps: " + Steps);
        }

        private void Move(int amount)
        {
            switch (Orientation)
            {
                case Direction.North:
                    this.PosY -= amount;
                    this.PosYMoved = true;
                    this.PosYMoved = false;
                    break;
                case Direction.South:
                    this.PosY += amount;
                    this.PosYMoved = true;
                    this.PosYMoved = false;
                    break;
                case Direction.East:
                    this.PosX += amount;
                    this.PosXMoved = true;
                    this.PosXMoved = false;
                    break;
                case Direction.West:
                    this.PosX -= amount;
                    this.PosXMoved = true;
                    this.PosXMoved = false;
                    break;
            }            
            Steps++;
        }

        public bool CheckNextTileFree()
        {
            Player p = new(PosX, PosY);
            p.Orientation = this.Orientation;
            p.Move(1);
            if (p.PosX >= playground.Columns || p.PosY >= playground.Rows
                || p.PosX < 0 || p.PosY < 0)
                return false;
            foreach(BlockObject blockObject in playground.BlockObjects)
                if (p.Compare(blockObject)) return false;            
            return true;
        }

        public async Task MoveForward() => await this.MoveForward(1);

        public async Task Rotate()
        {
            if ((int)Orientation < 3) this.Orientation++;
            else Orientation = 0;
            Rotated = true;
            Rotated = false;
            OnPropertyChanged("Degree");
            await Task.Delay(600);            
            Steps++;
        }

        public async Task Rotate(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                await Rotate();
            }
        }
    }
}
