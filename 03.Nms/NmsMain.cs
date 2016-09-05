namespace _03.Nms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class NmsMain
    {
        private const string End = "---NMS SEND---";
        private const char LowestChar = '@';

        private static readonly List<string> Words = new List<string>();

        public static void Main()
        {
            var entireText = new StringBuilder();
            var inlutLine = Console.ReadLine();
            while (inlutLine != End)
            {
                entireText.Append(inlutLine);
                inlutLine = Console.ReadLine();
            }
            
            ExtractWords(entireText.ToString());

            var delimeter = Console.ReadLine();
            Console.WriteLine(string.Join(delimeter, Words));
        }

        private static void ExtractWords(string text)
         {
            var currentChar = LowestChar;
            var container = new StringBuilder();
            foreach (var letter in text)
            {
                if (char.ToLower(currentChar) == char.ToLower(letter) || char.ToLower(letter) >= char.ToLower(currentChar))
                {
                    currentChar = letter;
                    container.Append(currentChar);
                }
                else
                {
                    Words.Add(container.ToString());

                    currentChar = letter;
                    container.Clear();
                    container.Append(currentChar);
                }
            }

            if (container.Length > 0)
            {
                Words.Add(container.ToString());
            }
        }
    }
}