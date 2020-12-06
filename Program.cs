
using System.Linq;
using AOC;

var asms = System.Reflection.Assembly
    .GetExecutingAssembly()
    .GetTypes()
    .Where(t => string.Equals(t.Namespace, "AOC", System.StringComparison.Ordinal))
    .OrderBy(t => ((AOCAttribute)System.Attribute.GetCustomAttribute(t, typeof(AOCAttribute))).Index)
    .ToArray();

foreach (var asm in asms) {
    var test = System.Activator.CreateInstance(null, asm.FullName);
    var obj = (BaseAOC)test.Unwrap();
    obj.Start();

    System.Console.WriteLine();
}