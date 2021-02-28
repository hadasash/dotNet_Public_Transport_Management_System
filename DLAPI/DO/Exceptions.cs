using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   // [Serializable]
    public class BadStationCodeException : Exception
    {
        public int Code;
        public BadStationCodeException(int code) : base() => Code = code;
        public BadStationCodeException(int code, string message) :
            base(message) => Code = code;
        public BadStationCodeException(int code, string message, Exception innerException) :
            base(message, innerException) => Code = code;

        public override string ToString() => base.ToString() + $", bad Station Code: {Code}";
    }

    public class BadLineIDException : Exception
    {
        public int ID;
        public BadLineIDException(int id) : base() => ID = id;
        public BadLineIDException(int id, string message) :
            base(message) => ID = id;
        public BadLineIDException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;
        public override string ToString() => base.ToString() + $", bad LineID: {ID}";
    }
    public class BadStationCodeLineID : Exception
    {
        public int stationCode;
        public int lineID;
        public BadStationCodeLineID(int statCode, int lnId) : base() { stationCode = statCode; lineID = lnId; }
        public BadStationCodeLineID(int statCode, int lnId, string message) :
            base(message)
        { stationCode = statCode; lineID = lnId; }
        public BadStationCodeLineID(int statCode, int lnId, string message, Exception innerException) :
            base(message, innerException)
        { stationCode = statCode; lineID = lnId; }

        public override string ToString() => base.ToString() + $", bad Station Code: {stationCode} and line id: {lineID}";
    }

    public class XMLFileLoadCreateException : Exception
    {
        public string xmlFilePath;
        public XMLFileLoadCreateException(string xmlPath) : base() { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message) :
            base(message)
        { xmlFilePath = xmlPath; }
        public XMLFileLoadCreateException(string xmlPath, string message, Exception innerException) :
            base(message, innerException)
        { xmlFilePath = xmlPath; }
        public override string ToString() => base.ToString() + $", fail to load or create xml file: {xmlFilePath}";
    }
}
