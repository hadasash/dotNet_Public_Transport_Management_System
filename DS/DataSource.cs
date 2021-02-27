using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
namespace DS
{
    public static class DataSource
    {
        private static Random r = new Random();
        public static List<Station> listStations;
        public static List<Line> listLines;
        public static List<LineStation> listLineStation;
        public static List<AdjacentStations> listAdjacentStations;
        public static List<User> users;
        public static List<LineTrip> listLineTrips;


        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            listStations = new List<Station>
            {
                #region restart stations
                new Station
                {
                    Code = 73,
                    Name = "שדרות גולדה מאיר/המשורר אצ''ג",
                    Address = "רחוב:שדרות גולדה מאיר  עיר: ירושלים ",
                    Lattitude = 31.825302,
                    Longitude = 35.188624
                },
                new Station
                {
                    Code = 76,
                    Name = "בית ספר צור באהר בנות/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים",
                    Lattitude = 31.738425,
                    Longitude = 35.228765
                },
                new Station
                {
                    Code = 77,
                    Name = "בית ספר אבן רשד/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים ",
                    Lattitude = 31.738676,
                    Longitude = 35.226704
                },
                new Station
                {
                    Code = 78,
                    Name = "שרי ישראל/יפו",
                    Address = "רחוב:שדרות שרי ישראל 15 עיר: ירושלים",
                    Lattitude = 31.789128,
                    Longitude = 35.206146
                },
                new Station
                {
                    Code = 83,
                    Name = "בטן אלהווא/חוש אל מרג",
                    Address = "רחוב:בטן אל הווא  עיר: ירושלים",
                    Lattitude = 31.766358,
                    Longitude = 35.240417
                },
                new Station
                {
                    Code = 84,
                    Name = "מלכי ישראל/הטורים",
                    Address = " רחוב:מלכי ישראל 77 עיר: ירושלים ",
                    Lattitude = 31.790758,
                    Longitude = 35.209791
                },
                new Station
                {
                    Code = 85,
                    Name = "בית ספר לבנים/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Lattitude = 31.768643,
                    Longitude = 35.238509
                },
                new Station
                {
                    Code = 86,
                    Name = "מגרש כדורגל/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Lattitude = 31.769899,
                    Longitude = 35.23973
                },
                new Station
                {
                    Code = 88,
                    Name = "בית ספר לבנות/בטן אלהוא",
                    Address = " רחוב:בטן אל הווא  עיר: ירושלים",
                    Lattitude = 31.767064,
                    Longitude = 35.238443
                },
                new Station
                {
                    Code = 89,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Lattitude = 31.765863,
                    Longitude = 35.247198
                },
                new Station
                {
                    Code = 90,
                    Name = "גולדה/הרטום",
                    Address = "רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.799804,
                    Longitude = 35.213021
                },
                new Station
                {
                    Code = 91,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Lattitude = 31.765717,
                    Longitude = 35.247102
                },
                new Station
                {
                    Code = 93,
                    Name = "חוש סלימה 1",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.767265,
                    Longitude = 35.246594
                },
                new Station
                {
                    Code = 94,
                    Name = "דרך בית לחם הישנה ב",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.767084,
                    Longitude = 35.246655
                },
                new Station
                {
                    Code = 95,
                    Name = "דרך בית לחם הישנה א",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.768759,
                    Longitude = 31.768759
                },
                new Station
                {
                    Code = 97,
                    Name = "שכונת בזבז 2",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Lattitude = 31.77002,
                    Longitude = 35.24348
                },
                new Station
                {
                    Code = 102,
                    Name = "גולדה/שלמה הלוי",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Lattitude = 31.8003,
                    Longitude = 35.208257
                },
                new Station
                {
                    Code = 103,
                    Name = "גולדה/הרטום",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Lattitude = 31.8,
                    Longitude = 35.214106
                },
                new Station
                {
                    Code = 105,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 2 עיר: ירושלים",
                    Lattitude = 31.797708,
                    Longitude = 35.217133
                },
                new Station
                {
                    Code = 106,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 3 עיר: ירושלים",
                    Lattitude = 31.797535,
                    Longitude = 35.217057
                },
                //20
                new Station
                {
                    Code = 108,
                    Name = "עזרת תורה/עלי הכהן",
                    Address = "  רחוב:עזרת תורה 25 עיר: ירושלים",
                    Lattitude = 31.797535,
                    Longitude = 35.213728
                },
                new Station
                {
                    Code = 109,
                    Name = "עזרת תורה/דורש טוב",
                    Address = "  רחוב:עזרת תורה 21 עיר: ירושלים ",
                    Lattitude = 31.796818,
                    Longitude = 35.212936
                },
                new Station
                {
                    Code = 110,
                    Name = "עזרת תורה/דורש טוב",
                    Address = " רחוב:עזרת תורה 12 עיר: ירושלים",
                    Lattitude = 31.796129,
                    Longitude = 35.212698
                },
                new Station
                {
                    Code = 111,
                    Name = "יעקובזון/עזרת תורה",
                    Address = "  רחוב:יעקובזון 1 עיר: ירושלים",
                    Lattitude = 31.794631,
                    Longitude = 35.21161
                },
                new Station
                {
                    Code = 112,
                    Name = "יעקובזון/עזרת תורה",
                    Address = " רחוב:יעקובזון  עיר: ירושלים",
                    Lattitude = 31.79508,
                    Longitude = 35.211684
                },
                //25
                new Station
                {
                    Code = 113,
                    Name = "זית רענן/אוהל יהושע",
                    Address = "  רחוב:זית רענן 1 עיר: ירושלים",
                    Lattitude = 31.796255,
                    Longitude = 35.211065
                },
                new Station
                {
                    Code = 115,
                    Name = "זית רענן/תורת חסד",
                    Address = " רחוב:זית רענן  עיר: ירושלים",
                    Lattitude = 31.798423,
                    Longitude = 35.209575
                },
                new Station
                {
                    Code = 116,
                    Name = "זית רענן/תורת חסד",
                    Address = "  רחוב:הרב סורוצקין 48 עיר: ירושלים ",
                    Lattitude = 31.798689,
                    Longitude = 35.208878
                },
                new Station
                {
                    Code = 117,
                    Name = "קרית הילד/סורוצקין",
                    Address = "  רחוב:הרב סורוצקין  עיר: ירושלים",
                    Lattitude = 31.799165,
                    Longitude = 35.206918
                },
                new Station
                {
                    Code = 119,
                    Name = "סורוצקין/שנירר",
                    Address = "  רחוב:הרב סורוצקין 31 עיר: ירושלים",
                    Lattitude = 31.797829,
                    Longitude = 35.205601
                },

                //#endregion //30
                new Station
                {
                    Code = 1485,
                    Name = "שדרות נווה יעקוב/הרב פרדס ",
                    Address = "רחוב: שדרות נווה יעקוב  עיר:ירושלים ",
                    Lattitude = 31.840063,
                    Longitude = 35.240062

                },
                new Station
                {
                    Code = 1486,
                    Name = "מרכז קהילתי /שדרות נווה יעקוב",
                    Address = "רחוב:שדרות נווה יעקוב ירושלים עיר:ירושלים ",
                    Lattitude = 31.838481,
                    Longitude = 35.23972
                },


                new Station
                {
                    Code = 1487,
                    Name = " מסוף 700 /שדרות נווה יעקוב ",
                    Address = "חוב:שדרות נווה יעקב 7 עיר: ירושלים  ",
                    Lattitude = 31.837748,
                    Longitude = 35.231598
                },
                new Station
                {
                    Code = 1488,
                    Name = " הרב פרדס/אסטורהב ",
                    Address = "רחוב:מעגלות הרב פרדס  עיר: ירושלים רציף  ",
                    Lattitude = 31.840279,
                    Longitude = 35.246272
                },
                new Station
                {
                    Code = 1490,
                    Name = "הרב פרדס/צוקרמן ",
                    Address = "רחוב:מעגלות הרב פרדס 24 עיר: ירושלים   ",
                    Lattitude = 31.843598,
                    Longitude = 35.243639
                },
                new Station
                {
                    Code = 1491,
                    Name = "ברזיל ",
                    Address = "רחוב:ברזיל 14 עיר: ירושלים",
                    Lattitude = 31.766256,
                    Longitude = 35.173
                },
                new Station
                {
                    Code = 1492,
                    Name = "בית וגן/הרב שאג ",
                    Address = "רחוב:בית וגן 61 עיר: ירושלים ",
                    Lattitude = 31.76736,
                    Longitude = 35.184771
                },
                new Station
                {
                    Code = 1493,
                    Name = "בית וגן/עוזיאל ",
                    Address = "רחוב:בית וגן 21 עיר: ירושלים    ",
                    Lattitude = 31.770543,
                    Longitude = 35.183999
                },
                new Station
                {
                    Code = 1494,
                    Name = " קרית יובל/שמריהו לוין ",
                    Address = "רחוב:ארתור הנטקה  עיר: ירושלים    ",
                    Lattitude = 31.768465,
                    Longitude = 35.178701
                },
                new Station
                {
                    Code = 1510,
                    Name = " קורצ'אק / רינגלבלום ",
                    Address = "רחוב:יאנוש קורצ'אק 7 עיר: ירושלים",
                    Lattitude = 31.759534,
                    Longitude = 35.173688
                },
                new Station
                {
                    Code = 1511,
                    Name = " טהון/גולומב ",
                    Address = "רחוב:יעקב טהון  עיר: ירושלים     ",
                    Lattitude = 31.761447,
                    Longitude = 35.175929
                },
                new Station
                {
                    Code = 1512,
                    Name = "הרב הרצוג/שח''ל ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Lattitude = 31.761447,
                    Longitude = 35.199936
                },
                new Station
                {
                    Code = 1514,
                    Name = "פרץ ברנשטיין/נזר דוד ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Lattitude = 31.759186,
                    Longitude = 35.189336
                },
                new Station
                {
                    Code = 1518,
                    Name = "פרץ ברנשטיין/נזר דוד",
                    Address = " רחוב:פרץ ברנשטיין 56 עיר: ירושלים ",
                    Lattitude = 31.759121,
                    Longitude = 35.189178
                },
                new Station
                {
                    Code = 1522,
                    Name = "מוזיאון ישראל/רופין",
                    Address = "  רחוב:דרך רופין  עיר: ירושלים ",
                    Lattitude = 31.774484,
                    Longitude = 35.204882
                },

                new Station
                {
                    Code = 1523,
                    Name = "הרצוג/טשרניחובסקי",
                    Address = "   רחוב:הרב הרצוג  עיר: ירושלים  ",
                    Lattitude = 31.769652,
                    Longitude = 35.208248
                },
                new Station
                {
                    Code = 1524,
                    Name = "רופין/שד' הזז",
                    Address = "    רחוב:הרב הרצוג  עיר: ירושלים   ",
                    Lattitude = 31.769652,
                    Longitude = 35.208248,
                 },
                new Station
                {
                    Code = 121,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = " רחוב:הרב סורוצקין 13 עיר: ירושלים",
                    Lattitude = 31.796033,
                    Longitude =35.206094
                },
                new Station
                {
                    Code = 123,
                    Name = "אוהל דוד/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 9 עיר: ירושלים",
                    Lattitude = 31.794958,
                    Longitude =35.205216
                },
                new Station
                {
                    Code = 122,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 28 עיר: ירושלים",
                    Lattitude = 31.79617,
                    Longitude =35.206158
                },
                new Station
                {
                   Code = 46422,
                   Name = "חזון איש/ רבי עקיבא",
                   Address = " רחוב:חזון איש 35 עיר: בני ברק ",
                   Lattitude = 31.759121,
                   Longitude = 35.189178
                },
                new Station
                {
                    Code = 46425,
                    Name = "חזון איש/ דבורה הנביאה",
                    Address = " רחוב:חזון איש 51  עיר: בני ברק ",
                    Lattitude = 31.774484,
                   Longitude = 35.204882
                },

                new Station
                {
                    Code = 35272,
                    Name = "חזון איש/ בעל שם טוב",
                    Address = " רחוב:חזון איש 67  עיר: בני ברק ",
                    Lattitude = 31.769652,
                    Longitude = 35.208248
                },
                new Station
                {
                   Code = 20115,
                   Name = "כהנמן/ הרב יעקובוביץ",
                   Address = " רחוב:בהנמן 165  עיר: בני ברק   ",
                   Lattitude = 31.769652,
                   Longitude = 35.208248,
                },
                new Station
                {
                    Code = 20116,
                    Name = "כהנמן/ מנחת שלמה ",
                    Address = " רחוב:כהנמן 211 עיר: בני ברק",
                    Lattitude = 31.796033,
                    Longitude =35.206094
                },
                new Station
                {
                    Code = 32298,
                    Name = "רבי עקיבא/הרב קוק ",
                    Address = " רחוב:רבי עקיבא 115 עיר: בני ברק",
                    Lattitude = 31.794958,
                    Longitude =35.205216
                },
                new Station
                {
                    Code = 32287,
                    Name = "רבי עקיבא/ גן ורשא ",
                    Address = " רחוב:רבי עקיבא 49 עיר: בני ברק",
                    Lattitude = 31.79617,
                    Longitude =35.206158
                }

                #endregion
                };

