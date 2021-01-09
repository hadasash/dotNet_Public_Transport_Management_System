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
        #region station
        DO.Station GetStation(int code);
        IEnumerable<DO.Station> GetAllStations();
        #endregion
    }
}
