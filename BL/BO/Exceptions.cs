using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;


namespace BO
{
    [Serializable]
    public class BadStationCodeException : Exception
    {
        public int ID;
        public BadStationCodeException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadStationCodeException)innerException).Code;
        public override string ToString() => base.ToString() + $", bad station code: {ID}";
    }

    [Serializable]
    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadStationCodeException)innerException).Code;
        public override string ToString() => base.ToString() + $", bad student id: {ID}";
    }

    [Serializable]
    public class BadStationCodeLineIDException : Exception
    {
        public int stationCode;
        public int lineID;
        public BadStationCodeLineIDException(string message, Exception innerException) :
            base(message, innerException)
        {
            stationCode = ((DO.BadStationCodeLineID)innerException).stationCode;
            lineID = ((DO.BadStationCodeLineID)innerException).lineID;
        }
        public override string ToString() => base.ToString() + $", bad station code: {stationCode} and line ID: {lineID}";
    }

}
