using MarkdownParsing;

namespace Markdown_to_LaTeX;

public class MdVisitor : MarkdownBaseVisitor<string?>
{
    private Action<string?> WriteLine;
    public override string? VisitDocument(Markdown.DocumentContext context)
    {
        WriteLine("""
                  \documentclass{article}
                  \usepackage[polish]{babel}
                  \usepackage[utf8]{inputenc}
                  \usepackage[T1]{fontenc}
                  \usepackage{graphicx}
                  \usepackage{float}
                  \usepackage{listings}
                  \usepackage{hyperref}

                  """);
        WriteLine(@"\begin{document}");
        base.VisitDocument(context);
        WriteLine(@"\end{document}");
        return null;
    }

    public override string? VisitAtxHeading(Markdown.AtxHeadingContext context)
    {
        string? type = VisitHeadingStart(context.headingStart());
        string text = VisitHeadingText(context.headingText());
        if(type is null)
            WriteLine(text);
        else
            WriteLine(type + text + '}');
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
            WriteLine("");
        else
            WriteLine(type + '}');
        return null;
    }

    public override string? VisitSetextHeading(Markdown.SetextHeadingContext context)
    {
        string type = VisitSetextEnd(context.setextEnd());
        string text = VisitRequiredText(context.requiredText());
        WriteLine(type + text + '}');
        return null;
    }

    public override string VisitSetextEnd(Markdown.SetextEndContext context)
    {
        string t = context.GetText();
        if (t[1] == '=')
            return @"\section*{";
        return @"\subsection*{";
    }

    public override string VisitHeadingText(Markdown.HeadingTextContext context)
    {
        return context.GetText().ToLatexEscaped();
    }

    public override string? VisitHorizontalLine(Markdown.HorizontalLineContext context)
    {
        WriteLine(@"\begin{center}\rule{\linewidth}{1pt}\end{center}");
        WriteLine(null);
        return null;
    }

    private List<List<string>> _tableRows = new();
    private int _tableColumnCount;

    public override string? VisitTable(Markdown.TableContext context)
    {
        VisitHeaderRow(context.headerRow());
        foreach (var row in context.contentRow())
        {
            VisitContentRow(row);
        }
        WriteLine(@"\begin{table}[H]");
        string beginTabular = VisitSeparatorRow(context.separatorRow());
        WriteLine(beginTabular);
        foreach (var row in _tableRows)
        {
            while(row.Count<_tableColumnCount)
                row.Add(" ");
            WriteLine($"\\hline\n{string.Join(" & ", row)} \\\\");
        }
        WriteLine("\\hline\n\\end{tabular}");
        WriteLine(@"\end{table}");
        WriteLine(null);
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
        
        return $"\\begin{{tabular}}{{|{string.Join('|', centering)}|}}";
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
        string text = VisitFencedText(context.fencedText());
        int index = text.IndexOf('\n');
        string? lang = null;
        if (index != -1)
        {
            lang = text[..(index + 1)].Trim();
            text = text.Remove(0, index+1);
        }
        string text2 = VisitOptionalText(context.optionalText());
        if (lang is null or "")
            WriteLine(@"\begin{verbatim}");
        else
            WriteLine($"\\begin{{lstlisting}}[language={lang}]");
        WriteLine(text.TrimEnd());
        if (!text2.Trim().Equals(""))
            WriteLine(text2);
        if (lang is null or "")
            WriteLine(@"\end{verbatim}");
        else
            WriteLine(@"\end{lstlisting}");
        return null;
    }

    public override string? VisitIndentedCodeBlock(Markdown.IndentedCodeBlockContext context)
    {
        WriteLine(null);
        WriteLine(@"\begin{verbatim}");
        WriteLine(VisitIndentedCode1(context.indentedCode1(0)));
        for (int i = 1; i < context.indentedCode1().Length; i++)
        {
            if(context.Newline(i) is not null)
                WriteLine(null);
            WriteLine(VisitIndentedCode1(context.indentedCode1(i)));
        }
        WriteLine(@"\end{verbatim}");
        return null;
    }

