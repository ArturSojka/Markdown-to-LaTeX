namespace Markdown_to_LaTeX;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1 || args.Length > 2)
        {
            Console.WriteLine("Użycie: MdToLatex in.md [out.tex]");
            return;
        }

        string inputPath = args[0];
        string outputPath = args.Length == 2 ? args[1] : Path.ChangeExtension(inputPath, ".tex");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Nieprawidłowa ścieżka do pliku.");
            return;
        }

        if (!outputPath.EndsWith(".tex", StringComparison.OrdinalIgnoreCase))
        {
            outputPath += ".tex";
        }

        MdConverter mdConverter = new(inputPath, outputPath);
        mdConverter.ConvertToLatex();

        Console.WriteLine($"Wynik zapisano do {outputPath}");
    }
}
