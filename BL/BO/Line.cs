using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    
    public class Line
    {
        public int LineId { get; set; }
        public int NumOfBus { get; set; }
        IEnumerable<LineStation> LineStations { set; get; }
    }
}
