using System;
using System.IO;

namespace AOC {
    [AOCAttribute(3)]
	public class DayThree : BaseAOC {
    	public override void Run() {
			string[] input;
            using (var sr = new StreamReader(".\\AOC\\DayThree\\input.txt"))
                input = sr.ReadToEnd().Split("\n");

			int iCurIdx = 3;
			int iTreeCount = 0;
			int iFreeCount = 0;
			long iTotal =1;

			foreach (var t in new int[][]{new int[]{1, 1},new int[]{3, 1},new int[]{5,1},new int[]{7,1},new int[]{1,2}}) {
				iCurIdx = t[0];
				iTreeCount = 0;
				iFreeCount = 0;

				for(int ln = t[1]; ln < input.Length; ln += t[1]) {
					if (input[ln][iCurIdx] == '.') 		iFreeCount++;
					else if (input[ln][iCurIdx] == '#') iTreeCount++;					

					iCurIdx+=t[0];
					if (iCurIdx>input[ln].Length-1) {
						iCurIdx = iCurIdx%input[ln].Length-1;
						System.Console.WriteLine("never ran");
					}
				}
				
				Console.WriteLine("TreeCount[{1}, {2}]: {0}", iTreeCount, t[0], t[1]);
				iTotal *= iTreeCount; 
			}

			Console.WriteLine("[Total]: {0}", iTotal);
		}
    }
}