using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Npoi.Mapper.Attributes;

namespace LungmenSoftware.Models.DRS
{
    public class DrsModel
    {
        public string SystemName { get; set; }
        public string DRSPanelName { get; set; }
        public string Description { get; set; }
        public string FIDDiagramNo { get; set; }
        public string ModuleType { get; set; }
        public int Division { get; set; }
        public string EPROMSpecNo { get; set; }
        public string Checksum { get; set; }
        public string FIDRev { get; set; }
        public string EPROMRev { get; set; }
    }

    public class DrsSystem
    {
        public Guid SystemId { get; set; }
        public string SystemName { get; set; }
       

        public ICollection<DrsPanel> DrsPanel { get; set; }
    }

    public class DrsPanel
    {
        public Guid DrsPanelId { get; set; }
        public string DRSPanelName { get; set; }

        public Guid SystemId { get; set; }
        public DrsSystem DrsSystem { get; set; }
   
        public ICollection<FID> FIDs { get; set; }

    }

    public class FID
    {
        [Ignore]
        public Guid FidId { get; set; }

        [Column("描述")]
        public string Description { get; set; }

        [Column("FID圖號")]
        public string FIDDiagramNo { get; set; }

       
        public string ModuleType { get; set; }

        public int Division { get; set; }

        
        public string EPROMSpecNo { get; set; }
        
        public string Checksum { get; set; }

        
        public string FIDRev { get; set; }

        public string EPROMRev { get; set; }
        [Ignore]
        public Guid DrsPanelId { get; set; }
       
        public DrsPanel DrsPanel { get; set; }
    }
}