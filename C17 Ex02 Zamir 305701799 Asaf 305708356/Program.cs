using System;
using Ex02.ConsoleUtils;

namespace C17_Ex02
{
    class Program
    {
        public static void Main(String[] args)
        {
            const bool v_gameOn = true;
            while (v_gameOn)
            {
                Screen.Clear();
                TicTacToeUserInterface.displayWelcome(); //Displays welcome to game
                TicTacToeUserInterface.displayMenu(); //Displays game menu and start the game
            }
        }
    }
}
