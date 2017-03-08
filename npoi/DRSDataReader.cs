using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungmenSoftware.Models.DRS;
using Npoi.Mapper;
using Spire.Pdf.General.Render.Decode.Jpeg2000;

namespace npoi
{
    public class DRSDataReader
    {
        public void ReadDataFromExcel()
        {
            var mapper = new Mapper("D:\\GitRepository\\NPOI_ReadNumacExcelData\\npoi\\DRS SCM Data.xlsx");
            var excelData = mapper.Take<DrsModel>("fidlist").ToList();
            int j = 0;
            List<DrsSystem> systems=new List<DrsSystem>();
            List<DrsPanel> panels=new List<DrsPanel>();
            List<FID> fids=new List<FID>();
            DrsDbContext db = new DrsDbContext();
            for (int i = 0; i < excelData.Count; i++)
            {
                var data = excelData[i].Value;
                var systemRecord = systems.Where(s => s.SystemName.Equals(data.SystemName)).ToList();
                var panelRecord = panels.Where(p => p.DRSPanelName.Equals(data.DRSPanelName)).ToList();
                #region systemRecord


                if (systemRecord.Count < 1)
                {
                    DrsSystem system = new DrsSystem()
                    {
                        SystemId = Guid.NewGuid(),
                        SystemName = data.SystemName
                    };
                    systems.Add(system);
                    
                }
                if (panelRecord.Count < 1)
                {
                    DrsPanel panel = new DrsPanel()
                    {
                        DrsPanelId = Guid.NewGuid(),
                        DRSPanelName = data.DRSPanelName
                    };
                    panels.Add(panel);
                }
                #endregion               
            }

            for (int i = 0; i < excelData.Count; i++)
            {
                var data = excelData[i].Value;
       
                var currSys = systems.First(s => s.SystemName.Equals(data.SystemName));
                var currPanel = panels.First(p => p.DRSPanelName.Equals(data.DRSPanelName));
                currPanel.SystemId = currSys.SystemId;
                
                    
                    FID fid = new FID()
                    {
                        FidId = Guid.NewGuid(),
                        Checksum = data.Checksum,
                        Description = data.Description,
                        Division = data.Division,
                        DrsPanelId = currPanel.DrsPanelId,
                        FIDRev = data.FIDRev,
                        EPROMRev = data.EPROMRev,
                        EPROMSpecNo = data.EPROMSpecNo,
                        FIDDiagramNo = data.FIDDiagramNo,
                        ModuleType = data.ModuleType
                    };
                    fids.Add(fid);
                    j++;
                    Console.WriteLine(j);
            }
            db.DrsSystems.AddRange(systems);
            db.DrsPanels.AddRange(panels);
            db.FIDs.AddRange(fids);

            Console.WriteLine(db.SaveChanges());
            
            
        }      
        
        }
    }
