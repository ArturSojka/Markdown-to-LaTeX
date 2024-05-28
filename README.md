# Dane Studentów
- Artur Sojka, asojka@student.agh.edu.pl
- Piotr Waluszek, waluszekp@student.agh.edu.pl

# Opis projektu konwertera Markdown do LaTeX

Naszym projektem był konwerter, który przekształca dokumenty napisane w formacie Markdown na dokumenty w formacie LaTeX. Projekt składał się z kilku kluczowych komponentów i etapów implementacji.

#### a. Opis ogólny programu

Celem programu było umożliwienie użytkownikom konwersji dokumentów Markdown do LaTeX. Markdown jest prostym językiem znaczników używanym do formatowania tekstu, podczas gdy LaTeX jest zaawansowanym systemem składu tekstu, powszechnie używanym do tworzenia dokumentów technicznych i naukowych.

#### b. Rodzaj translatora: interpreter czy kompilator

Nasz projekt był **kompilatorem**, który tłumaczy kod źródłowy napisany w Markdown na kod w LaTeX.

#### c. Planowany wynik działania programu

Planowanym wynikiem działania naszego programu był:
- Konwerter Markdown do LaTeX, który przekształca dokumenty Markdown na format LaTeX, umożliwiając dalszą edycję i profesjonalne składanie dokumentów.

#### d. Język implementacji

 Językiem implementacji był **C#**. Wybraliśmy ten język ze względu na jego wydajność oraz wsparcie dla nowoczesnych technik programowania.

#### e. Sposób realizacji skanera/parsera

Skaner i parser były realizowane za pomocą generatora ANTLR (ANother Tool for Language Recognition), który umożliwia automatyczne generowanie skanerów i parserów na podstawie zdefiniowanej gramatyki.

#### Opis komponentów projektu

- **Markdown-to-LaTeX.csproj**: Plik projektu dla środowiska .NET.
- **Markdown.g4**: Plik z definicją gramatyki dla parsera ANTLR, który opisuje składnię Markdown.
- **MarkdownLexer.g4**: Plik z definicją leksykalną dla lexer'a ANTLR, który rozpoznaje tokeny w kodzie Markdown.
- **MdConverter.cs**: Klasa odpowiedzialna za konwersję z Markdown do LaTeX.
- **MdPreprocessor.cs**: Klasa zajmująca się wstępnym przetwarzaniem tekstu Markdown przed przekazaniem go do parsera.
- **MdVisitor.cs**: Klasa odwiedzającego, która przechodzi przez drzewo parsowania wygenerowane przez ANTLR i przekształca je na kod LaTeX.
- **Program.cs**: Główny plik programu, który inicjalizuje i uruchamia konwerter.
- **StringExtension.cs**: Klasa zawierająca rozszerzenia dla stringów, pomocna przy przetwarzaniu tekstu.
- **przyklad.md**: Przykładowy plik Markdown używany do testowania konwertera.

### Szczegółowe kroki implementacji

1. **Definicja gramatyki**:
   - Zdefiniowaliśmy tokeny dla elementów Markdown (np. `HEADER`, `LIST_ITEM`, `BLOCK_QUOTE`, `BOLD`, `ITALIC`, `CODE`, `LINK`, `IMAGE`).
   - Zdefiniowaliśmy reguły parsowania tych elementów w plikach `Markdown.g4` i `MarkdownLexer.g4`.

2. **Generowanie parsera i leksera**:
   - Użyliśmy ANTLR do wygenerowania klas parsera i leksera.

3. **Implementacja klasy odwiedzającej**:
   - Stworzyliśmy klasę odwiedzającą `MdVisitor`, która rozszerza bazową klasę odwiedzającą wygenerowaną przez ANTLR.
   - Zaimplementowaliśmy między innymi metody takie jak `VisitHeader`, `VisitListItem`, `VisitBlockQuote`, `VisitBold`, `VisitItalic`, `VisitCode`, `VisitLink`, `VisitImage`.

# Kod Preprocesora

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

# Opis tokenów

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


## Lista produkcji z Markdown do LaTeX

### Nagłówki (Headers)
- **Markdown**: `# Header 1`, `## Header 2`, `### Header 3`, itd.
- **LaTeX**:
  ```latex
  \section{Header 1}
  \subsection{Header 2}
  \subsubsection{Header 3}
  ```

### Listy nieuporządkowane (Unordered Lists)
- **Markdown**: `- Item 1`, `* Item 1`, `+ Item 1`
- **LaTeX**:
  ```latex
  \begin{itemize}
      \item Item 1
      \item Item 2
  \end{itemize}
  ```

### Listy uporządkowane (Ordered Lists)
- **Markdown**: `1. Item 1`, `2. Item 2`
- **LaTeX**:
  ```latex
  \begin{enumerate}
      \item Item 1
      \item Item 2
  \end{enumerate}
  ```

### Cytaty (Blockquotes)
- **Markdown**: `> This is a quote`
- **LaTeX**:
  ```latex
  \begin{quote}
  This is a quote
  \end{quote}
  ```

