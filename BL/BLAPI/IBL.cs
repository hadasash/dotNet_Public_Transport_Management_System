using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;


namespace BLAPI
{
    public interface IBL
    {
        #region Station
        BO.Station GetStation(int code);
        IEnumerable<BO.Station> GetAllStations();
        #endregion
       
    }
}
