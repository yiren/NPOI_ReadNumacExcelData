using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace npoi.Model
{
    class NumacModel
    {

    }

    class NumacSystem
    {
        public Guid SystemId { get; set; }
        public string Name { get; set; }
        public string Panel { get; set; }

        public ICollection<Chassis> Chassis { get; set; }
    }

    class Chassis
    {
        public Guid ChassisId { get; set; }
        public string ChassisName { get; set; }

        public Guid SystemId { get; set; }
        public ICollection<ModuleBoard> ModuleBoards { get; set; }

        
    }

    class ModuleBoard
    {
        public Guid ModuleBoardId { get; set; }
        public string ModuleBoardName { get; set; }
        public string SocketLocation { get; set; }
        public string SerialNumber { get; set; }
        public string Assembly { get; set; }
        public string Program { get; set; }
        public string Rev { get; set; }

        public Guid ChassisId { get; set; }
        public Chassis Chassis { get; set; }
    }
}
