
# Dokumentacja

- Ogólna: [ANTLR4 Documentation](https://github.com/antlr/antlr4/blob/master/doc/index.md)
- Podstawy dla Pythona: [ANTLR4 Python Target](https://github.com/antlr/antlr4/blob/master/doc/python-target.md)
- Podstawy dla C#: [ANTLR4 C#](https://github.com/antlr/antlr4/tree/master/runtime/CSharp/src)

## Inne linki

- Gramatyka C11: [C.g4](https://github.com/antlr/grammars-v4/blob/master/c/C.g4)
- Tutoriale (głównie do C#):
  - [Getting Started with ANTLR in C#](https://tomassetti.me/getting-started-with-antlr-in-csharp/)
  - [Listeners and Visitors](https://tomassetti.me/listeners-and-visitors/)

## Kod Preprocesora

### Namespace Markdown_to_LaTeX

```csharp
namespace Markdown_to_LaTeX;

public class MarkdownPreprocessor
{
    private string FilePath { get; }

    public MarkdownPreprocessor(string filePath)
    {
        FilePath = filePath;
    }

    public void ProcessFile()
    {
        string[] lines = File.ReadAllLines(FilePath);
        using (StreamWriter writer = new StreamWriter(FilePath, false))
        {
            bool firstLineBlank = string.IsNullOrWhiteSpace(lines[0]);
            bool lastLineBlank = string.IsNullOrWhiteSpace(lines[^1]);

            if (!firstLineBlank)
            {
                writer.WriteLine();
            }

            foreach (string line in lines)
            {
                string processedLine = line.Replace("\t", "    ");
                processedLine = AdjustLeadingSpaces(processedLine);
                processedLine = processedLine.TrimEnd();
                processedLine = processedLine.Replace('\u0000', '\uFFFD');

                writer.WriteLine(processedLine);
            }

            if (!lastLineBlank)
            {
                writer.WriteLine();
            }
        }
    }

    private string AdjustLeadingSpaces(string line)
    {
        int leadingSpaces = 0;
        foreach (char c in line)
        {
            if (c == ' ')
            {
                leadingSpaces++;
            }
            else
            {
                break;
            }
        }
        leadingSpaces -= leadingSpaces % 4;
        return new string(' ', leadingSpaces) + line.TrimStart();
    }
}
```

### Lexer MarkdownLexer

```antlr
lexer grammar MarkdownLexer;

// Whitespace
Newline
    : '\r'? '\n'
    | '\r'
    ;
Space : ' ';
Tab : '\t';

// Escaped symbols
EscExclamation : '\\!';
EscDoubleQuote : '\\"';
EscSharp : '\\#';
EscDolar : '\\$';
EscPercent : '\\%';
EscAmp : '\\&';
EscQuote : '\\'';
EscLPAREN : '\\(';
EscRPAREN : '\\)';
EscStar : '\\*';
EscPlus : '\\+';
EscComma : '\\,';
EscDash : '\\-';
EscDot : '\\.';
EscSlash : '\\/';
EscColon : '\\:';
EscSemicilon : '\\;';
EscLT : '\\<';
EscEqual : '\\=';
EscGT : '\\>';
EscQuestion : '\\?';
EscAt : '\\@';
EscLBRACKET : '\\[';
EscBackslash : '\\\\';
EscRBRACKET : '\\]';
EscCarrot : '\\^';
EscUnderscore : '\\_';
EscCode : '\\`';
EscLBRACE : '\\{';
EscPipe : '\\|';
EscRBRACE : '\\}';
EscTilde : '\\~';

// Special symbols
LBRACKET : '[';
RBRACKET : ']';
LPAREN : '(';
RPAREN : ')';
LBRACE : '{';
RBRACE : '}';
LT : '<';
GT : '>';
Dot : '.';
Slash : '/';
Backslash : '\\';
Colon : ':';
Semicolon : ';';
Exclamation : '!';
Quote : '\'';
DoubleQuote : '"';
Sharp: '#';
Dolar: '$';
Percent : '%';
Amp : '&';
Comma : ',';
Equal : '=';
Question : '?';
At : '@';
Carrot : '^';
Underscore :  '_';
Pipe : '|';
Tilde : '~';
Dash : '-';
Star : '*';
Plus : '+';
Code : '`';

// Other characters 
Digit : [0-9];
Other : .;
```

### Parser Markdown

```antlr
parser grammar Markdown;
options{
    tokenVocab=MarkdownLexer;
}

// Main rule
document : (heading | horizontalLine | fencedCode | indentedCodeBlock | list | blockQuote | table | imageLine | textLine)* EOF;

// Headings
heading
    : headingStart Space headingText (Space Sharp+)?  #atxHeading
    | Newline requiredText setextEnd                  #setextHeading
    | headingStart                                    #emptyHeading
    ;
headingStart : Newline Sharp (Sharp (Sharp (Sharp (Sharp Sharp?)?)?)?)?;
setextEnd
    : Newline Dash Dash+ Newline
    | Newline Equal Equal+ Newline
    ;

// Horizontal lines - require a trailing empty line
horizontalLine
    : hLineDBegin (Space|Dash)* Newline
    | hLineUBegin (Space|Underscore)* Newline
    | hLineSBegin (Space|Star)* Newline
    ;
hLineDBegin : Newline Dash Space* Dash Space* Dash;
hLineUBegin : Newline Underscore Space* Underscore Space* Underscore;
hLineSBegin : Newline Star Space* Star Space* Star;

// Indents - for list items and indented code
indent3 : Newline Space Space Space Space Space Space Space Space Space Space Space Space;
indent2 : Newline Space Space Space Space Space Space Space Space;
indent1 : Newline Space Space Space Space;

// Fenced code blocks
fencedCode
    : Newline Code Code Code fencedText Code Code Code optionalText
    | Newline Tilde Tilde Tilde fencedText Tilde Tilde Tilde optionalText
    ;

// Indented code blocks - require a preceding empty line
indentedCodeBlock : Newline indentedCode1 (Newline? indentedCode1)*;
indentedCode1 : indent1 requiredText;
    
// Lists - itemized and enumerated with max 3 levels of indentation
list  : iList0 | eList0;
list1 : iList1 | eList1;
list2 : iList2 | eList2;
list3 : iList3 | eList3;

iList3 : iListItem3+;
iList2 : iListItem2+;
iList1 : iListItem1+;
iList0 : iListItem0+;

iListItem3 : indent3 iListBegin (Space requiredText)?;
iListItem2 : indent2 iListBegin (Space requiredText)? list3?;
iListItem1 : indent1 iListBegin (Space requiredText)? list2?;
iListItem0 : Newline iListBegin (Space requiredText)? list1?;

iListBegin : Dash | Plus | Star;

eList3 : eListItem3+;
eList2 : eListItem2+;
eList1 : eListItem1+;
eList0 : eListItem0+;

eListItem3 : indent3 eListBegin (Space requiredText)?;
eListItem2 : indent2 eListBegin (Space requiredText)? list3?;
eListItem1 : indent1 eListBegin (Space requiredText)? list2?;
eListItem0 : Newline eListBegin (Space requiredText)? list1?;

eListBegin : Digit+ (Dot | RPAREN);

// Block Quotes - require a space before text
blockQuote : (blockQuoteLine | emptyBlockQuoteLine)+;
blockQuoteLine : blockQuoteStart Space requiredText;
emptyBlockQuoteLine : blockQuoteStart;
blockQuoteStart : Newline GT (GT (GT (GT (GT GT?)?)?)?)?;

// Tables - require a trailing empty line
table : Newline headerRow Newline separatorRow Newline contentRow (Newline contentRow)* Newline;
headerRow : Pipe cellContent (Pipe cellContent)* Pipe;
contentRow : Pipe cellContent (Pipe cellContent)* Pipe;
cellContent : ~(Newline | Pipe)*;
separatorRow : Pipe separatorContent (Pipe separatorContent)* Pipe;
separatorContent : Space? Colon? Dash+ Colon? Space?;

// Images
imageLine : Newline Exclamation LBRACKET displayText RBRACKET LPAREN linkText RPAREN optionalText;

// Text
textLine : Newline optionalText;
requiredText : (link | ~Newline)+;
optionalText : (link | ~Newline)*;
displayText : ~(Newline|RBRACKET)+;
linkText : ~(Newline|RPAREN)+;
urlText : ~(Newline|GT)+;
headingText : (link | ~Newline)+?;
fencedText : .*?;

// Links
link : urlLink | textLink;
urlLink : LT urlText GT;
textLink : LBRACKET displayText RBRACKET LPAREN linkText RPAREN;
```
