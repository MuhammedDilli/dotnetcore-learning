using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst0.DAL
{
   // [Table("ProductTb",Schema ="products")] //1. yol tablo isim ver ve şema ismi ver 2.yol dbcontext te
    public   class Product
    {
        //[Column( Order = 1)]
        public int Id { get; set; }

       // [Column("name2",Order =2)]
        public string Name { get; set; }
       // [Column("price", Order = 3 ,TypeName ="decimal(18,2)")]
        public decimal? Price { get; set; }

        public int Stock {  get; set; }

        public int? Barcode { get; set; }

        public ProductFeature ProductFeature { get; set; } = new ProductFeature();

          public int CategoryId { get; set; }

        // [ForeignKey("Category_Id")]
          public Category? Category { get; set; }



    }
}
