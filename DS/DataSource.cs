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
        public static List<Station> listStations;
        public static List<Line> listLines;
        public static List<LineStation> listLineStation;
        public static List<AdjacentStations> listAdjacentStation;

        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            listStations = new List<Station>
            {
                #region Boot stations//איתחול תחנות
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
                    Name = "רבי עקיבע/הרב קוק ",
                    Address = " רחוב:רבי עקיבא 115 עיר: בני ברק",
                    Lattitude = 31.794958,
                    Longitude =35.205216
                },
                new Station
                {
                    Code = 32287,
                    Name = "רבי עקיבא/ גן ורשא ",
                    Address = " רחוב:רבי עקיבע 49 עיר: בני ברק",
                    Lattitude = 31.79617,
                    Longitude =35.206158
                }

                
                #endregion
            };
            listLines = new List<Line>
            {
                #region Boot lines//אתחול קוים
                new Line
                {
                    NumberBus = 56,
                    Area = Areas.Jerusalem,
                    FirstStation = 73,                    LastStation = 76,
                },
                new Line
                {
                    NumberBus = 179,
                    Area = Areas.Jerusalem,
                    FirstStation = 1491,
                    LastStation = 1486,
                },
                new Line
                {
                    NumberBus = 180,
                    Area = Areas.Jerusalem,
                    FirstStation = 86,
                    LastStation = 89,
                },
                new Line
                {
                    NumberBus = 277,
                    Area = Areas.Jerusalem,
                    FirstStation = 109,
                    LastStation = 119,
                },
                new Line
                {
                    NumberBus = 377,
                    Area = Areas.Jerusalem,
                    FirstStation = 1494,
                    LastStation = 1510,
                },
                new Line
                {
                    NumberBus = 3,
                    Area = Areas.Jerusalem,
                    FirstStation = 123,
                    LastStation = 121,
                },
                new Line
                {
                    NumberBus = 157,
                    Area = Areas.Jerusalem,
                    FirstStation = 76,
                    LastStation = 121,
                },
                new Line
                {
                    NumberBus = 280,
                    Area = Areas.Jerusalem,
                    FirstStation = 89,
                    LastStation = 90,
                },
                new Line
                {
                    NumberBus = 67,
                    Area = Areas.Jerusalem,
                    FirstStation = 105,
                    LastStation = 1494,
                },
                new Line
                {
                    NumberBus = 15,
                    Area = Areas.Jerusalem,
                    FirstStation = 1510,
                    LastStation = 111,
                },

                new Line
                {
                    NumberBus = 92,
                    Area = Areas.Center,
                    FirstStation = 46422,
                    LastStation = 32287,
                },
                new Line
                {
                    NumberBus = 108,
                    Area = Areas.Center,
                    FirstStation = 46422,
                    LastStation = 32298,
                },
               new Line                {                    NumberBus = 108,                    Area = Areas.Jerusalem,                    FirstStation = 106,                    LastStation = 88,                },


            #endregion
        };
            listLineStation = new List<LineStation>
            #region Boot lines//אתחול תחנות קו
            {
            new LineStation
            {

                Station = 89,
                LineStationIndex = 0,
                PrevStation = -1,
                NextStation = 76,
            },


           };

            #endregion
           
        }
    }
}

