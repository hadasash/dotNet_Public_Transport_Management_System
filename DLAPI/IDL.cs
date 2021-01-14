using System;
using System.Collections.Generic;

//using DO;

namespace DLAPI
{
    //CRUD Logic:
    // Create - add new instance
    // Request - ask for an instance or for a collection
    // Update - update properties of an instance
    // Delete - delete an instance
    public interface IDL
    {
        #region Station
        IEnumerable<DO.LineStation> GetAllLineStationsPerStation(int code);
        DO.Station GetStation(int code);
        IEnumerable<DO.Station> GetAllStations();
        void AddStation(DO.Station station);
        void UpdateStation(DO.Station station);
        void UpdateStation(int code, Action<DO.Station> update); //method that knows to updt specific fields in Station
        void DeleteStation(int code);

        #endregion

        #region Line
        DO.Line GetLine(int LineId);
        IEnumerable<DO.Line> GetAllLines();
        void AddLine(DO.Line line);
        void UpdateLine(DO.Line line);
        void UpdateLine(int idLine, Action<DO.Line> update); 
        void DeleteLine(int idLine); 
        #endregion

        #region Stations In Line//line station
        IEnumerable<DO.LineStation> GetStationsInLineList(Predicate<DO.LineStation> predicate);
        //  IEnumerable<DO.LineStation> GetAlllineStations();
        DO.LineStation GetLineStation(int ID);
        DO.LineStation GetLineStation(int id, int code);
        void AddStationInLine(int lineID, int statCode, int lineStationIndex);
        void UpdateStationInLine(int lineID, int statCode, int lineStationIndex);
        void DeleteStationInLine(int lineID, int statCode);
        void DeleteStationsFromAllLines(int statCode);
        void DeleteAllLineStationsPerLine(int lineID);
        IEnumerable<DO.AdjacentStations> GetAdjacentStationsByFirstOfPair(int code);
        IEnumerable<DO.AdjacentStations> GetAdjacentStationsBySecondOfPair(int code);
        #endregion
        #region User
        DO.User GetUser(string name);
        IEnumerable<DO.User> GetAllUsers();
        void AddUser(DO.User user);
        #endregion

    }

}
