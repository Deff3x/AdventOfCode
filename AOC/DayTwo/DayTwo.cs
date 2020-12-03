using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace AOC {
    [AOCAttribute(2)]
    public class DayTwo : BaseAOC {
		public override void Run() {
            string[] input;
            using (var sr = new StreamReader(".\\AOC\\DayTwo\\input.txt"))
                input = sr.ReadToEnd().Split("\n");
            
            var expr = new Regex("([0-9]+)-([0-9]+) ([A-z]+): (.*)");

            int iCount = 0;
            foreach (var ln in input) {
                var match = expr.Match(ln);
                
                if (!int.TryParse(match.Groups[1].Value, out int min) || !int.TryParse(match.Groups[2].Value, out int max))
                    continue;

                var require = match.Groups[3].Value[0];
                var data = match.Groups[4].Value;

                --min;
                --max;

                if ((data[min] == require && data[max] != require)
                    || (data[min] != require && data[max] == require))  
                    iCount++;           
            }

            Console.WriteLine("Valid: " + iCount);
            Console.WriteLine("Incorrect: " + (input.Length - iCount));

		}
    }
}
