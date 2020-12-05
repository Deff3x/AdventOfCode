using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC {
    [AOCAttribute(5)]
    public class DayFive : BaseAOC {
		public override void Run() {
			var lstSeatIds = new List<int>();

			foreach (var pass in this.input) {
				var row = GetMin(pass.Substring(0, pass.Length - 3), 0, 127, 'F');
				var clm = GetMin(pass.Substring(pass.Length - 3), 0, 7, 'L');				
				lstSeatIds.Add((row * 8) + clm);
			}
			
			System.Console.WriteLine("Part 1: " + lstSeatIds.Max());

			for (int i = lstSeatIds.Min(); i < lstSeatIds.Max(); i++) {
				if (lstSeatIds.Contains(i))
					continue;

				System.Console.WriteLine("Part 2: " + i);
			}
		}

		public int GetMin(string pass, int min, int max, char look) {
			int iCurMin = min, iCurMax = max;
			for (int i = 0; i < pass.Length; i++) {
				iCurMin = pass[i] == look ? iCurMin : (int)Math.Ceiling((decimal)(iCurMin + iCurMax)/2);
				iCurMax = pass[i] == look ? (int)Math.Floor((decimal)(iCurMin+iCurMax)/2) : iCurMax;
			}
			return iCurMin;
		}
	}
}