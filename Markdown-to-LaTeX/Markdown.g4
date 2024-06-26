﻿parser grammar Markdown;
options{
    tokenVocab=MarkdownLexer;
}

// Main rule
document : (heading | horizontalLine | fencedCode | indentedCodeBlock | list | blockQuote | table | imageLine | linkLine | textLine)* EOF;

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
//indent5 : Newline Space Space Space Space Space Space Space Space Space Space Space Space Space Space Space Space Space Space Space Space ;
//indent4 : Newline Space Space Space Space Space Space Space Space Space Space Space Space Space Space Space Space;
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
indentedCode1 : indent1 codeText;
    
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

// Images and links
imageLine : Newline Exclamation LBRACKET displayText RBRACKET LPAREN linkText RPAREN optionalText;
linkLine : Newline link optionalText;

// Text
textLine : Newline optionalText;
requiredText : ~Newline+;
optionalText : ~Newline*;
displayText : ~(Newline|RBRACKET)+;
linkText : ~(Newline|Space|RPAREN)+;
urlText : ~(Newline|Space|GT)+;
headingText : ~Newline+?;
fencedText : .*?;
codeText : ~Newline*?;

// Links
link : urlLink | textLink;
urlLink : LT urlText GT;
textLink : LBRACKET displayText RBRACKET LPAREN linkText RPAREN;