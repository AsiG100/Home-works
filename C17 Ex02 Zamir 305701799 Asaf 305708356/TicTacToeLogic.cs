using System;
using C17_Ex02;
using Ex02.ConsoleUtils;

namespace C17_Ex02
{
    class TicTacToeLogic
    {
        private static readonly char[] symbols = { 'X', 'O' };
        private static int numOfTurns = 0;

        // TODO: singleplayer game
        public static void singlePlayer(char[,] i_table)
        {
            throw new NotImplementedException();
        }

        // multiplayer game
        public static void multiPlayer(char[,] i_table)
        {
            PlayerDetails player1 = new PlayerDetails();
            PlayerDetails player2 = new PlayerDetails();

            player1.PlayerSymbol = symbols[0];
            player2.PlayerSymbol = symbols[1];

            Console.Write("\nFirst player - ");
            TicTacToeUserInterface.inputName(ref player1);
            Console.Write("Second player -");
            TicTacToeUserInterface.inputName(ref player2);

            Console.WriteLine("\n{0} begins, follow the orders in every level\n" +
                              "to quit at any point press 'Q', " +
                              "press 'Enter to start the game!'\n", player1.m_Name);
            Console.ReadKey();
            Screen.Clear();

            bool gameRunning = true;

            while (gameRunning)
            {
                TicTacToeUserInterface.drawTable(i_table);//draws the table
                gameRunning = playerInput(symbols[numOfTurns % 2], i_table,
                              (numOfTurns % 2 == 0) ? player1 : player2);

                if (!gameRunning)
                {
                    Screen.Clear();
                    Console.WriteLine("You left the game, see you soon");
                    return;
                }

                bool isPlayerLost = checkforStraight(i_table, symbols[numOfTurns % 2], numOfTurns);
                numOfTurns++;

                //if player lost or the table is full
                if (isPlayerLost || numOfTurns == i_table.Length)
                {
                    Screen.Clear();
                    TicTacToeUserInterface.drawTable(i_table);
                    break;
                }

                Screen.Clear();
            }
            Screen.Clear();
            TicTacToeUserInterface.drawTable(i_table);
            findWinner(player1, player2, symbols[(numOfTurns+1) % 2]);

            //play again
            Console.WriteLine("\nWould you like to play again?");
            if()
        }
        private static bool playerInput(char i_symbol, char[,] io_table, PlayerDetails player)
            {
                bool isInteger = false;
                bool isInsertable = false;

                Console.WriteLine("{0}, Please make your move", player.m_Name);
                do
                {
                    try
                    {
                        Console.Write("please enter row selection: ");
                        string input1 = Console.ReadLine();
                        if (string.IsNullOrEmpty(input1))
                        {
                            Console.WriteLine("You didn't enter a value!");
                            continue;
                        }
                        char rowInput = char.Parse(input1);

                        Console.Write("Please enter collumn selection: ");
                        string input2 = Console.ReadLine();
                        if (string.IsNullOrEmpty(input2))
                        {
                            Console.WriteLine("You didn't enter a value!");
                            continue;
                        }
                        char colInput = char.Parse(input2);

                        // Checks if player wants to end match 
                        if (colInput == 'Q' || rowInput == 'Q' || colInput == 'q' || rowInput == 'q')
                        {
                            return false;
                        }

                        int indexRow = 0, indexCol = 0;
                        isInteger = int.TryParse(rowInput.ToString(), out indexRow) &&
                                    int.TryParse(colInput.ToString(), out indexCol);

                        if (!isInteger)
                        {
                            throw new InvalidOperationException("please enter numbers of rows and cols");
                        }
                        else
                        {
                            isInsertable = TryInsert(i_symbol, ref io_table, indexRow - 1, indexCol - 1);
                            if (isInsertable == false)
                            {
                                throw new InvalidOperationException("There is no space in this spot, please try again");
                            }
                        }

                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Your input is invalid, please try again");
                    }
                } while (!isInteger || !isInsertable);

                return true;
            }

            private static bool TryInsert(char symbol, ref char[,] io_table, int rowInput, int colInput)
            {
                if (io_table[rowInput, colInput] == ' ')
                {
                    io_table[rowInput, colInput] = symbol;
                }

                return io_table[rowInput, colInput] == symbol;
            }

            private static bool checkforStraight(char[,] io_table, char symbol, int numOfSteps)
            {
                int edgeSize = io_table.GetLength(0);
                bool isStraight = false;
                int matchesCount = 0;

                if (numOfSteps >= (edgeSize * 2 - 2))
                {
                    //Check rows
                    for (int rowIndex = 0; rowIndex < edgeSize && !isStraight; rowIndex++)
                    {
                        matchesCount = 0;
                        for (int colIndex = 0; colIndex < edgeSize; colIndex++)
                        {
                            if (io_table[rowIndex, colIndex] == symbol)
                            {
                                matchesCount++;
                            }
                        }
                        if (edgeSize == matchesCount)
                        {
                            isStraight = true;
                            break;
                        }
                    }
                    //check columns
                    for (int colIndex = 0; colIndex < edgeSize && !isStraight; colIndex++)
                    {
                        matchesCount = 0;
                        for (int rowIndex = 0; rowIndex < edgeSize; rowIndex++)
                        {
                            if (io_table[rowIndex, colIndex] == symbol)
                            {
                                matchesCount++;
                            }
                        }
                        if (edgeSize == matchesCount)
                        {
                            isStraight = true;
                            break;
                        }
                    }
                    //Check first diagonal
                    matchesCount = 0;
                    for (int rowAndColIndex = 0; rowAndColIndex < edgeSize && !isStraight; rowAndColIndex++)
                    {
                        if (io_table[rowAndColIndex, rowAndColIndex] == symbol)
                        {
                            matchesCount++;
                        }
                        isStraight = edgeSize == matchesCount;
                    }
                    //Check second diagonal
                    matchesCount = 0;
                    for (int rowIndex = edgeSize - 1; rowIndex >= 0 && !isStraight; rowIndex--)
                    {
                        int colIndex = (edgeSize - 1) - rowIndex;
                        if (io_table[rowIndex, colIndex] == symbol)
                        {
                            matchesCount++;
                        }
                        isStraight = edgeSize == matchesCount;
                    }

                }
                return isStraight;
            }


        private static void findWinner(PlayerDetails io_player1, PlayerDetails io_player2, char symbol)
        {
            PlayerDetails winner;
            if (io_player1.m_PlayerSymbol == symbol)
            {
                io_player1.m_Points++;
                winner = io_player1;
            }
            else
            {
                io_player2.m_Points++;
                winner = io_player2;
            }

            Console.WriteLine("\n"+
                                "==========================\n"+
                                "    The winner is {0}   \n" + 
                                "==========================", winner.m_Name);
        }
        /*
        private static void playAgain()
        {
            int userChoise;
            bool validInput = true;

            do
            {
                try
                {
                    Console.WriteLine("Would you like to play again?\n1.Yes\n2.No");
                    userChoise = Console.Read();
                    if(userChoise!=2&&userChoise!=1)
                    {
                        throw new Exception("Choose only 1 or 2");
                    }
                    else
                    {
                        validInput = true;
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (validInput);

        } 
        */
    }
        
}

