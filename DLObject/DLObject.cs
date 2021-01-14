using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DLAPI;
using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDL //internal

    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        #region Station
        public DO.Station GetStation(int code)
        {
            DO.Station station = DataSource.listStations.Find(p => p.Code == code);
            //try { Thread.Sleep(2000); } catch (ThreadInterruptedException ex) { }
            if (station != null)
            {
                return station.Clone();
            }
            else
            {
                return null;
            }
            //else
            //    throw new DO.BadPersonIdException(id, $"bad student id: {id}");
        }

        public IEnumerable<DO.Station> GetAllStations()
        {
            return from station in DataSource.listStations
                   select station.Clone();
        }

        public void AddStation(DO.Station station)
        {
            var x = DataSource.listStations.ToList();
            if (DataSource.listStations.Where(s => s.Code == station.Code).ToList().Count()>0)
            {
                throw new DO.BadStationCodeException(station.Code, "Duplicate station Code");
            }
            DataSource.listStations.Add(station);
        }

        public void DeleteStation(int code)
        {
            DO.Station stat = DataSource.listStations.Find(s => s.Code == code);

            if (stat != null)
            {
                DataSource.listStations.Remove(stat);
            }
            else
                throw new DO.BadStationCodeException(code, $"bad station code: {code}"); 
        }
        public void UpdateStation(DO.Station station)
        {
            DO.Station mystation = DataSource.listStations.Find(s => s.Code == station.Code);
            if (mystation != null)
            {
                DataSource.listStations.Remove(mystation);
                DataSource.listStations.Add(station.Clone());
            }
            else
                throw new DO.BadStationCodeException(station.Code, $"bad station code: {station.Code}");
        }

        public void UpdateStation(int code, Action<DO.Station> update)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Line

        public DO.Line GetLine(int lineId)
        {
            DO.Line myLine = DataSource.listLines.Find(c => c.LineId == lineId);
            if (myLine != null)
            {
                return myLine.Clone();
            }
            else
            {
                throw new DO.BadLineIDException(lineId, $"Bad Line id");
            }
        }
        public IEnumerable<DO.Line> GetAllLines()
        {
            return from line in DataSource.listLines
                   select line.Clone();
        }
        public void AddLine(DO.Line line)
        {
            if (DataSource.listLines.FirstOrDefault(l => l.LineId == line.LineId) != null)
                throw new DO.BadLineIDException(line.LineId, "Duplicate line ID");
            //if (DataSource.listLines.FirstOrDefault(l => l.LineId == line.LineId) == null)
            //    throw new DO.BadLineIDException(line.LineId, "Missing line ID");
            DataSource.listLines.Add(line.Clone());
        }
        public void UpdateLine(DO.Line line)
        {
            DO.Line myline = DataSource.listLines.Find(l => l.LineId == line.LineId);
            if (myline != null)
            {
                DataSource.listLines.Remove(myline);
                DataSource.listLines.Add(line.Clone());
            }
            else
                throw new DO.BadLineIDException(line.LineId, $"bad line id: {line.LineId}");
        }
        public void UpdateLine(int lineId, Action<DO.Line> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLine(int lineId)
        {
            DO.Line myline = DataSource.listLines.Find(l => l.LineId == lineId);

            if (myline != null)
            {
                DataSource.listLines.Remove(myline);
            }
            else
                throw new DO.BadLineIDException(lineId, $"bad line id: {lineId}");
        }
        #endregion

        #region LineStation
        
        public IEnumerable<DO.LineStation> GetStationsInLineList(Predicate<DO.LineStation> predicate)
        {
            return from sil in DataSource.listLineStation
                   where predicate(sil)
                   select sil.Clone();
        }
        public DO.LineStation GetLineStation(int code)
        {

            DO.LineStation stat = DataSource.listLineStation.Find(s => s.Code == code);

            if (stat != null)//found the station
                return stat.Clone();
            else//didnt find the station
                throw new DO.BadStationCodeException(code, $"error in line station that its code is: {code}");
        }
        
          
        
        public void AddStationInLine(int lineID, int statCode, int lineStationIndex)
        {
            if (DataSource.listLineStation.FirstOrDefault(lis => (lis.LineId == lineID && lis.Code == statCode)) != null)
                throw new DO.BadStationCodeLineID(lineID, statCode, "Station Code is already registered to line ID");
            DO.LineStation sil = new DO.LineStation() { Code = statCode, LineId = lineID, LineStationIndex = lineStationIndex };
            DataSource.listLineStation.Add(sil);
        }

        public void UpdateStationInLine(int lineID, int statCode, int lineStationIndex)
        {
            DO.LineStation sil = DataSource.listLineStation.Find(lis => (lis.LineId == lineID && lis.Code == statCode));

            if (sil != null)
            {
                sil.LineStationIndex = lineStationIndex;
            }
            else
                throw new DO.BadStationCodeLineID(lineID, statCode, "station code is NOT registered to line ID");
        }

        public void DeleteStationInLine(int lineID, int statCode)
        {

            DO.LineStation sil = DataSource.listLineStation.Find(lis => (lis.LineId == lineID && lis.Code == statCode));

            if (sil != null)
            {
                DataSource.listLineStation.Remove(sil);
            }
            else
                throw new DO.BadStationCodeLineID(lineID, statCode, "station code is NOT registered to line ID");

        }

        public void DeleteStationsFromAllLines(int statCode)
        {
            DataSource.listLineStation.RemoveAll(s => s.Code == statCode);
        }
        public void DeleteAllLineStationsPerLine(int lineID)
        {
            DO.LineStation sil = DataSource.listLineStation.Find(lis => (lis.LineId == lineID));

            if (sil != null)
            {
                DataSource.listLineStation.Remove(sil);
            }
            else
                throw new DO.BadLineIDException(lineID, "line id is NOT registered to line ID");
        }
        #endregion

        #region User
       public DO.User GetUser(string myname)
        {
            DO.User user = DataSource.users.Find(u => u.Name == myname);
            //try { Thread.Sleep(2000); } catch (ThreadInterruptedException ex) { }
            if (user != null)
            {
                return user.Clone();
            }
            else
            {
                return null;
            }
            
        }
       public IEnumerable<DO.User> GetAllUsers()
            {
                return from user in DataSource.users
                       select user.Clone();
            }
        public void AddUser(DO.User user)
        {
            if (DataSource.users.Where(s => s.Name == user.Name).ToList().Count() > 0)
            {
               // throw new DO.BadStationCodeException(user.Name, "Duplicate user Code");
            }
            DataSource.users.Add(user);
        }
        #endregion
    }
}