using AutoMapper;
using EFCore.CodeFirst0.DAL;
using EFCore.CodeFirst0.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst0.Mappers
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy= new Lazy<IMapper> ( () =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });
            return config.CreateMapper();
        });
        public static IMapper Mapper => lazy.Value; 
    }
    internal class CustomMapping:Profile
    {
        public CustomMapping() 
        {
  CreateMap<ProductDto, Product>().ReverseMap(); //productsdto sınıfını product sınıfına map letam tersini yapacaksan .ReverseMap() kullan sonuna

        }
    }
}
