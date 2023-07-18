using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sklep
{
    public class Products
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeName { get; set; }
        public float Price { get; set; }
        public string Path { get; set; }
    }
}