using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BO;


namespace BL
{
    class BLImp : IBL //internal
    {
        IDL dl = DLFactory.GetDL();
        #region station
        public BO.Station GetStation(int code)
        {
            DO.Station stationDO; 
            stationDO = dl.GetStation(code);
            
            return stationDoBoAdapter(stationDO);
        }
        BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
           
            int code = stationDO.Code;

            stationDO.CopyPropertiesTo(stationBO);
            
            

            return stationBO;
        }
        public IEnumerable<BO.Station> GetAllStations()
        {
            
            return from item in dl.GetAllStations()
                   select stationDoBoAdapter(item);
        }
        #endregion
    }

}
