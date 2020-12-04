

using System.Diagnostics;

public abstract class BaseAOC {
	protected string[] input {get; set;}
	protected string RawInput {get; set;}

	public void Start() {
		System.Console.WriteLine("[{0}] Start", this.GetType().Name);
		var sw = new Stopwatch();

		sw.Start();	// start timer to time how long each day takes
		
		// Load in input file, not files
		var filename = $".\\AOC\\{this.GetType().Name}\\input.txt";
		if (System.IO.File.Exists(filename)) {
			using (var sr = new System.IO.StreamReader(filename)) {
				this.RawInput = sr.ReadToEnd();
			    this.input = this.RawInput.Replace("\r", "").Split("\n");		
			}
		}

		Run();
		sw.Stop();

		System.Console.WriteLine("[{0}] Completed - {1}", this.GetType().Name, sw.Elapsed.ToString());
	}

	// public void WriteLine(string format, object? arg0) {
	// 	System.Console.Write("[{0}] ", this.GetType().Name);
	// 	System.Console.WriteLine(format, arg0);
	// }

	public abstract void Run();
}

public class AOCAttribute : System.Attribute {
	public int Index { get; set; }
	public AOCAttribute(int idx)
	{
		this.Index = idx;
	}
}