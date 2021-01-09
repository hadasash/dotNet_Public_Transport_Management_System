﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DLAPI;
using DO;
//using DO;
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
                throw new DO.BadPersonIdException(person.ID, "Duplicate person ID"); //TO DO 
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
                throw new DO.BadPersonIdException(id, $"bad person id: {id}"); //TO DO
        }

        public void UpdatePerson(DO.Station station)
        {
            DO.Station stat = DataSource.listStations.Find(p => p.Code == station.Code);

            if (stat != null)
            {
                DataSource.listStations.Remove(stat);
                DataSource.listStations.Add(station.Clone());
            }
            else
                throw new DO.BadPersonIdException(station.ID, $"bad person id: {station.ID}"); //TO DO 
        }

        public void UpdatePerson(int id, Action<DO.Person> update)
        {
            throw new NotImplementedException();
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
        public IEnumerable<DO.LineStation> GetStationsLineInList(Predicate<DO.LineStation> predicate)
        {
            return from sil in DataSource.listLineStation
                   where predicate(sil)
                   select sil.Clone();
        }

        public void UpdateStation(Station person)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(int code, Action<Station> update)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetLinesInStation(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddLineInStation(int lineID, int statCode, float grade = 0)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineInStation(int lineID, int statCode, float lineStationIndex)
        {
            throw new NotImplementedException();
        }

        public void DeleteLineInStation(int lineID, int statCode)
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