namespace c17_Ex01_4
{
    class Program
    {
        public static void Main()
        {
            //checks if it's a palindrom
            System.Console.WriteLine("Please enter a string with 10 digits");
            string input = "";

            do // a loop until the user gives a valid string
            {
                try
                {
                    input = System.Console.ReadLine();
                    if (input.Length != 10 || !StringStats.isValidInput(input))
                    {
                        throw new System.Exception("The input is not valid");
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            } while (input.Length != 10||!StringStats.isValidInput(input));

            if (StringStats.isPalindrom(input)) //checks if the string is a palindrom
            {
                System.Console.WriteLine("The string is a palindrom");
            }
            else
            {
                System.Console.WriteLine("The string isn't a palindrom");
            }

            long num = 0;
            if (long.TryParse(input,out num))
            {
                System.Console.WriteLine("The mean is {0}",StringStats.digitsMean(num));
            }
            else
            {
                System.Console.WriteLine("The number of uppercase letters is {0}",StringStats.numOfUpperCase(input));
            }
               
            

            //keeps the console open until the user presses a key
            System.Console.ReadLine();
        }
    }
}
