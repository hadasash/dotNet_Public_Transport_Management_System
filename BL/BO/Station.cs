using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class Station
    {
        public int Code { get; set; }
        public string Name { get; set; }
        IEnumerable<LineInStation> LinesInStation { get; set; }
    }
}