    public override string VisitIndentedCode1(Markdown.IndentedCode1Context context)
    {
        return VisitCodeText(context.codeText()).Trim();
    }

    public override string VisitCodeText(Markdown.CodeTextContext context)
    {
        return context.GetText();
    }

    public override string VisitFencedText(Markdown.FencedTextContext context)
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

        WriteLine(@"\begin{figure}[H]");
        WriteLine(@"\centering");
        WriteLine($"\\includegraphics[width=\\linewidth]{{{image}}}");
        WriteLine($"\\caption{{{display}}}");
        WriteLine(@"\end{figure}");
        WriteLine(text);
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

    public override string VisitRequiredText(Markdown.RequiredTextContext context)
    {
        return context.GetText().ToLatexEscaped();
    }

    public override string? VisitList(Markdown.ListContext context)
    {
        if (context.iList0() is not null)
            VisitIList0(context.iList0());
        else
            VisitEList0(context.eList0());
        return null;
    }
    
    public override string? VisitList1(Markdown.List1Context context)
    {
        if (context.iList1() is not null)
            VisitIList1(context.iList1());
        else
            VisitEList1(context.eList1());
        return null;
    }

    public override string? VisitList2(Markdown.List2Context context)
    {
        if (context.iList2() is not null)
            VisitIList2(context.iList2());
        else
            VisitEList2(context.eList2());
        return null;
    }

    public override string? VisitList3(Markdown.List3Context context)
    {
        if (context.iList3() is not null)
            VisitIList3(context.iList3());
        else
            VisitEList3(context.eList3());
        return null;
    }

    public override string? VisitIList0(Markdown.IList0Context context)
    {
        WriteLine(@"\begin{itemize}");
        VisitChildren(context);
        WriteLine(@"\end{itemize}");
        return null;
    }

    public override string? VisitIList1(Markdown.IList1Context context)
    {
        WriteLine(@"\begin{itemize}");
        VisitChildren(context);
        WriteLine(@"\end{itemize}");
        return null;
    }

    public override string? VisitIList2(Markdown.IList2Context context)
    {
        WriteLine(@"\begin{itemize}");
        VisitChildren(context);
        WriteLine(@"\end{itemize}");
        return null;
    }

    public override string? VisitIList3(Markdown.IList3Context context)
    {
        WriteLine(@"\begin{itemize}");
        VisitChildren(context);
        WriteLine(@"\end{itemize}");
        return null;
    }

    public override string? VisitIListItem0(Markdown.IListItem0Context context)
    {
        string item = "";
        if (context.requiredText() is not null)
            item = VisitRequiredText(context.requiredText());
        WriteLine("\\item " + item);
        if (context.list1() is not null)
            VisitList1(context.list1());
        return null;
    }

    public override string? VisitIListItem1(Markdown.IListItem1Context context)
    {
        string item = "";
        if (context.requiredText() is not null)
            item = VisitRequiredText(context.requiredText());
        WriteLine("\\item " + item);
        if (context.list2() is not null)
            VisitList2(context.list2());
        return null;
    }

    public override string? VisitIListItem2(Markdown.IListItem2Context context)
    {
        string item = "";
        if (context.requiredText() is not null)
            item = VisitRequiredText(context.requiredText());
        WriteLine("\\item " + item);
        if (context.list3() is not null)
            VisitList3(context.list3());
        return null;
    }

    public override string? VisitIListItem3(Markdown.IListItem3Context context)
    {
        string item = "";
        if (context.requiredText() is not null)
            item = VisitRequiredText(context.requiredText());
        WriteLine("\\item " + item);
        return null;
    }

    public override string? VisitEList0(Markdown.EList0Context context)
    {
        WriteLine(@"\begin{enumerate}");
        VisitChildren(context);
        WriteLine(@"\end{enumerate}");
        return null;
    }

    public override string? VisitEList1(Markdown.EList1Context context)
    {
        WriteLine(@"\begin{enumerate}");
        VisitChildren(context);
        WriteLine(@"\end{enumerate}");
        return null;
    }

