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

            stationBO.ListOfLines = from sil in dl.GetStationsInLine(sil => sil.Station == code)//צריך לעבור על כל הקוים ולחפש במסלול של כל קו אם עובר בתחנה הנ"ל
                                    let line = dl.GetLine(sil.LineId)
                                       select line.CopyToListOfLines(sil);
      
            return stationBO;
        }
        public IEnumerable<BO.Station> GetAllStations()
        {
            
            return from item in dl.GetAllStations()
                   select stationDoBoAdapter(item);
        }
        #endregion
        #region Line
        //Adi- Add, Update, Delete
        public BO.Line lineDoBoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            int lneId = lineDO.LineId;
            lineDO.CopyPropertiesTo(lineBO);

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

            courseBO.Lecturers = from lic in dl.GetLecturersInCourseList(lic => lic.CourseId == id)
                                 let course = dl.GetCourse(lic.CourseId)
                                 select (BO.CourseLecturer)course.CopyPropertiesToNew(typeof(BO.CourseLecturer));
            return courseBO;
        }
        public IEnumerable<BO.Course> GetAllCourses()
        {
            return from crsDO in dl.GetAllCourses()
                   select courseDoBoAdapter(crsDO);
        }

        public IEnumerable<BO.StudentCourse> GetAllCoursesPerStudent(int id)
        {
            return from sic in dl.GetStudentsInCourseList(sic => sic.PersonId == id)
                   let course = dl.GetCourse(sic.CourseId)
                   select course.CopyToStudentCourse(sic);
        }

        #endregion
        #region Line
        //Adi- Add, Update, Delete
      
        #endregion
    }

}
