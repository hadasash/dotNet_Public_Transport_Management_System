using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace BO
{
    
    public class Line
    {
        public int LineId { get; set; }
        public int NumberBus { get; set; }
        public int FirstStation { get; set; }
        public int LastStation { get; set; }
        Areas Area { get; set; }
        public IEnumerable<LineStation> LineStations { set; get; }
    }
}
