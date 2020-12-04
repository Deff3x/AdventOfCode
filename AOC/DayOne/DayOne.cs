using System;
using System.Diagnostics;
using System.IO;

namespace AOC {
    [AOCAttribute(1)]
    public class DayOne : BaseAOC {
		public override void Run() {
            for (int i = 0; i < input.Length; i++)
            for (int i2 = i; i2 < input.Length; i2++)
            for (int i3 = i2; i3 < input.Length; i3++) {
                if (!int.TryParse(input[i], out int n1) || !int.TryParse(input[i2], out int n2) || !int.TryParse(input[i3], out int n3))
                    continue;

                if (n1 + n2 + n3 != 2020) 
                    continue;

                Console.WriteLine($"{n1} * {n2} * {n3} = {n1*n2*n3}");
                return;
            }
		}
	}
}
