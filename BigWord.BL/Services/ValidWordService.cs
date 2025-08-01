namespace BigWord.BL.Services
{
    public class ValidWordService : IValidWordService
    {
        public string GetLongestValidWord(string input)
        {
            string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string longest = "";

            foreach (string word in words)
            {
                if (IsValidWord(word) && word.Length > longest.Length)
                {
                    longest = word;
                }
            }

            return longest;
        }

        private bool IsValidWord(string word)
        {
            if (word.Length < 8) return false;

            bool hasUpper = false, hasLower = false, hasDigit = false;
            HashSet<char> repeatedChar = new HashSet<char>();

            foreach (char c in word)
            {
                if (!char.IsLetterOrDigit(c)) return false;
                if (!repeatedChar.Add(char.ToLower(c))) return false; // Fixed: Use char.ToLower(c) instead of c.ToLower()
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
            }

            return hasUpper && hasLower && hasDigit;
        }
    }
}
