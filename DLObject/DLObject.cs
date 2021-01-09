﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DLAPI;
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
                throw new DO.BadPersonIdException(line.LineId, "Duplicate line ID");//TO DO
            if (DataSource.listLines.FirstOrDefault(l => l.ID == line.LineId) == null)
                throw new DO.BadPersonIdException(line.LineId, "Missing line ID");//TO DO
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
                throw new DO.BadPersonIdException(line.LineId, $"bad line id: {line.LineId}");//TO DO
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
                throw new DO.BadPersonIdException(lineId, $"bad line id: {lineId}");//TO DO
        }

        #endregion 

    }
}