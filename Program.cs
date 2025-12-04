using System;
using System.Collections.Generic;
using System.Numerics;

namespace AdvCode2025_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt").Trim();
            var banks = new List<string>();
            foreach (var line in input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
                banks.Add(line.Trim());

            const int picks = 12;
            BigInteger total = 0;

            foreach (var bank in banks)
            {
                int n = bank.Length;
                if (n < picks)
                {
                    Console.WriteLine("Bank too short: " + bank);
                    continue;
                }

                var chosen = new char[picks];
                int start = 0;
                for (int p = 0; p < picks; p++)
                {
                    int end = n - (picks - p); // inclusive upper bound for search start..end
                    char best = '0';
                    int bestIdx = start;
                    for (int i = start; i <= end; i++)
                    {
                        if (bank[i] > best)
                        {
                            best = bank[i];
                            bestIdx = i;
                            if (best == '9') break; // can't beat 9
                        }
                    }
                    chosen[p] = best;
                    start = bestIdx + 1;
                }

                var s = new string(chosen);
                total += BigInteger.Parse(s);
            }

            Console.WriteLine("Total Output Joltage: " + total);
        }
    }
}