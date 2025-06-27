using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arrumar_Impressora.Models
{
    public class DriverConfig
    {
        public int print_qual { get; set; }
        public int printhead_time { get; set; }
    }
    // That object is just for json parsing be like the printer patterns.
    class DriverConfigObj {
        public DriverConfig? driver_config { get; set; }
    }
}