using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace MazeSolver
{
    public class MazeSolverInterface
    {
        private PlayerMain Player { get; set; }
        private PositionObject Goal { get; set; }

        public MazeSolverInterface(PlayerMain player, PositionObject goal)
        {
            this.Goal = goal;
            this.Player = player;
        }

        //Schreibe deinen Quellcode IN den try{ } Block! Es ist gewünscht, dass du weitere Methoden schreibst.
        //Diese aber auch nur im try-Block aufrufen! Um await nutzen zu können müssen deine Methoden async sein (siehe Beispiel())
        //Das mehrmalige Drücken des Spielen Knopfes stellt die Position des Flugzeugs wieder her und führt deinen Quellcode noch einmal aus.
        // Bitte nur folgende Methoden nutzen:
        //await Player.Rotate ==> Rotation um 90 Grad im Uhrzeigersinn
        //await Player.Rotate(int steps) ==> Rotation um 90 Grad im Uhrzeigersinn ==> steps -> wie oft auf einmal gedreht werden soll
        //await Player.MoveForward => Läuft eine Zelle weiter
        //Player.MoveForward(int steps) => Läuft um "steps" Zellen weiter
        //Player.CheckNextTileFree() => Prüft ob die nächste Zelle frei ist
        //Goal.PosX ==> X-Position des Ziels
        //Goal.PosY ==> Y-Position des Ziels
        //Player.PosX ==> X-Position des Spielers
        //Player.PosY ==> Y-Position des Spielers       
        public async void Play()
        {
            try
            {
                await Player.Rotate();
                Beispiel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private async void Beispiel()
        {
            await Player.MoveForward();
        }
    }
}