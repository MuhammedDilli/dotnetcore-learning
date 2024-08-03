using PLINQSORGU5.Models;

namespace PLINQSORGU5
{
    internal class Program
    {
        private static void writeLog(Product p)
        {
            Console.WriteLine(p.Name + " log'a kaydedildi.");
        }

        static void Main(string[] args)
        {           
            AdventureWorks2017Context context = new AdventureWorks2017Context();

            //context.Products.Take(10).ToList().ForEach(x => 
            //{
            //    Console.WriteLine(x.Name);
            //});

            //context.Products.AsParallel().ForAll(p => 
            //{
            //    writeLog(p);
            
                               
            //});
            //withdegreeofparallelism kaç işlemcide çalışacağını gösterir
            context.Products.AsParallel().WithDegreeOfParallelism(20).ForAll(p =>
            {
                writeLog(p);


            });

            //var product = (from p in context.Products.AsParallel()
            //               where p.ListPrice > 10M
            //               select p).Take(10);  

            //product.ForAll(x => 
            //{ 
            // Console.WriteLine(x.Name);

            //});



        }
    }
}
