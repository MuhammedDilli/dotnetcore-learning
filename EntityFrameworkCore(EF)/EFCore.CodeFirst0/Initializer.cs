using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst0
{
    internal class Initializer
    {
        public static IConfigurationRoot Configuration; //appsetting dosyasından okumak için.
        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile
                   ("appsettings.json", optional: true, reloadOnChange: true);
            //okunacak dosyanın yolu ve optinal olabilir
            // olmayabilirde dosya  , değişiklik sonrası tekrar yükle reloadonchange
            Configuration = builder.Build();


        }
    }
}