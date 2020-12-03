

using System.Diagnostics;

public abstract class BaseAOC {
	protected System.Collections.Generic.List<string> input {get; init;}

	public void Start() {
		System.Console.WriteLine("[{0}] Start", this.GetType().Name);
		var sw = new Stopwatch();
		sw.Start();
		Run();
		sw.Stop();

		System.Console.WriteLine("[{0}] Completed - {1}", this.GetType().Name, sw.Elapsed.ToString());
	}
	
	public abstract void Run();
}

public class AOCAttribute : System.Attribute {
	public int Index { get; set; }
	public AOCAttribute(int idx)
	{
		this.Index = idx;
	}
}