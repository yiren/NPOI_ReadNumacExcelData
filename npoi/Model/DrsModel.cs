using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LungmenSoftware.Models.DRS
{
    public class DrsModel
    {
        public string SystemName { get; set; }
        public string DrsPanelName { get; set; }
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
        public string DrsPanelName { get; set; }

        public Guid SystemId { get; set; }
        public DrsSystem DrsSystem { get; set; }
   
        public ICollection<FID> FIDs { get; set; }

    }

    public class FID
    {
        public Guid FidId { get; set; }

        public string Description { get; set; }

        
        public string FidDiagramNo { get; set; }

       
        public string ModuleType { get; set; }

        public int Division { get; set; }

        
        public string EPROMSpecNo { get; set; }
        
        public string Checksum { get; set; }

        
        public string FidRev { get; set; }

        public string EpromRev { get; set; }

        public Guid DrsPanelId { get; set; }
       
        public DrsPanel DrsPanel { get; set; }
    }
}