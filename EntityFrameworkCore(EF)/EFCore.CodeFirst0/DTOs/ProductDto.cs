using EFCore.CodeFirst0.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst0.DTOs
{
    internal class ProductDto
    {
        public int Id { get; set; }

     
        public string Name { get; set; }
       
        public decimal? Price { get; set; }

        public int Stock { get; set; }

    }
}
