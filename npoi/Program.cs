using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using npoi.Model;
using Npoi.Mapper;
using NPOI.SS.Formula.Functions;

namespace npoi
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var drsDataReader=new DRSDataReader();
            //drsDataReader.ReadDataFromExcel();
            drsDataReader.SaveDbDataToExcel();
            //drsDataReader.UseClosedXMLToExportExcel();
            Console.ReadLine();
        }
    }
}
