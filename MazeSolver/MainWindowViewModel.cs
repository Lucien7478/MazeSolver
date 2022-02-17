using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MazeSolver
{
    public class MainWindowViewModel : BaseViewModel
    {
        private int _maze = 0;
        public int Maze
        {
            get
            {
                return _maze;
            }
            set
            {
                _maze = value;
                Init();
            }
        }

        public MainWindowViewModel() : base(null)
        {
            this.PlayCommand = new RelayCommand(c => this.Play());
            Init();
        }

        private void Init()
        {
            switch (Maze)
            {
                case 0:
                    InitOne();
                    break;
                case 1:
                    InitTwo();
                    break;
                case 2:
                    InitThree();
                    break;
                case 3:
                    InitFour();
                    break;
                case 4:
                    InitFive();
                    break;
                default:
                    MessageBox.Show("Dieses Labyrinth gibt es nicht!");
                    break;
            }
            this.Playground.Player.Reset = true;
            this.Playground.Player.Reset = false;
        }

        private void InitOne()
        {
            List<BlockObject> blockObjects = new()
            {
                new BlockObject(1, 1),
                new BlockObject(1, 2),
                new BlockObject(1, 3),
                new BlockObject(1, 4),
                new BlockObject(2, 1),
                new BlockObject(3, 0),
                new BlockObject(3, 1),
                new BlockObject(3, 3),
                new BlockObject(4, 3),
            };
            this.Playground = new Playground(5, 5, new Player(0, 4), blockObjects, new Goal(4, 4));
        }

        private void InitTwo()
        {
            this.Playground = new Playground(10, 10, new Player(0, 9), GetBlocks(), new Goal(0, 4));
        }

        private void InitThree()
        {
            this.Playground = new Playground(10, 10, new Player(0, 9), GetBlocks(), new Goal(3, 0));
        }

        private void InitFour()
        {
            this.Playground = new Playground(10, 10, new Player(0, 9), GetBlocks(), new Goal(5, 9));            
        }

        private void InitFive()
        {
            
            this.Playground = new Playground(10, 10, new Player(0, 9), GetBlocks(), new Goal(9, 0));
        }

        private List<BlockObject> GetBlocks()
        {
            return new()
            {
                new BlockObject(0, 2),
                new BlockObject(0, 4),
                new BlockObject(0, 8),
                new BlockObject(1, 2),
                new BlockObject(1, 4),
                new BlockObject(1, 8),
                new BlockObject(2, 2),
                new BlockObject(2, 4),
                new BlockObject(2, 8),
                new BlockObject(3, 0),
                new BlockObject(3, 1),
                new BlockObject(3, 2),
                new BlockObject(3, 4),
                new BlockObject(3, 5),
                new BlockObject(3, 6),
                new BlockObject(3, 7),
                new BlockObject(3, 8),
                new BlockObject(4, 7),
                new BlockObject(4, 8),
                new BlockObject(5, 0),
                new BlockObject(5, 1),
                new BlockObject(5, 2),
                new BlockObject(5, 4),
                new BlockObject(5, 5),
                new BlockObject(5, 7),
                new BlockObject(5, 8),
                new BlockObject(6, 2),
                new BlockObject(6, 4),
                new BlockObject(6, 8),
                new BlockObject(7, 2),
                new BlockObject(7, 4),
                new BlockObject(7, 6),
                new BlockObject(8, 0),
                new BlockObject(8, 1),
                new BlockObject(8, 2),
                new BlockObject(8, 4),
                new BlockObject(8, 6),
                new BlockObject(8, 7),
                new BlockObject(8, 8),
                new BlockObject(8, 9),
                new BlockObject(9, 4),
                new BlockObject(9, 6),
            };
        }

        private void Play()
        {
            this.Init();
            try
            {
                new MazeSolverInterface(this.Playground.Player, this.Playground.Goal).Play();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public RelayCommand PlayCommand { get; set; }

        public Playground Playground { get; set; }
    }
}
