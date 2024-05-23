using System.Text;
using MarkdownParsing;

namespace Markdown_to_LaTeX;

public class MdVisitor : MarkdownBaseVisitor<string?>
{
    public override string? VisitDocument(Markdown.DocumentContext context)
    {
        //Console.WriteLine("document");
        return base.VisitDocument(context);
    }

    public override string? VisitAtxHeading(Markdown.AtxHeadingContext context)
    {
        string? type = VisitHeadingStart(context.headingStart());
        string text = VisitHeadingText(context.headingText());
        if(type is null)
            Console.WriteLine(text);
        else
            Console.WriteLine(type + text + '}');
        return null;
    }

    public override string? VisitHeadingStart(Markdown.HeadingStartContext context)
    {
        int level = context.GetText().Count(c => c == '#');
        return level switch
        {
            1 => "\\section*{",
            2 => "\\subsection*{",
            3 => "\\subsubsection*{",
            4 => "\\paragraph*{",
            5 => "\\subparagraph*{",
            _ => null
        };
    }

    public override string? VisitEmptyHeading(Markdown.EmptyHeadingContext context)
    {
        string? type = VisitHeadingStart(context.headingStart());
        if(type is null)
            Console.WriteLine("");
        else
            Console.WriteLine(type + '}');
        return null;
    }

    public override string VisitHeadingText(Markdown.HeadingTextContext context)
    {
        return context.GetText().ToLatexEscaped();
    }

    public override string? VisitHorizontalLine(Markdown.HorizontalLineContext context)
    {
        Console.WriteLine(@"\begin{center}\rule{\linewidth}{1pt}\end{center}");
        return null;
    }

    private List<List<string>> _tableRows = new();
    private int _tableColumnCount;

    public override string? VisitTable(Markdown.TableContext context)
    {
        StringBuilder latex = new();
        VisitHeaderRow(context.headerRow());
        foreach (var row in context.contentRow())
        {
            VisitContentRow(row);
        }
        latex.Append(@"\begin{table}[H]");
        string beginTabular = VisitSeparatorRow(context.separatorRow());
        latex.Append(beginTabular);
        foreach (var row in _tableRows)
        {
            while(row.Count<_tableColumnCount)
                row.Add(" ");
            latex.Append($"\\hline\n{string.Join(" & ", row)} \\\\\n");
        }
        latex.Append("\\hline\n\\end{tabular}\n");
        latex.Append(@"\end{table}");
        Console.WriteLine(latex.ToString());
        _tableRows = new();
        _tableColumnCount = 0;
        return null;
    }

    public override string VisitSeparatorRow(Markdown.SeparatorRowContext context)
    {
        List<string> centering = new();
        
        foreach (var content in context.separatorContent())
            centering.Add(VisitSeparatorContent(content));
        
        while (centering.Count < _tableColumnCount)
            centering.Add("l");
        
        if (centering.Count > _tableColumnCount)
            _tableColumnCount = centering.Count;
        
        return $"\\begin{{tabular}}{{|{string.Join('|', centering)}|}}\n";
    }

    public override string VisitSeparatorContent(Markdown.SeparatorContentContext context)
    {
        bool l = context.Colon(0) is not null;
        bool r = context.Colon(1) is not null;
        return (l,r) switch
        {
            (true,true) => "c",
            (false,true) => "r",
            (_,_) => "l"
        };
    }

    public override string? VisitHeaderRow(Markdown.HeaderRowContext context)
    {
        List<string> headers = new();
        foreach (var content in context.cellContent())
            headers.Add($"\\textbf{{{VisitCellContent(content)}}}");
        if (headers.Count > _tableColumnCount)
            _tableColumnCount = headers.Count;
        _tableRows.Add(headers);
        return null;
    }

    public override string? VisitContentRow(Markdown.ContentRowContext context)
    {
        List<string> contents = new();
        foreach(var content in context.cellContent())
            contents.Add(VisitCellContent(content));
        if (contents.Count > _tableColumnCount)
            _tableColumnCount = contents.Count;
        _tableRows.Add(contents);
        return null;
    }

    public override string VisitCellContent(Markdown.CellContentContext context)
    {
        return context.GetText().Trim().ToLatexEscaped();
    }

    public override string? VisitFencedCode(Markdown.FencedCodeContext context)
    {
        string text = VisitFencedText(context.fencedText()) ?? "";
        int index = text.IndexOf('\n');
        if (index != -1)
            text = text.Remove(0, index+1);
        string text2 = VisitOptionalText(context.optionalText());
        Console.WriteLine(@"\begin{verbatim}");
        Console.WriteLine(text.TrimEnd());
        if (!text2.Trim().Equals(""))
            Console.WriteLine(text2);
        Console.WriteLine(@"\end{verbatim}");
        return base.VisitFencedCode(context);
    }

    public override string? VisitFencedText(Markdown.FencedTextContext context)
    {
        return context.GetText();
    }

    public override string VisitOptionalText(Markdown.OptionalTextContext context)
    {
        return context.GetText().ToLatexEscaped();
    }

    public override string? VisitImageLine(Markdown.ImageLineContext context)
    {
        string display = VisitDisplayText(context.displayText());
        string image = VisitLinkText(context.linkText());
        string text = VisitOptionalText(context.optionalText());

        Console.WriteLine(@"\begin{figure}[H]");
        Console.WriteLine(@"\centering");
        Console.WriteLine($"\\includegraphics[width=\\linewidth]{{{image}}}");
        Console.WriteLine($"\\caption{{{display}}}");
        Console.WriteLine(@"\end{figure}");
        Console.WriteLine(text);
        return null;
    }

    public override string VisitDisplayText(Markdown.DisplayTextContext context)
    {
        return context.GetText().ToLatexEscaped();
    }

    public override string VisitLinkText(Markdown.LinkTextContext context)
    {
        return context.GetText().ToLatexEscaped();
    }
}