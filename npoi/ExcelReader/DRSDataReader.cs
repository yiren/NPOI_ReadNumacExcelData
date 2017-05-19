using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
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

        public void SaveDbDataToExcel()
        {
            var mapper= new Mapper();
            DrsDbContext db = new DrsDbContext();
            var data = db.FIDs.ToList();
            //mapper.Save("D:\\GitRepository\\NPOI_ReadNumacExcelData\\npoi\\text.xlsx", data,"DRS FID");
            string path = @"D:\\GitRepository\\NPOI_ReadNumacExcelData\\npoi\\test.xlsx";
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                mapper.Save(fs, data, "DRS FID");
            }
            //using (MemoryStream ms=new MemoryStream())
            //{
            //    mapper.Save(ms,data);
            //    Console.WriteLine("xlsx File Saved!");

            //}

        }

        public void UseClosedXMLToExportExcel()
        {
            DrsDbContext db = new DrsDbContext();
            string path = @"D:\\GitRepository\\NPOI_ReadNumacExcelData\\npoi\\test.xlsx";
            var data = db.FIDs.ToList();
            var wb =new XLWorkbook();
            var ws = wb.Worksheets.Add("Test");
            
            
            ws.Cell(1, 1).Value = data.AsEnumerable();
            ws.Columns().AdjustToContents();
            
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                wb.SaveAs(fs);
            }
            Console.WriteLine("xlsx File Saved!");

        }


        
        }
    }
