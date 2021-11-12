using System;
using System.Collections.Generic;

#nullable disable

namespace projetAsp.Modelsmusic
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int UserId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public float TotalAmount { get; set; }
        public string IsProcessed { get; set; }
    }
}
