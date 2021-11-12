using System;
using System.Collections.Generic;

#nullable disable

namespace projetAsp.Modelsmusic
{
    public partial class Lineitem
    {
        public int LineItemId { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
