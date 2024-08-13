using System.ComponentModel.DataAnnotations;

namespace Concurrency.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; } 
        public string? Description { get; set; }
        // 1.yol    [Timestamp] // sürekli güncellensin
        public byte[] RowVersion { get; set; }
    }
}
