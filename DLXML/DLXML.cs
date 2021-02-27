using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DL
{
    class DLXML : IDL
    {
        #region singelton
        static readonly DLXML instance = new DLXML();
        static DLXML() { }// static ctor to ensure instance init is done just before first usage
        DLXML() { } // default => private
        public static DLXML Instance { get => instance; }// The public Instance property to use
        #endregion

        #region Station
        public IEnumerable<DO.LineStation> GetAllLineStationsPerStation(int code)
        {
            List<LineStation> listLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(stationsPath);

            return from ls in listLineStation
                   where ls.Code == code
                   select ls;
        }

        public DO.Station GetStation(int code)
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            DO.Station station = listStations.Find(p => p.Code == code);
            //try { Thread.Sleep(2000); } catch (ThreadInterruptedException ex) { }
            if (station != null)
            {
                return station;
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
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            return from station in listStations
                   select station;
        }

        public void AddStation(DO.Station station)
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            var x = listStations.ToList();
            if (listStations.Where(s => s.Code == station.Code).ToList().Count() > 0)
            {
                throw new DO.BadStationCodeException(station.Code, "Duplicate station Code");
            }
            listStations.Add(station);
            XMLTools.SaveListToXMLSerializer(listStations, stationsPath);
        }

        public void DeleteStation(int code)
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            DO.Station stat =listStations.Find(s => s.Code == code);

            if (stat != null)
            {
                listStations.Remove(stat);
            }
            else
                throw new DO.BadStationCodeException(code, $"bad station code: {code}");
            XMLTools.SaveListToXMLSerializer(listStations, stationsPath);
        }
        public void UpdateStation(DO.Station station)
        {
            List<Station> listStations = XMLTools.LoadListFromXMLSerializer<Station>(stationsPath);

            DO.Station mystation = listStations.Find(s => s.Code == station.Code);
            if (mystation != null)
            {
                listStations.Remove(mystation);
                listStations.Add(station);
            }
            else
                throw new DO.BadStationCodeException(station.Code, $"bad station code: {station.Code}");
            XMLTools.SaveListToXMLSerializer(listStations, stationsPath);
        }
        public void UpdateStation(int code, Action<DO.Station> update)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Line

        public DO.Line GetLine(int lineId)
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
           
            DO.Line myLine = listLines.Find(c => c.LineId == lineId);
            if (myLine != null)
            {
                return myLine;
            }
            else
            {
                throw new DO.BadLineIDException(lineId, $"Bad Line id");
            }
        }
        public IEnumerable<DO.Line> GetAllLines()
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
           
            return from line in listLines
                   select line;
        }
        public void AddLine(DO.Line line)
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);
           
            if (listLines.FirstOrDefault(l => l.LineId == line.LineId) != null)
                throw new DO.BadLineIDException(line.LineId, "Duplicate line ID");
            //if (DataSource.listLines.FirstOrDefault(l => l.LineId == line.LineId) == null)
            //    throw new DO.BadLineIDException(line.LineId, "Missing line ID");
            listLines.Add(line);
            XMLTools.SaveListToXMLSerializer(listLines, linesPath);
            #region running number:
            //DO.Config.LineId++;//update running number

            //running number- since "Config" in DO is a static class,
            //in order to save the running number from haraza to haraza, we need to save it each time in a file.
            //we will use xElement for that:

            XElement runningNumberRootElem = XMLTools.LoadListFromXMLElement(runningNumberPath);//load from xml to Exelement root

            XElement getRunNumElem = (from run in runningNumberRootElem.Elements()
                                      select run).FirstOrDefault();

            int newRunNum = int.Parse(getRunNumElem./*Element("LineId").*/Value);
            line.LineId = newRunNum;//get the current running number

            getRunNumElem./*Element("LineId").*/Value = (newRunNum + 1).ToString();//add 1 to the line id that was before.

            XMLTools.SaveListToXMLElement(runningNumberRootElem, runningNumberPath);//save the new root in the xml file


            #endregion
        }
        public void UpdateLine(DO.Line line)
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            DO.Line myline = listLines.Find(l => l.LineId == line.LineId);
            if (myline != null)
            {
                listLines.Remove(myline);
               listLines.Add(line);
            }
            else
                throw new DO.BadLineIDException(line.LineId, $"bad line id: {line.LineId}");
            XMLTools.SaveListToXMLSerializer(listLines, linesPath);

        }
        public void UpdateLine(int lineId, Action<DO.Line> update)
        {
            throw new NotImplementedException();
        }
        public void DeleteLine(int lineId)
        {
            List<Line> listLines = XMLTools.LoadListFromXMLSerializer<Line>(linesPath);

            DO.Line myline = listLines.Find(l => l.LineId == lineId);

            if (myline != null)
            {
                listLines.Remove(myline);
            }
            else
                throw new DO.BadLineIDException(lineId, $"bad line id: {lineId}");
            XMLTools.SaveListToXMLSerializer(listLines, linesPath);

        }
        #endregion

        #region LineStation

        public IEnumerable<DO.LineStation> GetStationsInLineList(Predicate<DO.LineStation> predicate)
        {
            List<LineStation> listLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            return from sil in listLineStation
                   where predicate(sil)
                   select sil;
        }
        public DO.LineStation GetLineStation(int code)
        {
            List<LineStation> listLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            DO.LineStation stat = listLineStation.Find(s => s.Code == code);

            if (stat != null)//found the station
                return stat;
            else//didnt find the station
                throw new DO.BadStationCodeException(code, $"error in line station that its code is: {code}");
        }
        public DO.LineStation GetLineStation(int id, int code)
        {
            List<LineStation> listLineStations = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            DO.LineStation stat = listLineStations.Find(s => s.Code == code && s.LineId == id);

            if (stat != null)//found the station
                return stat;
            else//didnt find the station
                throw new DO.BadStationCodeException(code, $"error in line station that its code is: {code}");
        }



        public void AddStationInLine(int lineID, int statCode, int lineStationIndex)
        {
            List<LineStation> listLineStation= XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            if (listLineStation.FirstOrDefault(lis => (lis.LineId == lineID && lis.Code == statCode)) != null)
                throw new DO.BadStationCodeLineID(lineID, statCode, "Station Code is already registered to line ID");
            DO.LineStation sil = new DO.LineStation() { Code = statCode, LineId = lineID, LineStationIndex = lineStationIndex };
           listLineStation.Add(sil);
            XMLTools.SaveListToXMLSerializer(listLineStation, lineStationsPath);

        }

        public void UpdateStationInLine(int lineID, int statCode, int lineStationIndex)
        {
            List<LineStation> listLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            DO.LineStation sil =listLineStation.Find(lis => (lis.LineId == lineID && lis.Code == statCode));

            if (sil != null)
            {
                sil.LineStationIndex = lineStationIndex;
            }
            else
                throw new DO.BadStationCodeLineID(lineID, statCode, "station code is NOT registered to line ID");
            XMLTools.SaveListToXMLSerializer(listLineStation, lineStationsPath);

        }

        public void DeleteStationInLine(int lineID, int statCode)
        {
            List<LineStation> listLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            DO.LineStation sil =listLineStation.Find(lis => (lis.LineId == lineID && lis.Code == statCode));

            if (sil != null)
            {
                listLineStation.Remove(sil);
            }
            else
                throw new DO.BadStationCodeLineID(lineID, statCode, "station code is NOT registered to line ID");
            XMLTools.SaveListToXMLSerializer(listLineStation, lineStationsPath);

        }

        public void DeleteStationsFromAllLines(int statCode)
        { 
          List<LineStation> listLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

       
           listLineStation.RemoveAll(s => s.Code == statCode);
            XMLTools.SaveListToXMLSerializer(listLineStation, lineStationsPath);
        }
        public void DeleteAllLineStationsPerLine(int lineID)
        {
            List<LineStation> listLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationsPath);

            DO.LineStation sil = listLineStation.Find(lis => (lis.LineId == lineID));

            if (sil != null)
            {
                listLineStation.Remove(sil);
            }
            else
                throw new DO.BadLineIDException(lineID, "line id is NOT registered to line ID");
            XMLTools.SaveListToXMLSerializer(listLineStation, lineStationsPath);

        }
        #endregion

        #region User
        public DO.User GetUser(string myname)
        {
            List<User> listUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            DO.User user = listUsers.Find(u => u.Name == myname);
            //try { Thread.Sleep(2000); } catch (ThreadInterruptedException ex) { }
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }

        }
        public IEnumerable<DO.User> GetAllUsers()
        {
            List<User> listUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);

            return from user in listUsers
                   select user;
        }
        public void AddUser(DO.User user)
        {
            List<User> listUsers = XMLTools.LoadListFromXMLSerializer<User>(usersPath);
            if (listUsers.Where(s => s.Name == user.Name).ToList().Count() > 0)
            {
                // throw new DO.BadStationCodeException(user.Name, "Duplicate user Code");
            }
            listUsers.Add(user);
            XMLTools.SaveListToXMLSerializer(listUsers, usersPath);
        }
        #endregion

        #region AdjacentStations
        public IEnumerable<DO.AdjacentStations> GetAdjacentStationsByFirstOfPair(int code)
        {
            XElement adjacentStationsRootElem = XMLTools.LoadListFromXMLElement(adjacentStationsPath);

            //return from adjSt in DataSource.listAdjacentStations
            //       where adjSt.Station1 == code
            //       //where adjSt.Station2 == code
            //       select adjSt.Clone();//return a list of adjacent stations, in which the station with the given code apears as the 1st in the pair


            return from p in adjacentStationsRootElem.Elements()//each p is an adjacent stations
                   let adjStat = new AdjacentStations()
                   {
                       Station1 = Int32.Parse(p.Element("Station1").Value),
                       Station2 = Int32.Parse(p.Element("Station2").Value),
                       Distance = double.Parse(p.Element("Distance").Value),
                       Time = TimeSpan.ParseExact(p.Element("Time").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                   }
                   where (adjStat.Station1 == code)
                   select adjStat;

        }
        public IEnumerable<DO.AdjacentStations> GetAdjacentStationsBySecondOfPair(int code)
        {
            XElement adjacentStationsRootElem = XMLTools.LoadListFromXMLElement(adjacentStationsPath);

            //return from adjSt in DataSource.listAdjacentStations
            //       where adjSt.Station2 == code
            //       select adjSt.Clone();//return a list of adjacent stations, in which the station with the given code apears as the 2nd in the pair

            return from p in adjacentStationsRootElem.Elements()
                   let adjStat = new AdjacentStations()
                   {
                       Station1 = Int32.Parse(p.Element("Station1").Value),
                       Station2 = Int32.Parse(p.Element("Station2").Value),
                       Distance = double.Parse(p.Element("Distance").Value),
                       Time = TimeSpan.ParseExact(p.Element("Time").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                   }
                   where (adjStat.Station2 == code)
                   select adjStat;
        }


        #endregion

        #region LineTrip
        
        public IEnumerable<DO.LineTrip> GetAllLineTripPerLine(int lineid)
        {
            XElement lineTripRootElem = XMLTools.LoadListFromXMLElement(lineTripPath);

            //return from lnTrip in DataSource.listLineTrips//return all line trips of a specific line.
            //       where lnTrip.LineID == lineid
            //       select lnTrip.Clone();

            return from p in lineTripRootElem.Elements()
                   let lnTrip = new LineTrip()
                   {
                       LineTripID = Int32.Parse(p.Element("LineTripID").Value),
                       LineID = Int32.Parse(p.Element("LineID").Value),
                       StartAt = TimeSpan.ParseExact(p.Element("StartAt").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                   }
                   where (lnTrip.LineID == lineid)
                   select lnTrip;

        }

        public IEnumerable<DO.LineTrip> GetAllLineTripsBy(Predicate<DO.LineTrip> predicate)
        {
            XElement lineTripRootElem = XMLTools.LoadListFromXMLElement(lineTripPath);

            //return from lTrip in DataSource.listLineTrips
            //       where predicate(lTrip)
            //       select lTrip.Clone();

            return from p in lineTripRootElem.Elements()//each p is a line trip
                   let lnTrip = new LineTrip()
                   {
                       LineTripID = Int32.Parse(p.Element("LineTripID").Value),
                       LineID = Int32.Parse(p.Element("LineID").Value),
                       StartAt = TimeSpan.ParseExact(p.Element("StartAt").Value, "hh\\:mm\\:ss", CultureInfo.InvariantCulture)
                   }
                   where (predicate(lnTrip))
                   select lnTrip;
        }
        #endregion

        #region DS XML Files
        string stationsPath = @"StationsXml.xml"; //Serializer
        string lineStationsPath = @"LineStationsXml.xml"; //Serializer
        string linesPath = @"LinesXml.xml"; //Serializer
        string usersPath = @"UsersXml.xml"; //Serializer
        string adjacentStationsPath = @"AdjacentStationsXml.xml"; //XElement
        string lineTripPath = @"LineTripXml.xml"; //XElement
        string runningNumberPath = @"RunningNumberXml.xml";

        #endregion
        public void restartXmlLists()
        {
            //no need to write anything here, its done by the first haraza of DLObject
        }

    }
}