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
            for (int i = 0; i < edgeSize; i++)
            {
                Console.Write("   {0}", i + 1);
            }
            Console.WriteLine();
            ///The table
            for (int i = 0; i < edgeSize; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < edgeSize; j++)
                {
                    Console.Write("| {0} ", io_mat[i, j]);
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
                        |     fliped     |
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
            
        }
    
        // multiplayer game
        public static void multiPlayer(char[,] i_table)
        {
            bool gameRunning = true;
            char[] symbols = new char[2];
            int numOfTurns = 0;
            symbols[0] = 'X';
            symbols[1] = 'O';

            Console.Clear();
            while (gameRunning)
            {
                drawTable(i_table);//draws the table
                gameRunning = playerTurn(symbols[numOfTurns % 2], i_table);
                numOfTurns++;
            }

        }

        private static bool playerTurn(char i_symbol, char[,] io_table)
        {
            char row, col;
            int indexRow = 0, indexCol = 0;
            bool isInteger = false;
            bool isInsertable = false;
            do
            {
                Console.WriteLine("The single player game begins, follow the orders in every level\n" +
                                        "to quit press 'Q' at any point, press any key to continue\n");
                Console.ReadKey();
                Console.WriteLine("Please enter the row and the col numbers");
                try
                {
                    row = char.Parse(Console.ReadLine());//cant allow putting only one char
                    col = char.Parse(Console.ReadLine());

                    if (col == 'Q' || row == 'Q')// the player quits the game
                    {
                        return false;
                    }

                    isInteger=int.TryParse(row.ToString(), out indexRow) && int.TryParse(col.ToString(), out indexCol);

                    if (!isInteger)
                    {
                            throw new InvalidOperationException("please enter numbers of rows and cols");
                    }
                    else
                    {
                        isInsertable = TryInsert(i_symbol,ref io_table, indexRow, indexCol);
                        if(!isInsertable)
                        {
                            throw new InvalidOperationException("The is no space in this spot, please try again");
                        }
                    }

                }catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Your input is invalid, please try again");
                }
            } while (!isInteger&&!isInsertable);

            return true;
        } 

        private static bool TryInsert(char symbol,ref char[,] io_table,int row,int col)
        {
            if(io_table[row,col] == ' ')
            {
                io_table[row-1,col-1] = symbol;
            }

            return io_table[row, col] == symbol;
        }
}   }
