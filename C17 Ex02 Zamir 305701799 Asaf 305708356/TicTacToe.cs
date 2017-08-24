using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex02_Zamir_305701799_Asaf_305708356
{
    class TicTacToe
    {
        public static void drawTable(char[,] io_mat)
        {
            int edgeSize = io_mat.GetLength(0);

            ///The upper area
            for(int i=0;i<edgeSize;i++)
            {
                Console.Write("   {0}", i + 1);
            }
            Console.WriteLine();
            ///The table
            for(int i=0;i<edgeSize;i++)
            {
                Console.Write(i + 1);
                for(int j=0; j<edgeSize;j++)
                {
                    Console.Write("|{0}  ",io_mat[i,j]);
                }
                Console.WriteLine("|");
                Console.Write(" ");
                for (int j = 0; j < edgeSize; j++)
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
        public static void initTable(char[,] io_table)
        {
            int length = io_table.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    io_table[i, j] = ' ';
                }
            }
        }
        // TODO: singleplayer game
        public static void singlePlayer(char[,] i_table)
        {
            bool gameRunning = true;
            int row, col;

            Console.Clear(); ///todo: replace it with the clear from the dll
            Console.WriteLine("The single player game begins, follow the orders in every level\n" +
                              "to quit press 'Q' at any point, press any key to continue");
            Console.Read();

            while (gameRunning)
            {
                Console.Clear();
                drawTable(i_table);
                Console.WriteLine("Please enter the row and the col numbers to place your ");
                row = Console.Read();
                col = Console.Read();

            }
        }
        //TODO: multiplayer game
        public static void multiPlayer(char[,] i_table)
        {

        }
  
    }
}
