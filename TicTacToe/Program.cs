using System;

namespace TicTacToe
{
    internal class Program
    {
        private static bool gameIsRunnig = true;
        public static void Main(string[] args)
        {
            Playfield pf = new Playfield();
            char currentPlayer = 'x';
            int currentX;
            int currentY;
            while (gameIsRunnig)
            {
                pf.printPlayfield();
                Console.Write($"Spieler {currentPlayer}, gebe deine Koordinaten X, Y ein: ");
                currentX = Convert.ToInt32(Console.ReadLine());
                currentY =  Convert.ToInt32(Console.ReadLine());
                pf.setValueFromCoodrdinate(currentX-1,currentY-1,currentPlayer);
                if (currentPlayer == 'x') currentPlayer = 'o';
                else currentPlayer = 'x';
                pf.checkGame();
                Console.WriteLine($"Nun ist {currentPlayer} an der Reihe.");
                Console.ReadLine();
            }
        }
    }

    class Playfield
    {
        private char[,] playfield;

        public Playfield()
        {
            playfield = new char[,]
            {
                { '.', '.', '.' },
                { '.', '.', '.' },
                { '.', '.', '.' }
            };
        }

        public char getValueFromCoordinate(int x, int y)
        {
            return playfield[x, y];
        }

        public void setValueFromCoodrdinate(int x, int y, char activeplayer)
        {
            if (playfield[x, y] == '.')
            {
                playfield[x, y] = activeplayer;
            }
            else
            {
                Console.WriteLine("Stelle schon besetzt, Zug verschenkt.");
            }
        }

        public void checkGame()
        {
            if ((playfield[0, 0] == 'x' & playfield[0, 1] == 'x' & playfield[0, 2] == 'x') ||
                (playfield[0, 0] == 'x' & playfield[1, 0] == 'x' & playfield[2, 0] == 'x') ||
                (playfield[0, 0] == 'x' & playfield[1, 1] == 'x' & playfield[2, 2] == 'x'))
            {
                Console.Clear();
                Console.WriteLine("Spieler X gewinnt");
                Console.ReadLine();
                Environment.Exit(1);
            }
            if ((playfield[0, 0] == 'o' & playfield[0, 1] == 'o' & playfield[0, 2] == 'o') ||
                (playfield[0, 0] == 'o' & playfield[1, 0] == 'o' & playfield[2, 0] == 'o') ||
                (playfield[0, 0] == 'o' & playfield[1, 1] == 'o' & playfield[2, 2] == 'o'))
            {
                Console.Clear();
                Console.WriteLine("Spieler O gewinnt");
                Console.ReadLine();
                Environment.Exit(2);
            }
            if ((playfield[0, 0] != '.' & playfield[0, 1] != '.' & playfield[0, 2] != '.') &
                (playfield[0, 0] != '.' & playfield[1, 0] != '.' & playfield[2, 0] != '.') &
                (playfield[0, 0] != '.' & playfield[1, 1] != '.' & playfield[2, 2] != '.'))
            {
                Console.Clear();
                Console.WriteLine("Unentschieden");
                Console.ReadLine();
                Environment.Exit(3);
            }
        }

        public void printPlayfield()
        {
            Console.Clear();
            Console.WriteLine($"{playfield[0,0]} {playfield[1,0]} {playfield[2,0]}");
            Console.WriteLine($"{playfield[0,1]} {playfield[1,1]} {playfield[2,1]}");
            Console.WriteLine($"{playfield[0,2]} {playfield[1,2]} {playfield[2,2]}");
        }
    }
}