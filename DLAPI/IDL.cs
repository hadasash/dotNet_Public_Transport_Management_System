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
        DO.Station GetStation(int code);
        IEnumerable<DO.Station> GetAllStations();
        void AddStation(DO.Station person);
        void UpdateStation(DO.Station person);
        void UpdateStation(int code, Action<DO.Station> update); //method that knows to updt specific fields in Station
        void DeleteStation(int code);
        #endregion

        #region Line
        DO.Line GetLine(int LineId);
        IEnumerable<DO.Line> GetAllLines();
        #endregion

        #region Station In Line
        IEnumerable<DO.LineStation> GetLinesInStation(Predicate<DO.LineStation> predicate);
        void AddLineInStation(int lineID, int statCode, float grade = 0);
        void UpdateLineInStation(int lineID, int statCode, float lineStationIndex);
        void DeleteLineInStation(int lineID, int statCode);
        void DeleteLineInStation(int lineID);
        #endregion
    }

}
