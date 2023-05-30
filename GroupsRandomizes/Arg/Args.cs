namespace GroupsRandomizes.Arg;

public class Args
{
    private readonly List<string> args;

    public Args(List<string> args)
    {
        this.args = args;
    }

    public Args(string[] args) : this(new List<string>(args))
    {
    }

    public string Next(string flag)
    {
        var index = args.IndexOf(flag);
        if (index == -1 || index == args.Count - 1)
        {
            throw new Exception($"{flag} is out of range {index}");
        }
        return args[index + 1];
    }
}