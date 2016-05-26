using System;
using System.Data;
using System.Linq;

namespace ProcedureExtension
{
    public static class ProcedureExtension
    {
        public static T ReadAttr<T>(this IDataReader reader, string attrName)
        {

            if (reader[attrName] == DBNull.Value || string.IsNullOrEmpty(reader[attrName].ToString()))
                return default(T);

            var tipoT = typeof(T);
            var tipoR = reader[attrName].GetType();

            return tipoR == tipoT || (tipoT.GetGenericArguments().Any() && tipoR == tipoT.GenericTypeArguments[0])
                    ? (T)reader[attrName]
                    : (T)Convert.ChangeType(reader[attrName], typeof(T));

        }
    }
}
