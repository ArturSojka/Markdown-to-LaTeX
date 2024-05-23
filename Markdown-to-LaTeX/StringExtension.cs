using System.Text;

namespace Markdown_to_LaTeX;

public static class StringExtension
{
    /// <summary>
    /// Return a new string where
    /// all the LaTeX special characters
    /// have been escaped.
    /// </summary>
    public static string ToLatexEscaped(this string str)
    {
        StringBuilder builder = new(str);
        // Remove Markdown escapes
        builder.Replace(@"\!", "!");
        builder.Replace(@"\#", "#");
        builder.Replace(@"\(", "(");
        builder.Replace(@"\)", ")");
        builder.Replace(@"\<", "<");
        builder.Replace(@"\>", ">");
        builder.Replace(@"\[", "[");
        builder.Replace(@"\]", "]");
        builder.Replace(@"\`", "`");
        builder.Replace(@"\|", "|");
        builder.Replace(@"\\", @"\");
        
        // Escape LaTeX special characters
        builder.Replace(@"\", @"\textbackslash ");
        builder.Replace("%", @"\%");
        builder.Replace("$", @"\$");
        builder.Replace("&", @"\&");
        builder.Replace("#", @"\#");
        builder.Replace("{", @"\{");
        builder.Replace("}", @"\}");
        
        builder.Replace("^", @"\^{}");

        return builder.ToString();
    }
}