using System.Text;

namespace Markdown_to_LaTeX;
public class MdPreprocessor
{
    private string FilePath { get; }

    public MdPreprocessor(string filePath)
    {
        FilePath = filePath;
    }

    public string ProcessFile()
    {
        string[] lines = File.ReadAllLines(FilePath);
        StringBuilder builder = new();
        
        bool firstLineBlank = string.IsNullOrWhiteSpace(lines[0]);
        bool lastLineBlank = string.IsNullOrWhiteSpace(lines[^1]);

        if (!firstLineBlank)
            builder.Append('\n');

        foreach (string line in lines)
        {
            string processedLine = line.Replace("\t", "    ");
            processedLine = AdjustLeadingSpaces(processedLine);
            processedLine = processedLine.TrimEnd()+'\n';
            processedLine = processedLine.Replace('\u0000', '\uFFFD');
            
            builder.Append(processedLine);
        }

        if (!lastLineBlank)
            builder.Append('\n');

        return builder.ToString();
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