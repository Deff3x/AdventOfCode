
using System.Linq;

var asms = System.Reflection.Assembly
    .GetExecutingAssembly()
    .GetTypes()
    .Where(t => string.Equals(t.Namespace, "AOC", System.StringComparison.Ordinal) && !t.FullName.Contains("+<>"))
    .OrderBy(t => ((AOCAttribute)System.Attribute.GetCustomAttribute(t, typeof(AOCAttribute)))?.Index ?? -1)
    .ToArray();

foreach (var asm in asms){
    var test = System.Activator.CreateInstance(null, asm.FullName);
    var obj = (BaseAOC)test.Unwrap();
    obj.Start();

    System.Console.WriteLine();
}