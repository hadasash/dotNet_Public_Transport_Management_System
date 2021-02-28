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
        IEnumerable<BO.Line> GetAllLinesPerStation(int code);
         IEnumerable<BO.Station> GetAllStations();
         BO.Station GetStation(int code);
         void UpdateStationPersonalDetails(BO.Station station);
         void AddStation(DO.Station station);
         void DeleteStation(int code);

        #endregion
        //Add Station to line
        //get all lines for stations
        //get stations /get station
        //delete station
        //update station

        #region Line

        BO.Line GetLine(int lineID);
        IEnumerable<BO.Line> GetAllLines();
        void UpdateLinePersonalDetails(BO.Line line);
        void AddLine(DO.Line line);
        void DeleteLine(int lineID);

        #endregion
        //add line
        //get lines /get line
        //delete line
        //update line

        #region Station In Line
        void AddStationInLine(int statCode, int lineID, int index = 0);
        void UpdateStationIndexInLine(int statCode, int lineID, int index);
        void DeleteStationInLine(int statCode, int lineID);
        IEnumerable<BO.LineStation> GetAllStationInLine(int id);

        #endregion
        //add line
        //get lines /get line
        //delete line
        //update line

        #region User
        BO.User GetUser(string name);
        void AddUser(DO.User user);
        IEnumerable<BO.User> GetAllUsers();
        #endregion
        // get user 
        // add user
        // get all users

        #region LineTrip
        IEnumerable<BO.LineTrip> GetAllLineTripPerLine(int lineid);
        #endregion
        //Get All Line Trip Per Line

        #region Time
        IEnumerable<BO.Time> GetTimePerStation(BO.Station stationBO, TimeSpan currentTime);
        #endregion
        //Get Time Per Station
        void restartXmlLists();
    }
}
