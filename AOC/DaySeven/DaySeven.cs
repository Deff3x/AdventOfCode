using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AOC {

	[AOCAttribute(7)]
	public class DaySeven : BaseAOC {
		public override void Run() {
			var regex = new System.Text.RegularExpressions.Regex("(\\d|no) ([A-z ]+) bag(?:s|)(?:, |\\.)");
			var dic = new Dictionary<string, Dictionary<string, int>>();

			// setup becuase cba
			foreach (var ln in input) {
				var matches = regex.Matches(ln);
				var bag = ln.Split("bags contain").First().Trim();
				
				if (!dic.ContainsKey(bag))
					dic.Add(bag, new Dictionary<string, int>());

				foreach (Match match in matches) {
					int.TryParse(match.Groups[1].Value, out int num);

					if (match.Groups[1].Value == "no")
						num = 0;

					dic[bag].Add(match.Groups[2].Value, num);
				}
			}

			var output = FindBags(dic, "shiny gold");
			var output2 = FindBagSum(dic, "shiny gold") - 1;

			System.Console.WriteLine("Part 1: " + output.Distinct().Count());
			System.Console.WriteLine("Part 2: " + output2);
		}

		public int FindBagSum (Dictionary<string, Dictionary<string, int>> dic, string lookingFor) {
			int curSum = 1;
			foreach (var bag in dic.Where(x => x.Key == lookingFor)) 
			foreach (var subBag in bag.Value.Where(x => x.Value != 0)) {
				curSum += subBag.Value * FindBagSum(dic, subBag.Key);
			}
			return curSum;
		}

		public List<string> FindBags(Dictionary<string, Dictionary<string, int>> dic, string lookingFor) {
			var found = new List<string>();
			foreach (var bag2 in dic) {
				if (bag2.Value.ContainsKey(lookingFor)) {
					found.Add(bag2.Key);
					found.AddRange(FindBags(dic, bag2.Key));
				}
			}

			return found;
		}
	}
}