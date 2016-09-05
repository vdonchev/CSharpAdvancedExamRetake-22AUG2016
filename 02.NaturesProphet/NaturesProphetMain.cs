namespace _02.NaturesProphet
{
    using System;
    using System.Linq;

    public static class NaturesProphetMain
    {
        private const string End = "Bloom";

        private static int[][] garden;

        public static void Main()
        {
            var matrixDimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rows = matrixDimensions[0];
            var cols = matrixDimensions[1];

            garden = new int[matrixDimensions.First()][];
            for (int row = 0; row < rows; row++)
            {
                garden[row] = new int[cols];
            }

            var input = Console.ReadLine().Split();
            while (input[0] != End)
            {
                var row = int.Parse(input[0]);
                var col = int.Parse(input[1]);

                for (int colIndex = 0; colIndex < rows; colIndex++)
                {
                    garden[row][colIndex]++;
                }

                for (int rowIndex = 0; rowIndex < cols; rowIndex++)
                {
                    if (rowIndex == row)
                    {
                        continue;
                    }

                    garden[rowIndex][col]++;
                }

                input = Console.ReadLine().Split();
            }
            
            ShowGarden();
        }

        private static void ShowGarden()
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", garden[row]));
            }
        }
    }
}