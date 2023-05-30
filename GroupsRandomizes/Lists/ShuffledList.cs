using System.Collections;

namespace GroupsRandomizes.Lists;

public class ShuffledList<T> : IReadOnlyList<T>
{
    private readonly IReadOnlyList<T> origin;
    private IReadOnlyList<T>? shuffled;

    public ShuffledList(IReadOnlyList<T> origin)
    {
        this.origin = origin;
    }

    private IReadOnlyList<T> Shuffled()
    {
        if (shuffled == null)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var list = new List<T>(origin);

            for (var i = 0; i < list.Count; i++)
            {
                var another = random.Next(list.Count);
                (list[i], list[another]) = (list[another], list[i]);
            }

            shuffled = list;
        }
        return shuffled;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Shuffled().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public int Count => origin.Count;

    public T this[int index] => Shuffled()[index];
}