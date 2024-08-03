using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    public static bool İslem(int x)
    {
        return x % 2 == 0;
    }

    static void Main()
    {
        var array = Enumerable.Range(1, 100).ToList();

        ////NORMAL DÖNGÜ 
        //array.Where(İslem).ToList().ForEach (x => {
        //    Console.WriteLine(x);
        //});

        // PARALEL DÖNGÜ
        var newArray = array.AsParallel().Where(İslem);

        // Bir thread kullanır for ve foreach ama forAll birden fazla thread kullanır.

        // Performans kötü forAll'a göre
        //newArray.ToList().ForEach(x =>
        //{
        //    Thread.Sleep(500);
        //    Console.WriteLine(x);
        //});

        // forAll daha performanslıdır
        newArray.ForAll(x =>
        {
            Thread.Sleep(500);
            Console.WriteLine(x);
        });
    }
}




