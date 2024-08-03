


internal class Program
{
     private static void Main(string[] args)
    {

        int total = 0;

        Parallel.ForEach(Enumerable.Range(1,100).ToList(), () => 0,(x,loop,sumtotal) =>
        {
            sumtotal += x;
            return sumtotal;
        }, (y) => Interlocked.Add(ref total,y));
        Console.WriteLine(total);

        Parallel.For(1, 100, () => x, (x, loop, subtotal) =>
        {
            subtotal += x;
            return subtotal;
        }, (y) => Interlocked.Add(ref total,y));
        Console.WriteLine(total);
    }

}