    public override string? VisitEList2(Markdown.EList2Context context)
    {
        WriteLine(@"\begin{enumerate}");
        VisitChildren(context);
        WriteLine(@"\end{enumerate}");
        return null;
    }

    public override string? VisitEList3(Markdown.EList3Context context)
    {
        WriteLine(@"\begin{enumerate}");
        VisitChildren(context);
        WriteLine(@"\end{enumerate}");
        return null;
    }

    public override string? VisitEListItem0(Markdown.EListItem0Context context)
    {
        string item = "";
        if (context.requiredText() is not null)
            item = VisitRequiredText(context.requiredText());
        WriteLine("\\item " + item);
        if (context.list1() is not null)
            VisitList1(context.list1());
        return null;
    }

    public override string? VisitEListItem1(Markdown.EListItem1Context context)
    {
        string item = "";
        if (context.requiredText() is not null)
            item = VisitRequiredText(context.requiredText());
        WriteLine("\\item " + item);
        if (context.list2() is not null)
            VisitList2(context.list2());
        return null;
    }

    public override string? VisitEListItem2(Markdown.EListItem2Context context)
    {
        string item = "";
        if (context.requiredText() is not null)
            item = VisitRequiredText(context.requiredText());
        WriteLine("\\item " + item);
        if (context.list3() is not null)
            VisitList3(context.list3());
        return null;
    }

    public override string? VisitEListItem3(Markdown.EListItem3Context context)
    {
        string item = "";
        if (context.requiredText() is not null)
            item = VisitRequiredText(context.requiredText());
        WriteLine("\\item " + item);
        return null;
    }

    public override string? VisitTextLine(Markdown.TextLineContext context)
    {
        WriteLine(VisitOptionalText(context.optionalText()));
        return null;
    }

    public override string? VisitLink(Markdown.LinkContext context)
    {
        if (context.urlLink() is not null)
            VisitUrlLink(context.urlLink());
        else
            VisitTextLink(context.textLink());
        return null;
    }

    public override string? VisitUrlLink(Markdown.UrlLinkContext context)
    {
        string url = VisitUrlText(context.urlText());
        WriteLine($"\\url{{{url}}}");
        return null;
    }

    public override string VisitUrlText(Markdown.UrlTextContext context)
    {
        return context.GetText();
    }

    public override string? VisitTextLink(Markdown.TextLinkContext context)
    {
        string text = VisitDisplayText(context.displayText());
        string url = VisitLinkText(context.linkText());
        WriteLine($"\\href{{{url}}}{{{text}}}");
        return null;
    }

    private int _currentLevel;

    public MdVisitor(Action<string?> writeLine)
    {
        WriteLine = writeLine;
    }
    
    public override string? VisitBlockQuote(Markdown.BlockQuoteContext context)
    {
        VisitChildren(context);
        AdjustQuoteLevel(0);
        return null;
    }

    public override string? VisitBlockQuoteLine(Markdown.BlockQuoteLineContext context)
    {
        VisitBlockQuoteStart(context.blockQuoteStart());
        WriteLine(VisitRequiredText(context.requiredText()));
        return null;
    }

    public override string? VisitEmptyBlockQuoteLine(Markdown.EmptyBlockQuoteLineContext context)
    {
        VisitBlockQuoteStart(context.blockQuoteStart());
        WriteLine(null);
        return null;
    }

    public override string? VisitBlockQuoteStart(Markdown.BlockQuoteStartContext context)
    {
        int count = context.GetText().Count(x => x == '>');
        AdjustQuoteLevel(count);
        return null;
    }

    private void AdjustQuoteLevel(int newLevel)
    {
        while (_currentLevel < newLevel)
        {
            WriteLine(@"\begin{quote}");
            _currentLevel++;
        }
        while (_currentLevel > newLevel)
        {
            WriteLine(@"\end{quote}");
            _currentLevel--;
        }
    }

    public override string? VisitLinkLine(Markdown.LinkLineContext context)
    {
        VisitLink(context.link());
        return null;
    }
}