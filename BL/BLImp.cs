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
        /// <summary>
        /// Returns all lines that pass through a particular station
        /// </summary>
        /// <param name="code">code station</param>
        /// <returns></returns>
        public IEnumerable<BO.Line> GetAllLinesPerStation(int code)
        {
            return from lineStation in dl.GetAllLineStationsPerStation(code)
                   let line = dl.GetLine(lineStation.LineId)
                   select line.CopyToListOfLines(lineStation);
        }
        /// <summary>
        /// Conversion between Bo and DO
        /// </summary>
        /// <param name="stationDO">STATION</param>
        /// <returns>bo.station</returns>
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

            var t = (from sil in dl.GetStationsInLineList(sil => sil.Code == code) select sil).ToList();

            stationBO.ListOfLines = (from sil in dl.GetStationsInLineList(sil => sil.Code == code)
                                     let line = dl.GetLine(sil.LineId)
                                     select line.CopyToListOfLines(sil)).ToList();

            return stationBO;
        }
        /// <summary>
        /// returns all the stations
        /// </summary>
        /// <returns>bo.station</returns>
        public IEnumerable<BO.Station> GetAllStations()
        {

            return from item in dl.GetAllStations()
                   select stationDoBoAdapter(item);
        }
        /// <summary>
        /// return a station
        /// </summary>
        /// <param name="code">code</param>
        /// <returns>bo.station</returns>
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
        /// <summary>
        /// Update Station Details
        /// </summary>
        /// <param name="station">station details</param>
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
        /// <summary>
        /// delete a station
        /// </summary>
        /// <param name="code">code station</param>
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
        /// <summary>
        /// add a station
        /// </summary>
        /// <param name="station">do.station</param>
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
        /// <summary>
        /// Conversion between Bo and DO
        /// </summary>
        /// <param name="stationDO">line</param>
        /// <returns>bo.line</returns>
        public BO.Line lineDoBoAdapter(DO.Line lineDO)
        {
            DO.Line newlineDO;
            BO.Line lineBO = new BO.Line();
            int id = lineDO.LineId;
            try
            {
                newlineDO = dl.GetLine(id);//if code is legal, returns a new lineStationDO. if not- ecxeption.
            }
            catch (DO.BadLineIDException ex)
            {
                throw new BO.BadLineIdException("Line bus number is illegal", ex);
            }

            lineDO.CopyPropertiesTo(lineBO);

            lineBO.LineStations = from lineStationDO in dl.GetStationsInLineList(lis=>lis.LineId==id)
                                  let lineStationBO = lineStationDoBoAdapter(lineStationDO)
                                  select lineStationBO;

            return lineBO;
        }
        /// <summary>
        /// returns all the lines
        /// </summary>
        /// <returns>bo.line</returns>
        public IEnumerable<BO.Line> GetAllLines()
        {
            return from lneDO in dl.GetAllLines()
                   select lineDoBoAdapter(lneDO);
        }
        /// <summary>
        /// returnes a line
        /// </summary>
        /// <param name="lineID"> line id</param>
        /// <returns>bo.line</returns>
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
        /// <summary>
        /// update line details
        /// </summary>
        /// <param name="line">line details</param>
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
        /// <summary>
        /// add a line 
        /// </summary>
        /// <param name="line">line</param>
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
        /// <summary>
        /// delete a line
        /// </summary>
        /// <param name="lineID"> line id</param>
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
       /// <summary>
       /// add a station in a line
       /// </summary>
       /// <param name="statCode">station code</param>
       /// <param name="lineID"> line id</param>
       /// <param name="index">index</param>
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
        /// <summary>
        /// Update the Station Index In a Line
        /// </summary>
        /// <param name="statCode">station code</param>
        /// <param name="lineID">line id</param>
        /// <param name="index">index</param>
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
        /// <summary>
        /// delite a station in a line
        /// </summary>
        /// <param name="lineID">line id</param>
        /// <param name="statCode"> station code</param>
        public void DeleteStationInLine(int lineID,  int statCode)
        {
            try
            {
                dl.DeleteStationInLine(lineID, statCode);
            }
            catch (DO.BadStationCodeLineID ex)
            {
                throw new BO.BadStationCodeLineIDException("Station code and Line ID is Not exist", ex);
            }
        }
        /// <summary>
        /// Conversion between do and bo
        /// </summary>
        /// <param name="lineStationDO">line station</param>
        /// <returns>bo.line station</returns>
        BO.LineStation lineStationDoBoAdapter(DO.LineStation lineStationDO)
        {
            BO.LineStation lineStationBO = new BO.LineStation();
            DO.LineStation newlineStationDO;//before copying lineStationDO to lineStationBO, we need to ensure that lineStationDO is legal- legal code.
            //sometimes we get here after the user filled lineStationDO fields. thats why we copy the given lineStationDO to a new lineStationDO and check if it is legal.
            int code = lineStationDO.Code;
            int lineId = lineStationDO.LineId;
            try
            {
                newlineStationDO = dl.GetLineStation( lineId,code);//if code is legal, returns a new lineStationDO. if not- ecxeption.
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station code is illegal\n", ex);
            }

            //copy "Code" and "LinestationIndex":
            //newlineStationDO.CopyPropertiesTo(lineStationBO);//copies- only flat properties.
            lineStationBO.Code = lineStationDO.Code;
            lineStationBO.LineStationIndex = lineStationDO.LineStationIndex;

            //copy "Name":
            lineStationBO.Name = dl.GetStation(code).Name;

            //copy "Distance" and "Time":
            if (lineStationBO.LineStationIndex == 0)//if its the 1st station in the line, the distance and time from the former station =0.
            {
                //lineStationBO.Time = 00:00:00 - default
                //lineStationBO.Distance = 0 - default
            }
            else
            {
                //distance from the former station: we look for the stations pair in which our current stat is the second in the pair.
                //it will let us find the distance and time from the former station to her.
                lineStationBO.Distance = dl.GetAdjacentStationsBySecondOfPair(code).FirstOrDefault(adj => adj.Station2 == code).Distance;
                //time from the former station:
                lineStationBO.Time = dl.GetAdjacentStationsBySecondOfPair(code).FirstOrDefault(adj => adj.Station2 == code).Time;
            }

            return lineStationBO;
        }
        /// <summary>
        /// returns all the station in a spesific line
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>line stations</returns>
        public IEnumerable<BO.LineStation> GetAllStationInLine(int id)
        {
            return from sic in dl.GetStationsInLineList(sic => sic.LineId == id)
                   let lineStationBo = lineStationDoBoAdapter(sic)
                   select lineStationBo;
        }
        #endregion

        #region User
        /// <summary>
        /// Conversion between do and bo
        /// </summary>
        /// <param name="userDO">user do</param>
        /// <returns>user bo</returns>
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
        /// <summary>
        /// returns a user
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>user bo</returns>
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
        /// <summary>
        /// add a user
        /// </summary>
        /// <param name="user">user</param>
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
        /// <summary>
        /// returns all the users
        /// </summary>
        /// <returns>users</returns>
       public IEnumerable<BO.User> GetAllUsers()
        {
            return from item in dl.GetAllUsers()
                   select userDoBoAdapter(item);
        }
        #endregion
       
    }

}
