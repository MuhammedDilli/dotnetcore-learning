using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst0.DAL
{
    public  class ProductFeature
    {
        [ForeignKey("Product")]
         public int Id { get; set; }   
         public int Width { get; set; }
        public int height { get; set; }

        public string? Color { get; set; }
        public int ProductRef_Id { get; set; }   //id olan yer child diğer taraf parent yani foreignkey olan kısım

        public Product? Product { get; set; }
    }
}
