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
        #endregion

        #region Line
        DO.Line GetLine(int LineId);
        IEnumerable<DO.Line> GetAllLines();
        void Add(DO.Line line);
        void UpdateLine(DO.Line line);
        void UpdateLine(int idLine, Action<DO.Line> update); 
        void DeleteLine(int idLine); 
        #endregion

        #region Station In Line
        IEnumerable<DO.LineStation> GetStationsLineInList(Predicate<DO.LineStation> predicate);
        #endregion
    }

}
