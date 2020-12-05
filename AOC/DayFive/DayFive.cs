using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AOC {
    [AOCAttribute(5)]
    public class DayFive : BaseAOC {
		public override void Run() {
			var highest = 0;
			var lstSeatIds = new List<int>();
			foreach (var pass in this.input) {
				var row = GetRow(pass.Substring(0, pass.Length - 3));
				var clm = GetSeat(pass.Substring(pass.Length - 3));
				var total = (row*8) + clm;

				lstSeatIds.Add(total);

				if (total > highest)
					highest = total;

				Console.WriteLine("{0}: row: {1}, column: {2}, seat ID: {3}", pass, row, clm, total);
			}

			for (int i = lstSeatIds.Min(); i < lstSeatIds.Max(); i++) {
				if (lstSeatIds.Contains(i))
					continue;

				System.Console.WriteLine("Part 2: " + i);
			}

			System.Console.WriteLine("Part 1: " + highest);
		}

		public int GetRow(string pass) {
			int iCurMin = 0, iCurMax = 127;
			for (int i = 0; i < pass.Length; i++) {
				iCurMin = pass[i] == 'F' ? iCurMin : (int)Math.Ceiling((decimal)(iCurMin+iCurMax)/2);
				iCurMax = pass[i] == 'F' ? (int)Math.Floor((decimal)(iCurMin+iCurMax)/2) : iCurMax;
			}
			return iCurMin;
		}

		public int GetSeat(string pass) {
			int iCurMin = 0, iCurMax = 7;
			for (int i = 0; i < pass.Length; i++) {
				iCurMin = pass[i] == 'L' ? iCurMin : (int)Math.Ceiling((decimal)(iCurMin+iCurMax)/2);
				iCurMax = pass[i] == 'L' ? (int)Math.Floor((decimal)(iCurMin+iCurMax)/2) : iCurMax;
			}
			return iCurMax;
		}

	}
}