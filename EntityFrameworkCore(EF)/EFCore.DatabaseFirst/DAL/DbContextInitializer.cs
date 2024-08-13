using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.DatabaseFirst.DAL
{
    internal class DbContextInitializer
    {
        public static IConfigurationRoot Configuration;  //appsetting dosyasından okumak için.
        public static DbContextOptionsBuilder<AppDbContext> OptionsBuilder; //veritabanıya ilgili optionsları belirteceğimiz yer.
        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile
                   ("appsettings.json", optional: true, reloadOnChange: true);
            //okunacak dosyanın yolu ve optinal olabilir
            // olmayabilirde dosya  , değişiklik sonrası tekrar yükle reloadonchange

            Configuration= builder.Build();  

            //OptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            //OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon")); 



        }}}



