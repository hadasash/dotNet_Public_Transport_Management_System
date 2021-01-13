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

        BO.Station stationDoBoAdapter(DO.Station stationDO);
         IEnumerable<BO.Station> GetAllStations();
         BO.Station GetStation(int code);
         void UpdateStationPersonalDetails(BO.Station station);
         void AddStation(DO.Station station);
         void DeleteStation(int code);

        #endregion

        #region Line

        BO.Line GetLine(int lineID);
        IEnumerable<BO.Line> GetAllLines();
        void UpdateLinePersonalDetails(BO.Line line);
        void AddLine(DO.Line line);
        void DeleteLine(int lineID);

        #endregion

        #region Station In Line
        void AddStationInLine(int statCode, int lineID, int index = 0);
        void UpdateStationIndexInLine(int statCode, int lineID, int index);
        void DeleteStationInLine(int statCode, int lineID);
        IEnumerable<BO.LineStation> GetAllStationInLine(int id);

        #endregion

        #region User
        BO.User userDoBoAdapter(DO.User userDO);
        BO.User GetUser(string name);
        void AddUser(DO.User user);
        IEnumerable<BO.User> GetAllUsers();
        #endregion

    }
}
