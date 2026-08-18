//Given two strings s and t, return true if t is an anagram of s, and false otherwise.
//An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
//typically using all the original letters exactly once.

class Program
{
    static void Main()
    {
        string s = "check";
        string t = "khecc";

        bool result = IsAnagram(s, t);
        Console.WriteLine($" Result: {result}");
    }

    public static bool IsAnagram(string s, string t)
    {
        //Length check
        if (s.Length != t.Length)
        {
            return false;
        }

        //Init an array to store the frequency of the alphabet
        int[] charCheck = new int[26];

        //Increment a running tally for each ASCII letter found in s
        //and then decrements that same running tally for each letter found in t
        //if they're even, it should come back to 0
        for (int i = 0; i < s.Length; i++)
        {
            charCheck[s[i] - 'a']++;
            charCheck[t[i] - 'a']--;
        }

        //If all values are 0, then they're anagrams, if not, return false
        foreach (int count in charCheck)
        {
            if (count != 0)
            {
                return false;
            }
        }
        return true;
    }
}