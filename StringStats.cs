namespace c17_Ex01_4
{
     class StringStats
    {
        public static bool isPalindrom(string i_str)
        {
            bool equal = true;
            int start = 0;
            int end = i_str.Length - 1;
            while (start < end && equal==true)
            {
                equal = i_str[start] == i_str[end];
                start++;
                end--;
            }

            return equal;
        }

        public static float digitsMean(long i_num)
        {
            int sum = 0;
            int res = 0;
            int length = 0;

            while(i_num>0)
            {
                sum += (int)(i_num % 10);
                i_num /= 10;
                length++;
            }
            res = sum / length;
            return res;
        }

        public static int numOfUpperCase(string i_str)
        {
            int count = 0;
            for(int i = 0; i < i_str.Length;i++)
            {
                if(i_str[i]>='A' && i_str[i] <= 'Z')
                {
                    count++;
                }
            }

            return count;
        }

        public static bool isValidInput(string i_str)
        {
            bool hasLetter = false;
            bool hasDigit = false;

            for (int i = 0;i < i_str.Length; i++)
            {
                if((i_str[i]>='a'&& i_str[i] <= 'z' )||( i_str[i]>='A' && i_str[i]<='Z'))
                {
                    hasLetter = true;
                }
                else
                {
                    hasDigit = true;
                }
            }

            if ((hasDigit == true && hasLetter == true) || (hasDigit == false && hasLetter == false))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
