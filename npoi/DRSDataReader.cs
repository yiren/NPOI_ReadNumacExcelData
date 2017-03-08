using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LungmenSoftware.Models.DRS;
using Npoi.Mapper;

namespace npoi
{
    public class DRSDataReader
    {
        public void ReadDataFromExcel()
        {
            var mapper = new Mapper("D:\\GitRepository\\NPOI_ReadNumacExcelData\\npoi\\NUMAC_EPROM_Info.xlsx");
            var excelData = mapper.Take<DrsModel>("fidlist").ToList();
        }
    }
}
