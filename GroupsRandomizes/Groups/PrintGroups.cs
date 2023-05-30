using System.Text;

namespace GroupsRandomizes.Groups;

public class PrintGroups
{
    private readonly IReadOnlyList<IReadOnlyList<string>> groups;

    public PrintGroups(IReadOnlyList<IReadOnlyList<string>> groups)
    {
        this.groups = groups;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        for (var i = 0; i < groups.Count; i++)
        {
            builder.AppendLine($"Group {i + 1}: {string.Join(", ", groups[i])}");
        }
        return builder.ToString();
    }
}