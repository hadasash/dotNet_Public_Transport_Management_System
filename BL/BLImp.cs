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

            lineBO.LineStations = from lsil in dl.GetStationsInLine(lsil => lsil.LineId == lneId)
                                 let line = dl.GetLine(lsil.LineId)
                                 select (BO.LineStation)line.CopyPropertiesToNew(typeof(BO.LineStation));
            return lineBO;
        }
        public BO.Line GetLine(int lineID)
        {
            DO.Line lineDO;
            try
            {
                lineDO = dl.GetLine(lineID);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
            }
            return lineDoBoAdapter(lineDO);
        }
        
        public IEnumerable<BO.Line> GetAllLines()
        {
            return from lineDO in dl.GetAllLines()
                   select lineDoBoAdapter(lineDO);
        }
        void UpdateLinePersonalDetails(DO.Line line)
        {
            try
            {
                dl.UpdateLine(line);
            }
            catch (DO.BadPersonIdCourseIDException ex)
            {
                throw new BO.BadStudentIdCourseIDException("Line ID  is Not exist", ex);
            }
        }
        void AddLine(int lineID)
        {
            try
            {
                dl.AddLine(lineID);
            }
            catch (DO.BadStationIdLineIDException ex)//TO DO
            {
                throw new BO.BadStudentIdCourseIDException("Line ID is Not exist", ex);
            }
        }
        void DeleteLine(int lineID)
        {
            try
            {
               
                dl.DeleteLine(lineID);
               
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadStudentIdException("Line id does not exist or he is not a line", ex);
            }
        }

      

        #endregion
    }

}
