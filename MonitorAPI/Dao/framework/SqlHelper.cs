using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace MonitorAPI.Dao
{
    class SqlHelper
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        internal static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static IEnumerable<T> ExecuteReaderCmd<T>(SqlCommand SQL)
        {
            SqlDataReader sqlReader = SQL.ExecuteReader();

            PropertyInfo[] pis = typeof(T).GetProperties();
            while (sqlReader.Read())
            {
                Object o = Activator.CreateInstance(typeof(T));
                foreach (System.Reflection.PropertyInfo pi in pis)
                {
                    if (sqlReader[pi.Name] != DBNull.Value)
                    {
                        pi.SetValue(o, Convert.ChangeType(sqlReader[pi.Name].ToString(), GetType(pi)), null);
                    }
                }
                yield return (T)o;
            }
            sqlReader.Close();
        }

        public static T ExecuteReaderCmdObject<T>(SqlCommand SQL)
        {
            SqlDataReader sqlReader = SQL.ExecuteReader();
            PropertyInfo[] pis = typeof(T).GetProperties();
            Object o = null;
            if (sqlReader.Read())
            {
                o = Activator.CreateInstance(typeof(T));
                foreach (System.Reflection.PropertyInfo pi in pis)
                {
                    if (sqlReader[pi.Name] != DBNull.Value)
                    {
                        pi.SetValue(o, Convert.ChangeType(sqlReader[pi.Name].ToString(), GetType(pi)), null);
                    }
                }
            }
            sqlReader.Close();
            return (T)o;
        }

        public static List<T> ExecuteReaderCmdList<T>(SqlCommand SQL)
        {
            List<T> list = new List<T>();
            SqlDataReader sqlReader = SQL.ExecuteReader();
            PropertyInfo[] pis = typeof(T).GetProperties();
            while (sqlReader.Read())
            {
                Object o = Activator.CreateInstance(typeof(T));
                foreach (PropertyInfo pi in pis)
                {
                    if (sqlReader[pi.Name] != DBNull.Value)
                    {
                        pi.SetValue(o, Convert.ChangeType(sqlReader[pi.Name].ToString(), GetType(pi)), null);
                    }
                }
                list.Add((T)o);
            }
            sqlReader.Close();
            return list;
        }

        private static Type GetType(PropertyInfo pi)
        {
            if (pi.PropertyType == typeof(Char) || pi.PropertyType == typeof(Nullable<Char>))
            {
                return typeof(Char);
            }
            else if (pi.PropertyType == typeof(Boolean) || pi.PropertyType == typeof(Nullable<Boolean>))
            {
                return typeof(Boolean);
            }
            else if (pi.PropertyType == typeof(DateTime) || pi.PropertyType == typeof(Nullable<DateTime>))
            {
                return typeof(DateTime);
            }
            else if (pi.PropertyType == typeof(Int16) || pi.PropertyType == typeof(Nullable<Int16>))
            {
                return typeof(Int16);
            }
            else if (pi.PropertyType == typeof(Int32) || pi.PropertyType == typeof(Nullable<Int32>))
            {
                return typeof(Int32);
            }
            else if (pi.PropertyType == typeof(Int64) || pi.PropertyType == typeof(Nullable<Int64>))
            {
                return typeof(Int64);
            }
            else
            {
                return pi.PropertyType;
            }
        }

        public static T GetSingleObject<T>(IEnumerable<T> list)
        {
            foreach (T elem in list)
            {
                return elem;
            }

            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
