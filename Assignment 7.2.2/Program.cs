// Given a string s, reverse only all the vowels in the string and return it
//The vowels are 'a', 'e', 'i', 'o', and 'u'
//and they can appear in both lower and upper cases, more than once.

public class Program
{
    public static string ReverseOnlyVowels(string s)
    {
        if (s == null || s.Length <= 1)
        {
            return s;
        }

        //Convert string to char IOT mutate elements in place
        char[] chars = s.ToCharArray();
        //Create two pointers for left and right
        int left = 0;
        int right = chars.Length - 1;

        while (left < right)
        {
            //Advance left pointer if current character is not a vowel
            while (left < right && !IsVowel(chars[left]))
            {
                left++;
            }
            //Advance right pointer if current character is not a vowel
            while (left < right && !IsVowel(chars[right]))
            {
                right--;
            }

            //Swap values if vowel is found
            if (left < right)
            {
                char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;

                left++;
                right--;
            }
        }
        return new string(chars);
    }
    //Vowel check
    private static bool IsVowel(char c)
    {
        return  c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || 
                c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
    }

    //Test
    public static void Main(string[] args)
    {
        string input = "yellow";
        string result = ReverseOnlyVowels(input);
        Console.WriteLine($"Input: \"{input}\" -> Output: \"{result}\"");
    }
}