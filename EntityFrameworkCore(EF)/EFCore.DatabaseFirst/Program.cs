﻿// See https://aka.ms/new-console-template for more information


using EFCore.DatabaseFirst.DAL;
using Microsoft.EntityFrameworkCore;

DbContextInitializer.Build();

using (var _context = new AppDbContext())
{

    var products= await  _context.Products.ToListAsync();

    products.ForEach(p => 
    {
      Console.WriteLine($"{ p.id}: {p.Name} :{p.Stock} ");
    
    });
}