### Kod (Code)
- **Markdown**:
  ```markdown
  `inline code`
  ```
  ```markdown
  ```
  block code
  ```
- **LaTeX**:
  ```latex
  \texttt{inline code}
  ```
  ```latex
  \begin{verbatim}
  block code
  \end{verbatim}
  ```

### Kursywa (Italic)
- **Markdown**: `*italic*` lub `_italic_`
- **LaTeX**:
  ```latex
  \textit{italic}
  ```

### Pogrubienie (Bold)
- **Markdown**: `**bold**` lub `__bold__`
- **LaTeX**:
  ```latex
  \textbf{bold}
  ```

### Linki (Links)
- **Markdown**: `[link text](http://example.com)`
- **LaTeX**:
  ```latex
  \href{http://example.com}{link text}
  ```

### Obrazy (Images)
- **Markdown**: `![alt text](image.jpg)`
- **LaTeX**:
  ```latex
  \begin{figure}[h]
      \centering
      \includegraphics[width=\linewidth]{image.jpg}
      \caption{alt text}
  \end{figure}
  ```

### Linie poziome (Horizontal Rules)
- **Markdown**: `---`, `***`, `___`
- **LaTeX**:
  ```latex
  \hrule
  ```

### Tabele (Tables)
- **Markdown**:
  ```markdown
  | Header 1 | Header 2 |
  | -------- | -------- |
  | Cell 1   | Cell 2   |
  ```
- **LaTeX**:
  ```latex
  \begin{tabular}{|c|c|}
  \hline
  Header 1 & Header 2 \\
  \hline
  Cell 1 & Cell 2 \\
  \hline
  \end{tabular}
  ```

### Zagnieżdżone elementy (Nested Elements)
- **Markdown**:
  ```markdown
  - Item 1
    - Subitem 1
      - Subsubitem 1
  ```
- **LaTeX**:
  ```latex
  \begin{itemize}
      \item Item 1
      \begin{itemize}
          \item Subitem 1
          \begin{itemize}
              \item Subsubitem 1
          \end{itemize}
      \end{itemize}
  \end{itemize}
  ```

### Matematyka liniowa (Inline Math)
- **Markdown**: `$inline math$`
- **LaTeX**:
  ```latex
  $inline math$
  ```

### Matematyka blokowa (Block Math)
- **Markdown**:
  ```markdown
  $$
  block math
  $$
  ```
- **LaTeX**:
  ```latex
  \[
  block math
  \]
  ```

### Przypisy dolne (Footnotes)
- **Markdown**:
  ```markdown
  Here is a footnote reference[^1].

  [^1]: Here is the footnote.
  ```
- **LaTeX**:
  ```latex
  Here is a footnote reference\footnote{Here is the footnote.}.
  ```

# Instrukcja Obsługi Programu MdToLatex

Program MdToLatex konwertuje pliki w formacie Markdown na pliki w formacie LaTeX. Program można uruchomić z wiersza poleceń, podając odpowiednie argumenty.

## Użycie

```sh
MdToLatex in.md [out.tex]
```

## Argumenty

- `in.md`: Ścieżka do pliku Markdown, który ma być przekonwertowany.
- `[out.tex]` (opcjonalnie): Ścieżka do pliku wyjściowego w formacie LaTeX. Jeśli nie zostanie podany, plik wyjściowy zostanie nazwany tak samo jak plik wejściowy, ale z rozszerzeniem `.tex`.

## Przykłady

1. **Konwersja z domyślną nazwą pliku wyjściowego**

   Jeśli chcesz przekonwertować plik `in.md` i zapisać wynik w pliku `in.tex`:

   ```sh
   MdToLatex in.md
   ```

2. **Konwersja z określoną nazwą pliku wyjściowego**

   Jeśli chcesz przekonwertować plik `in.md` i zapisać wynik w pliku `output.tex`:

   ```sh
   MdToLatex in.md output.tex
   ```

## Działanie Programu

1. Program sprawdza, czy podano prawidłową liczbę argumentów (1 lub 2).
2. Program sprawdza, czy plik wejściowy (`in.md`) istnieje.
3. Jeśli nie podano nazwy pliku wyjściowego, program tworzy nazwę na podstawie pliku wejściowego, zmieniając jego rozszerzenie na `.tex`.
4. Program konwertuje zawartość pliku Markdown na LaTeX.
5. Program zapisuje wynik konwersji do pliku wyjściowego (z rozszerzeniem `.tex`).
6. Program wyświetla komunikat potwierdzający zapis pliku wyjściowego.

## Komunikaty Błędów

- Jeśli podano mniej niż jeden lub więcej niż dwa argumenty:
  ```sh
  Użycie: MdToLatex in.md [out.tex]
  ```

- Jeśli plik wejściowy (`in.md`) nie istnieje:
  ```sh
  Nieprawidłowa ścieżka do pliku.
  ```


## Dokumentacja instalacji ANTLRa

- Ogólna: [ANTLR4 Documentation](https://github.com/antlr/antlr4/blob/master/doc/index.md)
- Podstawy dla Pythona: [ANTLR4 Python Target](https://github.com/antlr/antlr4/blob/master/doc/python-target.md)
- Podstawy dla C#: [ANTLR4 C#](https://github.com/antlr/antlr4/tree/master/runtime/CSharp/src)

## Inne linki

- Gramatyka C11: [C.g4](https://github.com/antlr/grammars-v4/blob/master/c/C.g4)
- Tutoriale (głównie do C#):
  - [Getting Started with ANTLR in C#](https://tomassetti.me/getting-started-with-antlr-in-csharp/)
  - [Listeners and Visitors](https://tomassetti.me/listeners-and-visitors/)
