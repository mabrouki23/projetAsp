using System;
using System.Collections.Generic;

#nullable disable

namespace projetAsp.Modelsmusic
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
