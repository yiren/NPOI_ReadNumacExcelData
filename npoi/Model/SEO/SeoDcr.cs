using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model.SEO
{
    class SeoDcr
    {
        public Guid DcrId { get; set; }
        [StringLength(100)]
        public string DcrNo { get; set; }
        [StringLength(100)]
        public string SeoNo { get; set; }
        [StringLength(10)]
        public string Unit { get; set; }
        [StringLength(100)]
        public string Sytem { get; set; }
        [StringLength(50)]
        public string Division { get; set; }
        [StringLength(100)]
        public string Room { get; set; }
        [StringLength(50)]
        public string Task { get; set; }
        [StringLength(100)]
        public string Rpe { get; set; }
        public bool IsSafety { get; set; }
        public bool IsASME { get; set; }
        public bool IsDCIS { get; set; }
        public bool IsSMP { get; set; }

        [StringLength(30)]
        public string Classification { get; set; }
        [StringLength(50)]
        public string RequestDate { get; set; }
        [StringLength(50)]
        public string ReceivedDate { get; set; }
        [StringLength(50)]
        public string ResponseDate { get; set; }
        public string ReviewComment { get; set; }
        [StringLength(20)]
        public string Section { get; set; }
        [StringLength(20)]
        public string Engineer { get; set; }
        public string Note { get; set; }



    }
}
