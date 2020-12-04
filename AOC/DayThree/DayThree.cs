using System;
using System.IO;

namespace AOC {
    [AOCAttribute(3)]
	public class DayThree : BaseAOC {
    	public override void Run() {
			string[] bigMap = new string[input.Length];
			for (int i =0; i < input.Length; i++) {
				bigMap[i] = string.Concat(System.Linq.Enumerable.Repeat(input[i], 50));
			}

			int iCurIdx = 3;
			int iTreeCount = 0;
			int iFreeCount = 0;
			long iTotal =1;

			foreach (var t in new int[][]{new int[]{1, 1},new int[]{3, 1},new int[]{5,1},new int[]{7,1},new int[]{1,2}}) {
				iCurIdx = t[0];
				iTreeCount = 0;
				iFreeCount = 0;

				for(int ln = t[1]; ln < bigMap.Length; ln += t[1]) {
					if (bigMap[ln][iCurIdx] == '.') 		iFreeCount++;
					else if (bigMap[ln][iCurIdx] == '#') iTreeCount++;					

					iCurIdx += t[0];

					if (iCurIdx >= input[ln].Length)
						iCurIdx -= input[ln].Length;
				}
				
				Console.WriteLine("TreeCount[{1}, {2}]: {0}", iTreeCount, t[0], t[1]);
				iTotal *= iTreeCount; 
			}

			Console.WriteLine("[Total]: {0}", iTotal);

      	}

    }
}