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
    sealed class DLObject : IDL    //internal

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
            if (DataSource.listStations.FirstOrDefault(s => s.Code == station.Code) != null)
                throw new DO.BadStationCodeException(station.Code, "Duplicate station Code"); 
            DataSource.listStations.Add(station.Clone());
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

        #endregion

        #region Line

        public DO.Line GetLine(int lineId)
        {
            return DataSource.listLines.Find(c => c.LineId == lineId).Clone();
        }
        public IEnumerable<DO.Line> GetAllLines()
        {
            return from course in DataSource.listLines
                   select course.Clone();
        }
        public void AddLine(DO.Line line)
        {
            if (DataSource.listLines.FirstOrDefault(l => l.LineId == line.LineId) != null)
                throw new DO.BadLineIDException(line.LineId, "Duplicate line ID");
            if (DataSource.listLines.FirstOrDefault(l => l.LineId == line.LineId) == null)
                throw new DO.BadLineIDException(line.LineId, "Missing line ID");
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
            throw new NotImplementedException();//TO DO
        }
        public void DeleteLine(int lineId)
        {
            DO.Line myline = DataSource.listLines.Find(l => l.LineId == lineId);

            if (myline != null)
            {
                DataSource.listLines.Remove(myline);
            }
            else
                throw new DO.BadLineIDException(lineId, $"bad line id: {lineId}");//TO DO
        }
        #endregion

        #region LineStation
        // TO DO: implement functions 
        // Line= Student/Person 
        // Station= Course
        public IEnumerable<LineStation> GetLinesInStation(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddLineInStation(int lineID, int statCode, int lineStationIndex)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineInStation(int lineID, int statCode, int lineStationIndex)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineInStation(int lineID, int statCode)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(Station person)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(int code, Action<Station> update)
        {
            throw new NotImplementedException();
        }

        public void Add(Line line)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineInStation(int lineID)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}