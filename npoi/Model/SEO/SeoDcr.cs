using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model.SEO
{
    class SeoDcr
    {
        public Guid DcrId { get; set; }
        public string DcrNo { get; set; }
        public string SeoNo { get; set; }
        public string Unit { get; set; }
        public string Sytem { get; set; }
        public string Division { get; set; }
        public string Room { get; set; }
        public string Task { get; set; }
        public string Rpe { get; set; }
        public bool IsSafety { get; set; }
        public bool IsASME { get; set; }
        public bool IsDCIS { get; set; }
        public bool IsSMP { get; set; }
        
        public string Classification { get; set; }
        public string RequestDate { get; set; }
        public string ReceivedDate { get; set; }
        public string ResponseDate { get; set; }
        public string ReviewComment { get; set; }
        public string Section { get; set; }
        public string Engineer { get; set; }
        public string Note { get; set; }



    }
}
