using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Concurrency.Web.Controllers
{

    public class ProductsController : Controller
    {
        private readonly AppDbContext _Context;

        public ProductsController(AppDbContext context)
        {
            _Context = context;
        }

        public async Task<IActionResult> List()
        {
            return   View( await  _Context.Products.ToListAsync());  

        }


     public async Task<IActionResult>  Update(int id)
        {

            var product = await _Context.Products.FindAsync(id);

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {

            try
            {
                _Context.Products.Update(product);
                await _Context.SaveChangesAsync();

                return RedirectToAction(nameof(List));
            }
            catch (DbUpdateConcurrencyException exception)
            {
                var exceptionEntry = exception.Entries.First();

                var currentProduct = exceptionEntry.Entity as Product;

                var databaseValues=exceptionEntry.GetDatabaseValues(); // db deki mevcut değerler
                
                var databaseProducts = databaseValues.ToObject() as Product;
                var clientValues = exceptionEntry.CurrentValues;




                if (databaseValues == null)
                {
                    ModelState.AddModelError(string.Empty, "bu ürün başka bir kullanıcı tarafından silindi");

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "bu ürün başka bir kullanıcı tarafından Güncellendi");
                }

                return View();
               
            }

           
        }
     


    }
}
