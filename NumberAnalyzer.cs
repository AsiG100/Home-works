namespace c17_Ex01_1
{
    class NumberAnalyzer
    {
        public static string[] convertToBin(string[] decimals)
        {
            string[] bins = { "", "", "", "" };

            for(int i = 0; i < decimals.Length; i++)
            {
                int num = int.Parse(decimals[i]);
                while(num>0)
                {
                    if(num%2==0)
                    {
                        bins[i] += '0';
                    }
                    else
                    {
                        bins[i] += '1';
                    }
                    num /= 2;
                }
            }

            return bins;
        }
    }
}
