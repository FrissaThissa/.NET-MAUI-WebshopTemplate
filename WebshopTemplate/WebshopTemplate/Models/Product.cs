using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopTemplate.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public string Size { get; set; }
        public List<Image> Images { get; set; }
    }
}
