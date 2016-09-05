namespace _01.SecondNature
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SecondNatureMain
    {
        private static readonly List<int> SecondNatureFlowers = new List<int>();

        public static void Main()
        {
            var flowers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var buckets = new Stack<int>(Console.ReadLine()
                .Split(' ')
                .Select(int.Parse));

            var index = 0;
            while (buckets.Any() && index < flowers.Count)
            {
                var currentBucket = buckets.Peek();
                var currentFlower = flowers[index];

                if (currentBucket == currentFlower)
                {
                    SecondNatureFlowers.Add(currentFlower);
                    buckets.Pop();
                    flowers[index] = 0;
                    index++;
                }
                else
                {
                    flowers[index] -= currentBucket;
                    if (flowers[index] <= 0)
                    {
                        flowers[index] = 0;
                        index++;

                        var remainingWater = buckets.Pop() - currentFlower;
                        if (buckets.Any())
                        {
                            remainingWater += buckets.Pop();
                        }

                        buckets.Push(remainingWater);
                        continue;
                    }

                    buckets.Pop();
                }
            }

            Console.WriteLine(buckets.Any() ? string.Join(" ", buckets) : string.Join(" ", flowers.Where(f => f > 0)));
            Console.WriteLine(SecondNatureFlowers.Any() ? string.Join(" ", SecondNatureFlowers) : "None");
        }
    }
}