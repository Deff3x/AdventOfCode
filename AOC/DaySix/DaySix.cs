using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC {
    [AOCAttribute(6)]
    public class DaySix : BaseAOC {
		public override void Run() {
			Part1();
			Part2();
		}

		public void Part1() {
			var groups = RawInput.Split("\r\n\r\n");
			// var peopleCount = groups.Select(x => x.Split("\r\n").Count()).ToArray<int>();
			var uniqueSum = groups.Sum(x => string.Join("", x.Split("\r\n")).Distinct().Count());
			
			System.Console.WriteLine("Part 1: " + uniqueSum);
		}

		public void Part2() {
			var groups = RawInput.Split("\r\n\r\n");
			var sum1 = 0;
			foreach (var group in groups) {
				var ppl = group.Split("\r\n");
				var dic = new Dictionary<char, int>();
				
				if (ppl.Count() == 1) {
					sum1 += ppl[0].Length;
					continue;
				}

				foreach (var p in ppl) {
					p.Distinct().ToList().ForEach(x => {
						if(dic.ContainsKey(x))
							dic[x]++;
						else
							dic.Add(x, 1);
					});
				}

				sum1 += dic.Where(x => x.Value == ppl.Count()).Count();
			}
			System.Console.WriteLine("Part 2: " + sum1);
		}
	}
}