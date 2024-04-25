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
EscQuote : '\\\'';
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

