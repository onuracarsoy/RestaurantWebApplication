﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductImage{ get; set; }

        public string ProductContent { get; set; }

        public decimal ProductPrice{ get; set; }

        public int CategoryID { get; set; } // Ürünün hangi kategoriye ait olduğunu belirten dış anahtar
        public Category Category { get; set; } // Ürünün kategori ile ilişkisini temsil eder

    }
}
