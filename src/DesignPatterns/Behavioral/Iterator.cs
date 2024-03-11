using System.Collections;

namespace DesignPatterns.Behavioral;

public abstract class Iterator : IEnumerator
{
    public abstract bool MoveNext();
    public abstract void Reset();
    public abstract object Current { get; }
}

public abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}

public class WordsCollection : IteratorAggregate
{
    private readonly List<string> words = [];

    public List<string> GetItems() => words;
    public void AddItem(string item) => words.Add(item);
    public override IEnumerator GetEnumerator() => new AlphabeticalIterator(this);
}

public class AlphabeticalIterator : Iterator
{
    private int position = -1;
    private readonly WordsCollection collection;

    public AlphabeticalIterator(WordsCollection collection)
    {
        this.collection = collection;
    }

    public override bool MoveNext()
    {
        position += 1;
        return position < collection.GetItems().Count;
    }

    public override void Reset() => position = -1;
    public override object Current => collection.GetItems()[position];
}