using System;
using System.Collections.Generic;

#nullable disable

namespace projetAsp.Models
{
    public partial class Download
    {
        public int DownloadId { get; set; }
        public int UserId { get; set; }
        public DateTime DownloadDate { get; set; }
        public string DownloadFilename { get; set; }
        public string ProductCode { get; set; }
    }
}
