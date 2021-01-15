using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   
    public static class DeepCopyUtilities
    {
        /// <summary>
        /// copy the properties to template
        /// </summary>
       
        public static void CopyPropertiesTo<T, S>(this S from, T to)
        {
            foreach (PropertyInfo propTo in to.GetType().GetProperties())
            {
                PropertyInfo propFrom = typeof(S).GetProperty(propTo.Name);
                if (propFrom == null)
                    continue;
                var value = propFrom.GetValue(from, null);
                if (value is ValueType || value is string)
                    propTo.SetValue(to, value);
            }
        }
        /// <summary>
        /// copy the properties to new object
        /// </summary>

        public static object CopyPropertiesToNew<S>(this S from, Type type)
        {
            object to = Activator.CreateInstance(type); // new object of Type
            from.CopyPropertiesTo(to);
            return to;
        }
        /// <summary>
        /// copy the properties to list of lines
        /// </summary>

        public static BO.Line CopyToListOfLines(this DO.Line line, DO.LineStation sic)
        {
            BO.Line result = (BO.Line)line.CopyPropertiesToNew(typeof(BO.Line));
            // propertys' names changed? copy them here...
            result.LineId = sic.LineId;
            return result;
        }
        /// <summary>
        /// copy the properties to statio line
        /// </summary>

        public static BO.LineStation CopyToStationLine(this DO.Line line, DO.LineStation sic)
        {
            BO.LineStation result = (BO.LineStation)line.CopyPropertiesToNew(typeof(BO.LineStation));
            // propertys' names changed? copy them here...
            result.LineStationIndex = sic.LineStationIndex;
            result.Name = sic.Name;
            result.Code = sic.Code;
            return result;
        }
        

    }
}
