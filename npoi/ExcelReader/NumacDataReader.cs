using Npoi.Mapper;
using npoi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi
{
    public class NumacDataReader
    {
        public void ReadDataFromExcel()
        {
            var mapper = new Mapper("D:\\GitRepository\\NPOI_ReadNumacExcelData\\npoi\\NUMAC_EPROM_Info.xlsx");
            var excelData = mapper.Take<NumacSheetModel>("fidlist").ToList();

            List<NumacSystem> systems = new List<NumacSystem>();
            List<Chassis> chasses = new List<Chassis>();
            List<ModuleBoard> boards = new List<ModuleBoard>();

            for (int i = 0; i < excelData.Count; i++)
            {
                var data = excelData[i].Value;
                var systemRecord = systems.Where(s => s.Name.Equals(data.System) && s.Panel.Equals(data.Panel)).ToList();
                if (systemRecord.Count < 1)
                {
                    NumacSystem system = new NumacSystem()
                    {
                        SystemId = Guid.NewGuid(),
                        Name = data.System,
                        Panel = data.Panel
                    };
                    systems.Add(system);
                    if (chasses.Where(c => c.ChassisName.Equals(data.ChassisName)).ToList().Count < 1)
                    {

                        Chassis chassis = new Chassis()
                        {
                            ChassisId = Guid.NewGuid(),
                            ChassisName = data.ChassisName,
                            SystemId = system.SystemId
                        };
                        chasses.Add(chassis);

                        ModuleBoard board = new ModuleBoard()
                        {
                            ModuleBoardId = Guid.NewGuid(),
                            ModuleBoardName = data.ChassisBoardName,
                            SocketLocation = data.SocketLocation,
                            Assembly = data.EpromAssembly,
                            SerialNumber = data.SerialNumber,
                            Program = data.Program,
                            Rev = data.Revision,
                            ChassisId = chassis.ChassisId
                        };
                        boards.Add(board);

                    }
                }
                else
                {
                    var chassisRecord = chasses.Where(c => c.ChassisName.Equals(data.ChassisName)).ToList();
                    if (chassisRecord.Count < 1)
                    {
                        var system = systemRecord.First();
                        Chassis chassis = new Chassis()
                        {
                            ChassisId = Guid.NewGuid(),
                            ChassisName = data.ChassisName,
                            SystemId = system.SystemId
                        };
                        chasses.Add(chassis);

                        ModuleBoard board = new ModuleBoard()
                        {
                            ModuleBoardId = Guid.NewGuid(),
                            ModuleBoardName = data.ChassisBoardName,
                            SocketLocation = data.SocketLocation,
                            Assembly = data.EpromAssembly,
                            SerialNumber = data.SerialNumber,
                            Program = data.Program,
                            Rev = data.Revision,
                            ChassisId = chassis.ChassisId
                        };
                        boards.Add(board);
                    }
                    else
                    {
                        var chassis = chassisRecord.First();
                        ModuleBoard board = new ModuleBoard()
                        {
                            ModuleBoardId = Guid.NewGuid(),
                            ModuleBoardName = data.ChassisBoardName,
                            SocketLocation = data.SocketLocation,
                            Assembly = data.EpromAssembly,
                            SerialNumber = data.SerialNumber,
                            Program = data.Program,
                            Rev = data.Revision,
                            ChassisId = chassis.ChassisId
                        };
                        boards.Add(board);
                    }
                }
            }
            NumacDbContext db = new NumacDbContext();
            db.NumacSystems.AddRange(systems);
            db.ModuleBoards.AddRange(boards);
            db.Chassis.AddRange(chasses);
            db.SaveChanges();
            Console.WriteLine(boards.Count);
        }
        
    }
}
