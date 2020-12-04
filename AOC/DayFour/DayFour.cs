using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AOC {
    [AOCAttribute(4)]
    public class DayFour : BaseAOC {
		public override void Run() {
			string[] reqFields = new string[] {
				"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" //, "cid"
			};

			var lns = RawInput.Split("\r\n\r\n");
			var failureCount = 0;

			foreach (var ln in lns) {
				var ttet = System.Text.RegularExpressions.Regex.Replace(ln, @"\r\n?|\n|\s+", " ").Split(" ");
				var fields = new Dictionary<string, string>(ttet.Select(x => new KeyValuePair<string, string>(x.Split(":").First(), x.Split(":").Last())));

				foreach (var field in reqFields) {
					if (!fields.ContainsKey(field)) {
						failureCount++;
						break;
					}
                    
                    var val = fields[field];
                    var fail= false;

                    switch (field) {
                        case "byr":
                            if (int.TryParse(val, out int year1)) {
                                if (year1 < 1920 || year1 > 2002)
                                    fail = true;
                            } else 
                                fail = true;
                            break;
                        
                        case "iyr":                            
                            if (int.TryParse(val, out int year2)) {
                                if (year2 < 2010 || year2 > 2020)
                                    fail = true;
                            } else 
                                fail = true;
                            break;

                        case "eyr":
                           if (int.TryParse(val, out int year3)) {
                                if (year3 < 2020 || year3 > 2030)
                                    fail = true;
                            } else 
                                fail = true;
                            break;

                         case "hgt":
                            if (int.TryParse(val.Substring(0, val.Length - 2), out int id)){
                                if (val.EndsWith("in")) {
                                    if (id < 59 || id > 76)
                                        fail = true;
                                } else if (val.EndsWith("cm")) {
                                    if (id < 150 || id > 193)
                                        fail = true;
                                } else 
                                 fail = true;
                            } else 
                                fail = true;

                            break;

                        case "hcl":
                            if (val[0] != '#' || val.Length != 7)
                                fail = true;
                            if (!Int32.TryParse(val.Substring(1, val.Length - 1), System.Globalization.NumberStyles.HexNumber, null, out int _))
                                fail = true;
                            break;
                        
                         case "ecl":
                            if (!"amb,blu,brn,gry,grn,hzl,oth".Contains(val))
                                fail = true;
                            break;

                        case "pid":
                            if (val.Length != 9 || !int.TryParse(val, out int _)) fail = true;
                            break;
                        // cid (Country ID) - ignored, missing or not.
                    }

                    if (fail) {
                        failureCount++;
                        break;
                    }
				}
			}
            Console.WriteLine("valid: {0}", lns.Length - failureCount);
		}
	}
}