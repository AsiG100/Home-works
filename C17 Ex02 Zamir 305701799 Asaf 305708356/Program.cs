using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C17_Ex02_Zamir_305701799_Asaf_305708356
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loopRunner = true;
            do
            {
                TicTacToe.displayWelcome();///Display welcome
                Console.WriteLine("Please insert a number to determine the size of the table(or 0 to exit)");
                try ///ask for the size of the table
                {
                    string userSize = Console.ReadLine();
                    int tableSize;
                    bool convertionSucceded = int.TryParse(userSize, out tableSize);

                    if (!convertionSucceded)
                    {
                        throw new InvalidOperationException("Please enter numbers only");
                    } 
                    else if (tableSize < 3 || tableSize > 9) throw new InvalidOperationException("You inserted an invalid number, try again!");

                    char[,] valuesInTable = new char[tableSize, tableSize];///A matrix for the game values
                    TicTacToe.initTable(valuesInTable);///initiate matrix with white spaces
                    Console.Clear();
                    
                    ///single player or multi player
                    Console.WriteLine("Would you like to play against another player (m) or against the computer (s)?");
                    string userDecision = Console.ReadLine();
                    if (userDecision == "s")
                    {
                        TicTacToe.singlePlayer(valuesInTable);
                    }
                    else if (userDecision == "m")
                    {
                        TicTacToe.multiPlayer(valuesInTable);
                    }
                    else
                    {
                        throw new Exception("You should only choose s or m, try again");
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                Console.ReadKey();
                Console.Clear();
            } while(loopRunner);
        }
    }
}