            listLines = new List<Line>()
            {
                #region restart lines
                new Line
                {
                    LineId= 0,
                    NumberBus = 179,
                    Area = Areas.General,
                    FirstStation= 1491,
                    LastStation = 1486,
                },
                new Line
                {
                    LineId= 1,
                    NumberBus = 280,
                    Area = Areas.Jerusalem,
                    FirstStation = 89,
                    LastStation = 90,
                },
                new Line
                {
                    LineId= 2,
                    NumberBus = 67,
                    Area = Areas.Jerusalem,
                    FirstStation = 105,
                    LastStation = 1494,
                },
                new Line
                {
                    LineId= 3,
                    NumberBus = 15,
                    Area = Areas.Jerusalem,
                    FirstStation = 1510,
                    LastStation = 111,
                },

                new Line
                {
                    LineId= 4,
                    NumberBus = 56,
                    Area = Areas.Jerusalem,
                    FirstStation = 73,
                    LastStation = 76,
                },

                 new Line
                {
                    LineId= 5,
                    NumberBus = 180,
                    Area = Areas.Jerusalem,
                    FirstStation = 86,
                    LastStation = 89,
                },
                new Line
                {
                    LineId= 6,
                    NumberBus = 277,
                    Area = Areas.Jerusalem,
                    FirstStation = 109,
                    LastStation = 119,
                },
                new Line
                {
                    LineId= 7,
                    NumberBus = 377,
                    Area = Areas.Jerusalem,
                    FirstStation = 1494,
                    LastStation = 1510,
                },
                new Line
                {
                    LineId= 8,
                    NumberBus = 3,
                    Area = Areas.Jerusalem,
                    FirstStation = 123,
                    LastStation = 121,
                },
                new Line
                {
                    LineId= 9,
                    NumberBus = 157,
                    Area = Areas.Jerusalem,
                    FirstStation = 76,
                    LastStation = 111,
                },
                new Line
                {
                    LineId= 10,
                    NumberBus = 92,
                    Area = Areas.Center,
                    FirstStation = 46422,
                    LastStation = 32287,
                },
                new Line
                {
                    LineId= 11,
                    NumberBus = 108,
                    Area = Areas.Center,
                    FirstStation = 46422,
                    LastStation = 32298,
                },
                new Line
                {
                    LineId= 12,
                    NumberBus = 108,
                    Area = Areas.Jerusalem,
                    FirstStation = 106,
                    LastStation = 88,
                }
                #endregion
            };

