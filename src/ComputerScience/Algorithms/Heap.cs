namespace DesignPatterns.Algorithms;

public class Heap
{
    public static int[] TopK(int[] elements, int k)
    {
        var queue = new PriorityQueue<int, int>();
        for (var i = 0; i < k; i++)
        {
            queue.Enqueue(elements[i], elements[i]);
        }

        for (var i = k; i < elements.Length; i++)
        {
            if (elements[i] > queue.Peek())
            {
                queue.Dequeue();
                queue.Enqueue(elements[i], elements[i]);
            }
        }

        var topK = new List<int>();
        while (queue.Count > 0) topK.Add(queue.Dequeue());

        return topK.ToArray();
    }
}

public class HeapTest
{
    [Test]
    public void TopK()
    {
        const int k = 3;
        var elements = new[] { 1, 2, 3, 4, 5, 6, 7, 9, 8, 10 };
        var topK = Heap.TopK(elements, k);
        Assert.That(topK, Has.Length.EqualTo(k));
        Assert.That(string.Join(",", topK), Is.EqualTo("8,9,10"));
    }
}