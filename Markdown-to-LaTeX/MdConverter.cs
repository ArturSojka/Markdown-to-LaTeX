using Antlr4.Runtime;
using MarkdownParsing;
namespace Markdown_to_LaTeX;

public class MdConverter
{
    private string InputFilePath { get; }
    private string OutputFilePath { get; }

    public MdConverter(string inputFilePath, string outputFilePath)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
    }

    public void ConvertToLatex()
    {
        MdPreprocessor mdPreprocessor = new(InputFilePath);
        string processedFile = mdPreprocessor.ProcessFile();
        AntlrInputStream inputStream = new(processedFile);
        MarkdownLexer mdLexer = new(inputStream);
        CommonTokenStream tokenStream = new(mdLexer);
        Markdown mdParser = new(tokenStream);

        Markdown.DocumentContext context = mdParser.document();
        using (StreamWriter writer = File.CreateText(OutputFilePath))
        {
            MdVisitor visitor = new(writer.WriteLine);//Console.WriteLine);
            visitor.VisitDocument(context);
        }
    }
}