            listLineStation = new List<LineStation>()
            {
                #region restart line stations

                //line 179, jerusalem
                new LineStation
                {
                    LineId=0,
                    Code = 1491,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 90,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 90,
                    LineStationIndex = 1,
                    PrevStation = 1491,
                    NextStation = 91,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 91,
                    LineStationIndex = 2,
                    PrevStation = 90,
                    NextStation = 93,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 93,
                    LineStationIndex = 3,
                    PrevStation = 91,
                    NextStation = 94,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 94,
                    LineStationIndex = 4,
                    PrevStation = 93,
                    NextStation = 95,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 95,
                    LineStationIndex = 5,
                    PrevStation = 94,
                    NextStation = 102,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 102,
                    LineStationIndex = 6,
                    PrevStation = 95,
                    NextStation = 103,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 103,
                    LineStationIndex = 7,
                    PrevStation = 102,
                    NextStation = 110,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 110,
                    LineStationIndex = 8,
                    PrevStation = 103,
                    NextStation = 1486,
                },
                new LineStation
                {
                    LineId=0,
                    Code = 1486,
                    LineStationIndex = 9,
                    PrevStation = 110,
                    NextStation = -1,
                },

                //line 67, jerusalem
                new LineStation
                {
                    LineId=2,
                    Code = 105,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 106,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 106,
                    LineStationIndex = 1,
                    PrevStation = 105,
                    NextStation = 108,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 108,
                    LineStationIndex = 2,
                    PrevStation = 106,
                    NextStation = 109,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 109,
                    LineStationIndex = 3,
                    PrevStation = 108,
                    NextStation = 110,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 110,
                    LineStationIndex = 4,
                    PrevStation = 109,
                    NextStation = 111,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 111,
                    LineStationIndex = 5,
                    PrevStation = 110,
                    NextStation = 119,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 119,
                    LineStationIndex = 6,
                    PrevStation = 111,
                    NextStation = 1487,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 1487,
                    LineStationIndex = 7,
                    PrevStation = 119,
                    NextStation = 1492,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 1492,
                    LineStationIndex = 8,
                    PrevStation = 1487,
                    NextStation = 1494,
                },
                new LineStation
                {
                    LineId=2,
                    Code = 1494,
                    LineStationIndex = 9,
                    PrevStation = 1492,
                    NextStation = -1,
                },

                //line 180, jerusalem
                new LineStation
                {
                    LineId= 5,
                    Code = 86,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 85,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 85,
                    LineStationIndex = 1,
                    PrevStation = 86,
                    NextStation = 84,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 84,
                    LineStationIndex = 2,
                    PrevStation = 85,
                    NextStation = 83,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 83,
                    LineStationIndex = 3,
                    PrevStation = 84,
                    NextStation = 78,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 78,
                    LineStationIndex = 4,
                    PrevStation = 83,
                    NextStation = 77,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 77,
                    LineStationIndex = 5,
                    PrevStation = 78,
                    NextStation = 115,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 115,
                    LineStationIndex = 6,
                    PrevStation = 77,
                    NextStation = 113,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 113,
                    LineStationIndex = 7,
                    PrevStation = 115,
                    NextStation = 94,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 94,
                    LineStationIndex = 8,
                    PrevStation = 113,
                    NextStation = 89,
                },
                new LineStation
                {
                    LineId= 5,
                    Code = 89,
                    LineStationIndex = 9,
                    PrevStation = 94,
                    NextStation = -1,
                },

                //line 3, jerusalem
                new LineStation
                {
                    LineId= 8,
                    Code = 123,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 122,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 122,
                    LineStationIndex = 1,
                    PrevStation = 123,
                    NextStation = 1510,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 1510,
                    LineStationIndex = 2,
                    PrevStation = 122,
                    NextStation = 1511,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 1511,
                    LineStationIndex = 3,
                    PrevStation = 1510,
                    NextStation = 1514,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 1514,
                    LineStationIndex = 4,
                    PrevStation = 1511,
                    NextStation = 1518,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 1518,
                    LineStationIndex = 5,
                    PrevStation = 1514,
                    NextStation = 1522,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 1522,
                    LineStationIndex = 6,
                    PrevStation = 1518,
                    NextStation = 1523,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 1523,
                    LineStationIndex = 7,
                    PrevStation = 1522,
                    NextStation = 1524,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 1524,
                    LineStationIndex = 8,
                    PrevStation = 1523,
                    NextStation = 121,
                },
                new LineStation
                {
                    LineId= 8,
                    Code = 121,
                    LineStationIndex = 9,
                    PrevStation = 1524,
                    NextStation = -1,
                },

                //line 108, center
                new LineStation
                {
                    LineId= 11,
                    Code = 46422,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 35272,
                },
                new LineStation
                {
                    LineId= 11,
                    Code = 35272,
                    LineStationIndex = 1,
                    PrevStation = 46422,
                    NextStation = 20116,
                },
                new LineStation
                {
                    LineId= 11,
                    Code = 20116,
                    LineStationIndex = 2,
                    PrevStation = 35272,
                    NextStation = 20115,
                },
                new LineStation
                {
                    LineId= 11,
                    Code = 20115,
                    LineStationIndex = 3,
                    PrevStation = 20116,
                    NextStation = 46425,
                },
                new LineStation
                {
                    LineId= 11,
                    Code = 46425,
                    LineStationIndex = 4,
                    PrevStation = 20115,
                    NextStation = 32287,
                },
                new LineStation
                {
                    LineId= 11,
                    Code = 32287,
                    LineStationIndex = 5,
                    PrevStation = 46425,
                    NextStation = 32298,
                },
                new LineStation
                {
                    LineId= 11,
                    Code = 32298,
                    LineStationIndex = 6,
                    PrevStation = 32287,
                    NextStation = -1,
                },

            //line 280 ,Jerusalem
            new LineStation
            {
                LineId=1,
                Code = 89,
                LineStationIndex = 0,
                PrevStation = -1,
                NextStation = 76,
            },
            new LineStation
            {
                LineId=1,
                Code = 105,
                LineStationIndex = 1,
                PrevStation = 89,
                NextStation = 121,
            },
            new LineStation
            {
                LineId=1,
                Code = 121,
                LineStationIndex = 2,
                PrevStation = 105,
                NextStation = 1510,
            },
            new LineStation
            {
                LineId=1,
                Code = 1510,
                LineStationIndex = 3,
                PrevStation = 121,
                NextStation = 111,
            },
            new LineStation
            {
                LineId=1,
                Code = 111,
                LineStationIndex = 4,
                PrevStation = 1510,
                NextStation = 76,
            },
            new LineStation
            {
                LineId=1,
                Code = 89,
                LineStationIndex = 5,
                PrevStation = 111,
                NextStation = 109,
            },
            new LineStation
            {
                LineId=1,
                Code = 109,
                LineStationIndex = 6,
                PrevStation = 89,
                NextStation = 119,
            },
            new LineStation
            {
                LineId=1,
                Code = 119,
                LineStationIndex = 7,
                PrevStation = 109,
                NextStation = 73,
            },
              new LineStation
            {
                LineId=1,
                Code = 119,
                LineStationIndex = 8,
                PrevStation = 119,
                NextStation = 90,
            },
                new LineStation
            {
                LineId=1,
                Code = 90,
                LineStationIndex = 9,
                PrevStation = 119,
                NextStation = -1,
            },

            //line 56,Jerusalem
            new LineStation
            {
                LineId=4,
                Code = 73,
                LineStationIndex = 0,
                PrevStation = -1,
                NextStation = 83,
            },
            new LineStation
            {
                LineId=4,
                Code = 83,
                LineStationIndex = 1,
                PrevStation = 73,
                NextStation = 85,
            },
            new LineStation
            {
                LineId=4,
                Code = 85,
                LineStationIndex = 2,
                PrevStation = 83,
                NextStation = 86,
            },
            new LineStation
            {
                LineId=4,
                Code = 86,
                LineStationIndex = 3,
                PrevStation = 85,
                NextStation = 111,
            },
            new LineStation
            {
                LineId=4,
                Code = 111,
                LineStationIndex = 4,
                PrevStation = 86,
                NextStation = 113,
            },
            new LineStation
            {
                LineId=4,
                Code = 113,
                LineStationIndex = 5,
                PrevStation = 111,
                NextStation = 117,
            },
            new LineStation
            {
                LineId=4,
                Code = 117,
                LineStationIndex = 6,
                PrevStation = 113,
                NextStation = 1518,
            },
            new LineStation
            {
                LineId=4,
                Code = 1518,
                LineStationIndex = 7,
                PrevStation = 117,
                NextStation = 1522,
            },
              new LineStation
            {
                LineId=4,
                Code = 1522,
                LineStationIndex = 8,
                PrevStation = 1518,
                NextStation = 76,
            },
                new LineStation
            {
                LineId=4,
                Code = 76,
                LineStationIndex = 9,
                PrevStation = 1522,
                NextStation = -1,
            },

             //line 277 ,Jerusalem
             new LineStation
            {
                LineId= 6,
                Code = 109,
                LineStationIndex = 0,
                PrevStation = -1,
                NextStation = 91,
            },
            new LineStation
            {
                LineId= 6,
                Code = 91,
                LineStationIndex = 1,
                PrevStation = 109,
                NextStation = 93,
            },
            new LineStation
            {
                LineId= 6,
                Code = 93,
                LineStationIndex = 2,
                PrevStation = 91,
                NextStation = 97,
            },
            new LineStation
            {
                LineId= 6,
                Code = 97,
                LineStationIndex = 3,
                PrevStation = 93,
                NextStation = 95,
            },
            new LineStation
            {
                LineId= 6,
                Code = 95,
                LineStationIndex = 4,
                PrevStation = 97,
                NextStation = 105,
            },
            new LineStation
            {
                LineId= 6,
                Code = 105,
                LineStationIndex = 5,
                PrevStation = 95,
                NextStation = 117,
            },
            new LineStation
            {
                LineId= 6,
                Code = 117,
                LineStationIndex = 6,
                PrevStation = 105,
                NextStation = 106,
            },
            new LineStation
            {
                LineId= 6,
                Code = 106,
                LineStationIndex = 7,
                PrevStation = 117,
                NextStation = 103,
            },
              new LineStation
            {
                LineId= 6,
                Code = 103,
                LineStationIndex = 8,
                PrevStation = 106,
                NextStation = 119,
            },
                new LineStation
            {
                LineId= 6,
                Code = 119,
                LineStationIndex = 9,
                PrevStation = 103,
                NextStation = -1,
            },

            //line 377 ,Jerusalem
            new LineStation
            {
                LineId= 7,
                Code = 1494,
                LineStationIndex = 0,
                PrevStation = -1,
                NextStation = 1492,
            },
            new LineStation
            {
                LineId= 7,
                Code = 1492,
                LineStationIndex = 1,
                PrevStation = 1494,
                NextStation = 1491,
            },
            new LineStation
            {
                LineId= 7,
                Code = 1491,
                LineStationIndex = 2,
                PrevStation = 1492,
                NextStation = 1490,
            },
            new LineStation
            {
                LineId= 7,
                Code = 1490,
                LineStationIndex = 3,
                PrevStation = 1491,
                NextStation = 1488,
            },
            new LineStation
            {
                LineId= 7,
                Code = 1488,
                LineStationIndex = 4,
                PrevStation = 1490,
                NextStation = 1512,
            },
            new LineStation
            {
                LineId= 7,
                Code = 1512,
                LineStationIndex = 5,
                PrevStation = 1488,
                NextStation = 1518,
            },
            new LineStation
            {
                LineId= 7,
                Code = 1518,
                LineStationIndex = 6,
                PrevStation = 1512,
                NextStation = 1511,
            },
            new LineStation
            {
                LineId= 7,
                Code = 1511,
                LineStationIndex = 7,
                PrevStation = 1518,
                NextStation = 106,
            },
              new LineStation
            {
                LineId= 7,
                Code = 106,
                LineStationIndex = 8,
                PrevStation = 1511,
                NextStation = 1510,
            },
                new LineStation
            {
                LineId= 7,
                Code = 1510,
                LineStationIndex = 9,
                PrevStation = 106,
                NextStation = -1,
            },
            
            // line 92,Center
            new LineStation
            {
                LineId= 10,
                Code = 46422,
                LineStationIndex = 0,
                PrevStation = -1,
                NextStation = 1510,
            },
            new LineStation
            {
                LineId= 10,
                Code = 1510,
                LineStationIndex = 1,
                PrevStation = 46422,
                NextStation = 20116,
            },
            new LineStation
            {
                LineId= 10,
                Code = 20116,
                LineStationIndex = 2,
                PrevStation = 1510,
                NextStation = 20115,
            },
            new LineStation
            {
                LineId= 10,
                Code = 20115,
                LineStationIndex = 3,
                PrevStation = 20116,
                NextStation = 35272,
            },
            new LineStation
            {
                LineId= 10,
                Code = 35272,
                LineStationIndex = 4,
                PrevStation = 20115,
                NextStation = 46425,
            },
            new LineStation
            {
                LineId= 10,
                Code = 46425,
                LineStationIndex = 5,
                PrevStation = 35272,
                NextStation = 46425,
            },
            new LineStation
            {
                LineId= 10,
                Code = 32287,
                LineStationIndex = 6,
                PrevStation = 46425,
                NextStation = -1,
            },
            
            //line 108 ,Jerusalem
           new LineStation
            {
                LineId= 10,
                Code = 106,
                LineStationIndex = 0,
                PrevStation = -1,
                NextStation = 83,
            },

            new LineStation
            {
                LineId= 12,
                Code = 106,
                LineStationIndex = 1,
                PrevStation = 106,
                NextStation = 85,
            },
            new LineStation
            {
                LineId= 12,
                Code = 85,
                LineStationIndex = 2,
                PrevStation = 106,
                NextStation = 86,
            },
            new LineStation
            {
                LineId= 12,
                Code = 86,
                LineStationIndex = 3,
                PrevStation = 85,
                NextStation = 73,
            },
            new LineStation
            {
                LineId= 12,
                Code = 73,
                LineStationIndex = 4,
                PrevStation = 86,
                NextStation = 77,
            },
            new LineStation
            {
                LineId= 12,
                Code = 77,
                LineStationIndex = 5,
                PrevStation = 73,
                NextStation = 76,
            },
            new LineStation
            {
                LineId= 12,
                Code = 76,
                LineStationIndex = 6,
                PrevStation = 77,
                NextStation = 97,
            },
            new LineStation
            {
                LineId= 12,
                Code = 97,
                LineStationIndex = 7,
                PrevStation = 76,
                NextStation = 84,
            },
              new LineStation
            {
                LineId= 12,
                Code = 84,
                LineStationIndex = 8,
                PrevStation = 97,
                NextStation = 88,
            },
                new LineStation
            {
                LineId= 12,
                Code = 88,
                LineStationIndex = 9,
                PrevStation = 84,
                NextStation = -1,
            },

                //line 15, jerusalem
                new LineStation
                {
                    LineId=3,
                    Code = 1510,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 83,
                },

                new LineStation
                {
                    LineId=3,
                    Code = 83,
                    LineStationIndex = 1,
                    PrevStation = 1510,
                    NextStation = 84,

                },
                new LineStation
                {
                    LineId=3,
                    Code = 84,
                    LineStationIndex = 2,
                    PrevStation = 83,
                    NextStation = 88,

                },
                new LineStation
                {
                    LineId=3,
                    Code = 88,
                    LineStationIndex = 3,
                    PrevStation = 84,
                    NextStation = 89,

                },
                new LineStation
                {
                    LineId=3,
                    Code = 89,
                    LineStationIndex = 4,
                    PrevStation = 88,
                    NextStation = 97,

                },
                new LineStation
                {
                    LineId=3,
                    Code = 97,
                    LineStationIndex = 5,
                    PrevStation = 89,
                    NextStation = 103,

                },
                new LineStation
                {
                    LineId=3,
                    Code = 103,
                    LineStationIndex = 6,
                    PrevStation = 97,
                    NextStation = 102,

                },
                new LineStation
                {
                    LineId=3,
                    Code = 102,
                    LineStationIndex = 7,
                    PrevStation = 103,
                    NextStation = 116,

                },
                new LineStation
                {
                    LineId=3,
                    Code = 116,
                    LineStationIndex = 8,
                    PrevStation = 102,
                    NextStation = 111,

                },
                new LineStation
                {
                    LineId=3,
                    Code = 111,
                    LineStationIndex = 9,
                    PrevStation = 116,
                    NextStation = -1,

                },

                //line 157, jerusalem 
                new LineStation
                {
                    LineId= 9,
                    Code = 76,
                    LineStationIndex = 0,
                    PrevStation = -1,
                    NextStation = 77,
                },

                new LineStation
                {
                    LineId= 9,
                    Code = 77,
                    LineStationIndex = 1,
                    PrevStation = 76,
                    NextStation = 78,

                },
                new LineStation
                {
                    LineId= 9,
                    Code = 78,
                    LineStationIndex = 2,
                    PrevStation = 77,
                    NextStation = 83,

                },
                new LineStation
                {
                    LineId= 9,
                    Code = 83,
                    LineStationIndex = 3,
                    PrevStation = 78,
                    NextStation = 94,

                },
                new LineStation
                {
                    LineId= 9,
                    Code = 94,
                    LineStationIndex = 4,
                    PrevStation = 83,
                    NextStation = 95,

                },
                new LineStation
                {
                    LineId= 9,
                    Code = 95,
                    LineStationIndex = 5,
                    PrevStation = 94,
                    NextStation = 103,

                },
                new LineStation
                {
                    LineId= 9,
                    Code = 103,
                    LineStationIndex = 6,
                    PrevStation = 95,
                    NextStation = 106,

                },
                new LineStation
                {
                    LineId= 9,
                    Code = 106,
                    LineStationIndex = 7,
                    PrevStation = 103,
                    NextStation = 109,

                },
                new LineStation
                {
                    LineId= 9,
                    Code = 109,
                    LineStationIndex = 8,
                    PrevStation = 106,
                    NextStation = 111,

                },
                new LineStation
                {
                    LineId= 9,
                    Code = 111,
                    LineStationIndex = 9,
                    PrevStation = 109,
                    NextStation = -1,

                },

                #endregion
            };

