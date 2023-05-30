using GroupsRandomizes.Arg;
using GroupsRandomizes.Groups;
using GroupsRandomizes.Lists;

var arguments = new Args(args);
Console.WriteLine(
    new PrintGroups(
        new SplitList<string>(
            new ShuffledList<string>(
                arguments.Next("--members")
                    .Split(',', ';')
                    .Select(e => e.Trim())
                    .ToList()
            ),
            int.Parse(
                arguments.Next("--count")
            )
        )
    )
);