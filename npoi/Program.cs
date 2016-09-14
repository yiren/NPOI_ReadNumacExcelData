using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using npoi.Model;
using Npoi.Mapper;

namespace npoi
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = new Mapper("D:\\GitRep\\npoi\\npoi\\NUMAC_EPROM_Info.xlsx");
            var excelData = mapper.Take<NumacSheetModel>("Table 2").ToList();
            List<NumacSystem> systems=new List<NumacSystem>(); 
            List<Chassis> chasses=new List<Chassis>();
            List<ModuleBoard> boards=new List<ModuleBoard>();
                       

            for (int i = 0; i < excelData.Count(); i++)
            {
                

            }
            Console.ReadLine();
        }
    }
}