            listAdjacentStations = new List<AdjacentStations>();

            #region restart AdjacentStations
            //Gets two consecutive line stations and calculates the distance and time between them by longitude and latitude. And thus initializes the subsequent stations
            foreach (LineStation ls in listLineStation)
            {
                if (!listLines.Exists(l => l.LastStation == ls.Code && l.LineId == ls.LineId))//if the lineStation is not the last in the bus
                {
                    AdjacentStations newAdj = new AdjacentStations();
                    newAdj.Station1 = ls.Code;
                    newAdj.Station2 = ls.NextStation;
                    double long1 = listStations.Find(st => st.Code == ls.Code).Longitude;
                    double long2 = listStations.Find(st => st.Code == newAdj.Station2).Longitude;
                    double lat1 = listStations.Find(st => st.Code == ls.Code).Lattitude;
                    double lat2 = listStations.Find(st => st.Code == newAdj.Station2).Lattitude;

                    newAdj.Distance = ((Math.Sqrt((Math.Pow(long1 - long2, 2) * 11) + (Math.Pow(lat1 - lat2, 2)) * 11)));

                    double timeInSec = ((newAdj.Distance * 1.5) / r.Next(20, 50))* 60;
                    int hours = (int)(timeInSec / 3600);
                    int min = (int)(timeInSec / 60);
                    int sec = (int)timeInSec;

                    if (sec == 0)
                    {
                        sec = 1;
                    }

                    TimeSpan time = new TimeSpan(hours, min, sec);
                    newAdj.Time = time;

                    listAdjacentStations.Add(newAdj);
                }
               
            }


            #endregion

            users = new List<User>()
            {
                #region User //אתחול משתמשים
                new User
                {
                    Name = "Chaim",
                    Password = "Chaim123",
                },
               
                #endregion
            };
            listLineTrips = new List<LineTrip>();
            #region restart lineTrips list


            foreach (Line ln in listLines)
            {
                int numLineTrip = r.Next(20, 30);
                for (int i = 0; i < numLineTrip; i++)
                {
                    LineTrip ltrip = new LineTrip();
                    ltrip.LineID = ln.LineId;
                    ltrip.LineTripID = i;
                    TimeSpan start = new TimeSpan(r.Next(5, 24), r.Next(0, 11) * 5, 0);
                    ltrip.StartAt = start;
                    listLineTrips.Add(ltrip);
                }

            }
            #endregion

        }
    }
}




