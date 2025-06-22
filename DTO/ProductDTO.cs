using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int? Price { get; set; }
        public string? PathOfPicture { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryId { get; set; }
    }

}
