// See https://aka.ms/new-console-template for more information 

using AutoMapper.QueryableExtensions;
using EFCore.CodeFirst0;
using EFCore.CodeFirst0.DAL;
using EFCore.CodeFirst0.DTOs;
using EFCore.CodeFirst0.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

Initializer.Build();
using (var _context = new AppDbContext())
{      //Configuration1 ve 2        //paginition sayfalama

                   //TRANSACTİONNN
              //SAVECHANGES TRANSSACTİON YAPISI      

   
//    using(var transaction = _context.Database.BeginTransaction())
//    { 
//            var category = new Category() { Name = "Kılıflar" };

//            _context.Categories.Add(category);
//            await _context.SaveChangesAsync(); // 2 savechange kullanıyoruz  çünkü categoryId yi almamız lazım

//            Product product = new()
//            {
//                Name = "Kılıf 1",
//                Price = 100,
//                Stock = 200,
//                Barcode = 1234,
//                CategoryId = category.Id
//            };

//            _context.Products.Add(product);

//            await _context.SaveChangesAsync();
//            transaction.Commit();
//        }  
//        }  

//Console.WriteLine();




   

                                 //AUTO MAPPER İLE MAPPİNG İŞLEMİ
  //  var product = _context.Products.ToList(); //tüm değerler geliyor   
  //  var productDto = ObjectMapper.Mapper.Map<List<ProductDto>>(product); // üstteki gelen tüm verileri map le  istediğin değerler gelir

          
    // bu ikiside aynı üstte sql cümle kullanacaksam product tolist öncesinde kullanılabilinir
    //üsttekinde önce tüm datayı çek sonra map le  bunda ise direkt çekiyor maplediğini bunu kullan kullanacaksan
    //  var productDto=_context.Products.ProjectTo<ProductDto>(ObjectMapper.Mapper.ConfigurationProvider).Where(x=> x.Price>10).ToList();
                                                                             // where ile sql cümlede kullanılabilir


   // Console.WriteLine();

               //              //AUTOMAPPER KULLANMAK İSTEMESSEM ŞU ŞEKİLDE 
    //var productsDto = _context.Products.Select(x => new ProductDto()
    //{
    //    Id = x.Id,
    //    Name = x.Name,
    //    Price = x.Price,
    //    Stock = x.Stock

    //});
    //Console.WriteLine();


                                           //STORE PROCEDURE
    //var id1 = 1;
    //var price1 = 50;
    //////Parametre alan storeProcedured çagırma  burada parametreler dışardan gelecek 
    //var productss1 = await _context.Products.FromSqlInterpolated($"sp_get_product_full_parameters  {id1},{price1}").ToListAsync();

    //Console.WriteLine();

    //storeproduce2 where sql server tarafında yapılmaz client tarafında yapılır 
    //  var productss1 = await _context.Products.FromSqlRaw("sp_get_product_full").ToListAsync();
    // bu şekilde where yapılabilir  ha direkt nasıl yapılır function ile 
    //  var productss2 = productss1.Where(x => x.Price > 200);
    //storeproduce1
    //  var productss= await  _context.Products.FromSqlRaw("sp_get_products").ToListAsync();





    // var id = 3;
    //decimal price = 50;
    //  var products = await  _context.Products.FromSqlRaw(" select * from Products").FirstAsync();
    // id değeri 3 olanları getir olanı firstasync
    // var products1 = await _context.Products.FromSqlRaw("SELECT * FROM Products WHERE Id = {0}", id).FirstOrDefaultAsync();

    // price değeri 300 den büyük olanı getir
    // var products2 = await _context.Products.FromSqlRaw("SELECT * FROM Products WHERE price>{0}", price).FirstOrDefaultAsync();
    // aynı değeri döndürür daha uygundur
    //var products3 = await _context.Products.FromSqlInterpolated($"select * from products where price>{price}").FirstAsync();

    //Console.WriteLine("işlem bitti");


    //x category ıd   y ise product a bağlı categoryıd new ile yeni class oluşturup yazdırıuyouz
    // 2 li join
    //var result = _context.Categories.Join(_context.Products, x => x.Id, y => y.CategoryId, (c, p) => new
    //{
    //    CategoryName = c.Name,
    //    ProductName = p.Name,
    //    ProductPrice= p.Price
    //}).ToList();

    //3 lü join
    //var result = _context.Categories
    //    .Join(_context.Products, c => c.Id, p => p.CategoryId, (c, p) => new { c, p })  //x product y category
    //    .Join(_context.ProductFeature, x => x.p.Id, y => y.Id, (c, pf) => new                   // x product y product feature
    //    {
    //        CategoryName = c.c.Name,
    //        ProductName = c.p.Name,
    //        ProductFeatureColor= pf.Color

    //    });                                   

    //sql kodlarıyla

    //var result2 = (from c  in _context.Categories
    //               join p  in _context.Products on c.Id equals p.CategoryId
    //               join pf in _context.ProductFeature on p.Id equals pf.Id
    //               select new
    //               {
    //                   CategoryName = c.Name,
    //                   ProductName = p.Name,
    //                   ProductFeatureColor = pf.Color
    //               }).ToList();

    //var result2 = (from c in _context.Categories
    //               join p in _context.Products on c.Id equals p.CategoryId
    //               join pf in _context.ProductFeature on p.Id equals pf.Id
    //               select new{c,p,pf}).ToList();

    //Console.WriteLine("işlem bitti");   




    //var category = new Category() { Name = "Kalemler" };
    //category.Products.Add(new Product
    //{
    //    Name = "Kalemler 1",
    //    Price = 100,
    //    Stock = 200,
    //    Barcode = 1234,
    //    ProductFeature = new ProductFeature
    //    {
    //        Color = "Red",
    //        height = 200,
    //        Width = 100
    //    }
    //});

    //category.Products.Add(new Product
    //{
    //    Name = "Kalemler 2",
    //    Price = 100,
    //    Stock = 200,
    //    Barcode = 1234,
    //    ProductFeature = new ProductFeature
    //    {
    //        Color = "Red",
    //        height = 200,
    //        Width = 100
    //    }
    //});

    //category.Products.Add(new Product
    //{
    //    Name = "Kalemler 3",
    //    Price = 100,
    //    Stock = 200,
    //    Barcode = 1234,
    //    ProductFeature = new ProductFeature
    //    {
    //        Color = "Red",
    //        height = 200,
    //        Width = 100
    //    }
    //});

    //category.Products.Add(new Product
    //{
    //    Name = "Kalemler 4",
    //    Price = 100,
    //    Stock = 200,
    //    Barcode = 1234,
    //    ProductFeature = new ProductFeature
    //    {
    //        Color = "Red",
    //        height = 200,
    //        Width = 100
    //    }
    //});
    //_context.Categories.Add(category);
    //_context.SaveChanges();

    //Console.WriteLine("işlem bitti");




    // var persons = _context.People.ToList().Where(x=> FormatPhone(x.Phone) == "554151652156").ToList(); // ilk tolist memory e alır verileri
    //daha sonra memory den buradaki methodları kullanarak işlem yapabilir buradaki metodlar direkt database içerisinden işlem yapamaz.


    //var persons=_context.People.ToList().Select(p => new {PersonName=p.Name, PersonPhone= FormatPhone(p.Phone)}).ToList();
    //Console.WriteLine("işlem bitti");



    // _context.People.Add(new Person() { Name = "ahmet", Phone   =  "0554151652156" }); //db ye kaydetme
    // _context.People.Add(new Person() { Name = "mehmet", Phone  = "0326189151185" });
    //await  _context.SaveChangesAsync();



    //string FormatPhone(string phone)
    //{
    //    return phone.Substring(1, phone.Length - 1);     // 0 ı alma 
    //}




    //var product = new Product { Name = "silgi", Price = 100, Stock = 300, Barcode = 1234, Category = new() {Name="Silgiler" } };

    //_context.Products.Add(product);
    //_context.SaveChanges();




    //Console.WriteLine("KAYDEDİLDİ");




    //dBCONTEXT CHANGETRACER 
    //var products = await  _context.Products.Where(x=> x.Id > 10).ToListAsync();

    //products.ForEach(p =>
    //{
    //    Console.WriteLine($"{p.Id} - {p.Name} -{p.Price} ");
    //});

    //products.ForEach(p =>
    //{
    //    var state = _context.Entry(p).State;

    //    Console.WriteLine($"{p.Id}: {p.Name} :{p.Stock} State:{state} ");
    //});









    //_context.Products.Add(new() { Name = "kalem", Price = 200, Stock = 100, Barcode = 123 });
    //_context.Products.Add(new() { Name = "kalem", Price = 200, Stock = 100, Barcode = 123 });
    //_context.Products.Add(new() { Name = "kalem", Price = 200, Stock = 100, Barcode = 123 });

    //_context.SaveChanges();





    //var product = await _context.Products.FirstAsync();
    //var newProduct = new Product { Name = "kalem 200", Price = 200, Stock = 100, Barcode = 333 };
    //Console.WriteLine($"ilk state : {_context.Entry(product).State} ");

    //product.Stock = 1000;


    //Console.WriteLine($"Son state : {_context.Entry(product).State} ");





    // Console.WriteLine($"state after sava changes {_context.Entry(product).State}");
    //await _context.AddAsync(product);







}



