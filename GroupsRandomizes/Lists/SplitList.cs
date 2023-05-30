using System.Collections;

namespace GroupsRandomizes.Lists;

public class SplitList<T> : IReadOnlyList<IReadOnlyList<T>>
{
    private readonly IReadOnlyList<T> origin;
    private readonly int count;

    private IReadOnlyList<IReadOnlyList<T>>? splits;

    public SplitList(IReadOnlyList<T> origin, int count)
    {
        this.origin = origin;
        this.count = count;
    }

    private IReadOnlyList<IReadOnlyList<T>> Splits()
    {
        if (splits == null)
        {
            if (origin.Count < count)
            {
                throw new Exception("Not enough items to split");
            }
            var lists = new List<List<T>>(count);
            for (var i = 0; i < count; i++)
            {
                lists.Add(new List<T>());
            }
            for (var i = 0; i < origin.Count; i++)
            {
                lists[i % count].Add(origin[i]);
            }
            splits = lists;
        }
        return splits;
    }

    public IEnumerator<IReadOnlyList<T>> GetEnumerator()
    {
        return Splits().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => count;

    public IReadOnlyList<T> this[int index] => Splits()[index];
}