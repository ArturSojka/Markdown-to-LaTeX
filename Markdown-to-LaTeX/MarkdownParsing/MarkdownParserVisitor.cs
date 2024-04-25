//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/artur/RiderProjects/Markdown-to-LaTeX/Markdown-to-LaTeX/MarkdownParser.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace MarkdownParsing {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="MarkdownParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IMarkdownParserVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.document"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDocument([NotNull] MarkdownParser.DocumentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.heading"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeading([NotNull] MarkdownParser.HeadingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.emptyHeading"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEmptyHeading([NotNull] MarkdownParser.EmptyHeadingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.atxHeading"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAtxHeading([NotNull] MarkdownParser.AtxHeadingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.headingStart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeadingStart([NotNull] MarkdownParser.HeadingStartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.horizontalLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHorizontalLine([NotNull] MarkdownParser.HorizontalLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.hLineDBegin"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHLineDBegin([NotNull] MarkdownParser.HLineDBeginContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.hLineUBegin"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHLineUBegin([NotNull] MarkdownParser.HLineUBeginContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.hLineSBegin"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHLineSBegin([NotNull] MarkdownParser.HLineSBeginContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.indent3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndent3([NotNull] MarkdownParser.Indent3Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.indent2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndent2([NotNull] MarkdownParser.Indent2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.indent1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndent1([NotNull] MarkdownParser.Indent1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.fencedCode"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFencedCode([NotNull] MarkdownParser.FencedCodeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.indentedCodeBlock"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndentedCodeBlock([NotNull] MarkdownParser.IndentedCodeBlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.indentedCode1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndentedCode1([NotNull] MarkdownParser.IndentedCode1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList([NotNull] MarkdownParser.ListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.list1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList1([NotNull] MarkdownParser.List1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.list2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList2([NotNull] MarkdownParser.List2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.list3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList3([NotNull] MarkdownParser.List3Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iList3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIList3([NotNull] MarkdownParser.IList3Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iList2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIList2([NotNull] MarkdownParser.IList2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iList1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIList1([NotNull] MarkdownParser.IList1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iList0"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIList0([NotNull] MarkdownParser.IList0Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iListItem3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIListItem3([NotNull] MarkdownParser.IListItem3Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iListItem2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIListItem2([NotNull] MarkdownParser.IListItem2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iListItem1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIListItem1([NotNull] MarkdownParser.IListItem1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iListItem0"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIListItem0([NotNull] MarkdownParser.IListItem0Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.iListBegin"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIListBegin([NotNull] MarkdownParser.IListBeginContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eList3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEList3([NotNull] MarkdownParser.EList3Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eList2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEList2([NotNull] MarkdownParser.EList2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eList1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEList1([NotNull] MarkdownParser.EList1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eList0"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEList0([NotNull] MarkdownParser.EList0Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eListItem3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEListItem3([NotNull] MarkdownParser.EListItem3Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eListItem2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEListItem2([NotNull] MarkdownParser.EListItem2Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eListItem1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEListItem1([NotNull] MarkdownParser.EListItem1Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eListItem0"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEListItem0([NotNull] MarkdownParser.EListItem0Context context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.eListBegin"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEListBegin([NotNull] MarkdownParser.EListBeginContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.blockQuote"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockQuote([NotNull] MarkdownParser.BlockQuoteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.blockQuoteLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockQuoteLine([NotNull] MarkdownParser.BlockQuoteLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.emptyBlockQuoteLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEmptyBlockQuoteLine([NotNull] MarkdownParser.EmptyBlockQuoteLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.blockQuoteStart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlockQuoteStart([NotNull] MarkdownParser.BlockQuoteStartContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.table"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTable([NotNull] MarkdownParser.TableContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.headerRow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeaderRow([NotNull] MarkdownParser.HeaderRowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.contentRow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContentRow([NotNull] MarkdownParser.ContentRowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.cellContent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCellContent([NotNull] MarkdownParser.CellContentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.separatorRow"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSeparatorRow([NotNull] MarkdownParser.SeparatorRowContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.separatorContent"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSeparatorContent([NotNull] MarkdownParser.SeparatorContentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.imageLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitImageLine([NotNull] MarkdownParser.ImageLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.textLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTextLine([NotNull] MarkdownParser.TextLineContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.requiredText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRequiredText([NotNull] MarkdownParser.RequiredTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.optionalText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOptionalText([NotNull] MarkdownParser.OptionalTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.displayText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDisplayText([NotNull] MarkdownParser.DisplayTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.linkText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLinkText([NotNull] MarkdownParser.LinkTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.urlText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUrlText([NotNull] MarkdownParser.UrlTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.headingText"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHeadingText([NotNull] MarkdownParser.HeadingTextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.link"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLink([NotNull] MarkdownParser.LinkContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.urlLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUrlLink([NotNull] MarkdownParser.UrlLinkContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="MarkdownParser.textLink"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTextLink([NotNull] MarkdownParser.TextLinkContext context);
}
} // namespace MarkdownParsing
