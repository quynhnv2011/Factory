using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.ExtData
{
    public static class ConvertExt
    {
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public static DataTable ToDataTableExcelListTaiSan<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    var val = Props[i].GetValue(item, null);
                    if (
                       
                        (i == 12) ||
                        (i == 13) ||
                        (i == 14) ||
                        (i == 15) ||
                        (i == 17) ||
                        (i == 18) ||
                        (i == 19) ||
                        (i == 20) ||
                        (i == 22) ||
                        (i == 23) ||
                        (i == 25) ||
                        (i == 26) ||
                        (i == 27) ||
                        (i == 28) ||
                        (i == 29) ||
                        (i == 30) ||
                        (i == 34) ||
                        (i == 35) ||
                        (i == 36) ||
                        (i == 37) ||
                        (i == 38))
                    {
                        val = (val.ToString() == "0") ? "Không" : "Có";
                    }
                    else if(i==30)
                    {
                        val = (val.ToString() == "0") ? "CNKD" : "Đi thuê";
                    }
                    else if (i == 2)
                    {
                        val = (val.ToString() == "0") ? "LD" : "BS";
                    }
                    values[i] = val;
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
}
