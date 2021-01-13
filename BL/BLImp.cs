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

        public BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            DO.Station newStationDO;
            int code = stationDO.Code;
            try
            {
                newStationDO = dl.GetStation(code);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station code is illegal", ex);
            }
            newStationDO.CopyPropertiesTo(stationBO);

            stationDO.CopyPropertiesTo(stationBO);

            var t = (from sil in dl.GetStationsInLineList(sil => sil.Station == code) select sil).ToList();

            stationBO.ListOfLines = (from sil in dl.GetStationsInLineList(sil => sil.Station == code)
                                     let line = dl.GetLine(sil.LineId)
                                     select line.CopyToListOfLines(sil)).ToList();

            return stationBO;
        }
        public IEnumerable<BO.Station> GetAllStations()
        {

            return from item in dl.GetAllStations()
                   select stationDoBoAdapter(item);
        }
        public BO.Station GetStation(int code)
        {
            DO.Station stationDO;
            try
            {
                stationDO = dl.GetStation(code);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station code does not exist or he is not a station", ex);
            }
            return stationDoBoAdapter(stationDO);
        }
        public void UpdateStationPersonalDetails(BO.Station station)
        {
            //Update DO.Station            
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dl.UpdateStation(stationDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station code is illegal", ex);
            }

            

        }
        public void DeleteStation(int code)
        {
            try
            {
                dl.DeleteStation(code);
                
                dl.DeleteStationsFromAllLines(code);
            }
            catch (DO.BadStationCodeLineID ex)
            {
                throw new BO.BadStationCodeLineIDException("Station code and Line ID is Not exist", ex);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station id does not exist or he is not a station", ex);
            }
        }
        public void AddStation(DO.Station station)
        {
            try
            {
                dl.AddStation(station);
            }
            catch (DO.BadStationCodeLineID ex)
            {
                throw new BO.BadStationCodeLineIDException("Station is exist", ex);
            }
        }


        #endregion

        #region Line
        //Adi- Add, Update, Delete
      
        public BO.Line lineDoBoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            int id = lineDO.LineId;
            lineDO.CopyPropertiesTo(lineBO);

            lineBO.LineStations = from lis in dl.GetStationsInLineList(lis => lis.LineId == id)
                                 let linestation = dl.GetLineStation(lis.LineId)
                                 select (BO.LineStation)linestation.CopyPropertiesToNew(typeof(BO.LineStation));
            return lineBO;
        }
        public IEnumerable<BO.Line> GetAllLines()
        {
            return from lneDO in dl.GetAllLines()
                   select lineDoBoAdapter(lneDO);
        }
        public BO.Line GetLine(int lineID)
        {

            DO.Line lineDO;
            try
            {
                lineDO = dl.GetLine(lineID);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIdException("Line id does not exist or he is not a line", ex);
            }
            return lineDoBoAdapter(lineDO);
        }
        public void UpdateLinePersonalDetails(BO.Line line)
        {
            DO.Line lineDO = new DO.Line();
            line.CopyPropertiesTo(lineDO);
            try
            {
                dl.UpdateLine(lineDO);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIdException("Line id is illegal", ex);
            }

        }
        public void AddLine(DO.Line line)
        {
            try
            {
                dl.AddLine(line);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIdException("Line exists", ex);
            }
        }
        public void DeleteLine(int lineID)
        {
            try
            {
                dl.DeleteLine(lineID);

                dl.DeleteAllLineStationsPerLine(lineID);
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIdException(" Line ID is Not exist", ex);
            }
           
        }
        #endregion

        #region Line Station
       
        public void AddStationInLine(int statCode, int lineID, int index = 0)
        {
            try
            {
                dl.AddStationInLine(statCode, lineID, index);
            }
            catch (DO.BadStationCodeLineID ex)
            {
                throw new BO.BadStationCodeLineIDException("Station code and Line ID is Not exist", ex);
            }
        }
       public void UpdateStationIndexInLine(int statCode, int lineID, int index)
        {
            try
            {
                dl.UpdateStationInLine(statCode, lineID, index);
            }
            catch (DO.BadStationCodeLineID ex)
            {
                throw new BO.BadStationCodeLineIDException("Station code and Line ID is Not exist", ex);
            }
        }
        public void DeleteStationInLine(int statCode, int lineID)
        {
            try
            {
                dl.DeleteStationInLine(statCode, lineID);
            }
            catch (DO.BadStationCodeLineID ex)
            {
                throw new BO.BadStationCodeLineIDException("Station code and Line ID is Not exist", ex);
            }
        }

        #endregion

        #region User
        public BO.User userDoBoAdapter(DO.User userDO)
        {
            BO.User userBO = new BO.User();
            DO.User newUserDO;
            string name = userDO.Name;
            try
            {
                newUserDO = dl.GetUser(name);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station code is illegal", ex);
            }
            newUserDO.CopyPropertiesTo(userBO);

            userDO.CopyPropertiesTo(userBO);

            return userBO;
        }
        public BO.User GetUser(string name)
        {
            DO.User userDO;
            try
            {
                userDO = dl.GetUser(name);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("User code does not exist or he is not a user", ex);
            }
            return userDoBoAdapter(userDO);
        }
        public void AddUser(DO.User user)
        {
            try
            {
                dl.AddUser(user);
            }
            catch (DO.BadStationCodeLineID ex)
            {
                throw new BO.BadStationCodeLineIDException("User is exist", ex);
            }
        }
       public IEnumerable<BO.User> GetAllUsers()
        {
            return from item in dl.GetAllUsers()
                   select userDoBoAdapter(item);
        }
        #endregion

    }

}
