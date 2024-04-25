using Antlr4.Runtime;
using Markdown;
namespace Markdown_to_LaTeX;

class Program
{
    static void Main(string[] args)
    {
        string input = """
                       # Head One
                       ## Head Two
                       ### Head Three
                       
                       """;
        input = input.Replace("\t", "    ");
        Console.WriteLine(input);
        
        AntlrInputStream inputStream = new AntlrInputStream(input);
        MarkdownLexer mdLexer = new(inputStream);
        for (var token = mdLexer.NextToken(); token.Type != MarkdownLexer.Eof; token = mdLexer.NextToken())
        {
            Console.WriteLine(token.ToString());
        }
    }
}
