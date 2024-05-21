using Antlr4.Runtime;
using MarkdownParsing;
namespace Markdown_to_LaTeX;

class Program
{
    static void Main(string[] args)
    {
        string file = "przyklad.md";
        MarkdownPreprocessor mdPreprocessor = new(file);
        mdPreprocessor.ProcessFile();
        AntlrFileStream inputStream = new(file);
        MarkdownLexer mdLexer = new(inputStream);
        CommonTokenStream tokenStream = new(mdLexer);
        Markdown mdParser = new(tokenStream);

        Markdown.DocumentContext context = mdParser.document();

        MdVisitor visitor = new();
        Console.WriteLine("""
                          \documentclass{article}
                          \usepackage[polish]{babel}
                          \usepackage[utf8]{inputenc}
                          \usepackage[T1]{fontenc}
                          \usepackage{graphicx}
                          \usepackage{float}
                          
                          """);
        Console.WriteLine(@"\begin{document}");
        visitor.VisitDocument(context);
        Console.WriteLine(@"\end{document}");
    }
}
