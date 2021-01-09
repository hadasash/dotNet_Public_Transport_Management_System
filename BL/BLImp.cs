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
        //Hadasa: finish station
        public BO.Station GetStation(int code)
        {
            DO.Station stationDO; 
            stationDO = dl.GetStation(code);
            
            return stationDoBoAdapter(stationDO);
        }
        BO.Station stationDoBoAdapter(DO.Station stationDO)
        {
            BO.Station stationBO = new BO.Station();
            DO.Station newstationDO;
            int code = stationDO.Code;
            //try
            //{
            //    newstationDO = dl.GetStation(code);
            //}
            //catch (DO.BadPersonIdException ex)
            //{
            //    throw new BO.BadStudentIdException("Student ID is illegal", ex);
            //}
           

            stationDO.CopyPropertiesTo(stationBO);

            stationBO.ListOfLines = from sil in dl.GetLinesInStation(sil => sil.Station == code)
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
        BO.Course courseDoBoAdapter(DO.Course courseDO)
        {
            BO.Course courseBO = new BO.Course();
            int id = courseDO.ID;
            courseDO.CopyPropertiesTo(courseBO);

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
    }

}
