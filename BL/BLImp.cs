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
        //Hadasa: finish station student =person=station. course =line
        BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            DO.Station personDO;
            int id = stationDO.Code;
            try
            {
                personDO = dl.GetStation(id);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Station code is illegal", ex);
            }
            personDO.CopyPropertiesTo(stationBO);
            
            stationDO.CopyPropertiesTo(stationBO);
           
            stationBO.Longitude = from sil in dl.GetStationInLinesList(sil => sil.PersonId == code)
                                      let line = dl.GetLine(sil.LINEId)
                                      select line.CopyToStudentCourse(sil);
           
            return stationBO;
        }

        public BO.Station GetStation(int id)
        {
            DO.Station stationDO;
            try
            {
                stationDO = dl.GetStation(id);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("station code does not exist ", ex);
            }
            return stationDoBoAdapter(stationDO);
        }

        public IEnumerable<BO.Station> GetAllStatons()
        {
         
            return from stationDO in dl.GetAllStations()
                   orderby stationDO.Code
                   select stationDoBoAdapter(stationDO);
        }
        public IEnumerable<BO.Station> GetStationsBy(Predicate<BO.Station> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.ListedPerson> GetStationIDNameList()
        {
            return from item in dl.GetStationListWithSelectedFields((StationDO) =>
            {
                try { Thread.Sleep(1500); } catch (ThreadInterruptedException e) { }
                return new BO.ListedPerson() { ID = stationDO.ID, Name = dl.GetPerson(stationDO.ID).Name };
            })
                   let stationBO = item as BO.ListedPerson
                   select stationBO;
        }

        public void UpdateStudentPersonalDetails(BO.Station station)
        {          
            DO.Station personDO = new DO.Station();
            station.CopyPropertiesTo(personDO);
            try
            {
                dl.UpdateStation(personDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Student ID is illegal", ex);
            }

            //Update DO.Student            
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dl.UpdateStation(stationDO);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Student ID is illegal", ex);
            }

        }
        public void DeleteStation(int id)
        {
            try
            {
                dl.DeleteStation(id);
                dl.DeleteStation(id);
                dl.DeleteStationFromAllLines(id);
            }
            catch (DO.BadStationCodeLineID ex)
            {
                throw new BO.BadStationCodeLineID("Station ID and line ID is Not exist", ex);
            }
            catch (DO.BadStationCodeException ex)
            {
                throw new BO.BadStationCodeException("Person id does not exist or he is not a station", ex);
            }
        }

        #endregion
        #region Line
        //Adi- Add, Update, Delete
      
        #endregion
    }

}
