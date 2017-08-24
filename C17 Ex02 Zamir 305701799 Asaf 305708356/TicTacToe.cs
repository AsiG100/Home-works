using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex02_Zamir_305701799_Asaf_305708356
{
    class TicTacToe
    {
        public static void drawTable(int size,char [,] mat)
        {
            ///The upper area
            for(int i=0;i<size;i++)
            {
                Console.Write("   {0}", i + 1);
            }
            Console.WriteLine();
            ///The table
            for(int i=0;i<size;i++)
            {
                Console.Write(i + 1);
                for(int j=0; j<size;j++)
                {
                    Console.Write("|{0}  ",mat[i,j]);
                }
                Console.WriteLine("|");
                Console.Write(" ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write("====");
                }
                Console.WriteLine("=");
            }
        }

        public static void displayWelcome()
        {
            Console.Write(@"
                        ==================
                        | Welcome to the |
                        |  up side down  |
                        |  Tic Tac Toe   |
                        ==================");
            Console.WriteLine("\n");
        }
        public static void initTable(char[,] table)
        {
            int length = table.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    table[i, j] = ' ';
                }
            }
        }
        // TODO: singleplayer game
        public static void singlePlayer(char[,] table)
        {

        }
        //TODO: multiplayer game
        public static void multiPlayer(char[,] table)
        {

        }
  
    }
}
