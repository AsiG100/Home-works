
namespace c17_Ex01_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter 4 numbers with 4 digits:");
            string[] userInputs = { "", "", "", "" };
            for(int i=0; i < 4; i++)
            {
                try
                {
                    userInputs[i] = System.Console.ReadLine();
                    if (userInputs[i].Length != 4)
                    {
                        i--;
                        throw new System.Exception("");
                    }
                }catch(System.Exception ex)
                {
                    System.Console.WriteLine("We accept only numbers with four digits");
                }
            }

            string[] bins = NumberAnalyzer.convertToBin(userInputs);
            foreach(string str in bins)
            {
                System.Console.Write("{0} , ",str);
            }
            System.Console.ReadLine();
        }
    }
}
