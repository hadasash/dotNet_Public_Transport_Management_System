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

        #region Line

        BO.Line GetLine(int lineID);
        IEnumerable<BO.Line> GetAllLines();
        void UpdateLinePersonalDetails(BO.Line line);
        void AddLine(int lineID);
        void DeleteLine(int lineID);

        #endregion

    }
}
