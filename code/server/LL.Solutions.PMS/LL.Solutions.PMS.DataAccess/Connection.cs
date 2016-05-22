using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LL.Solutions.PMS.DataAccess
{
    public class Connection<T>
    {
        #region Members
        public const string connectionString = "Server=localhost;Database=pms;Uid=root;Pwd=Password!;";
        internal static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        MySqlConnection connection = null;
        #endregion

        #region Constructor
        public Connection(string connectionString = connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                connection = new MySqlConnection(connectionString);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// OpenConnection
        /// </summary>
        public void OpenConnection()
        {
            try
            {
                log.Info("Opening Connection");
                connection.Open();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// LoadData
        /// </summary>
        /// <param name="cmd"></param>
        public IList<T> LoadData(string cmdText)
        {
            try
            {
                log.Info("Entering LoadData!");
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = cmdText;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                log.Info("Exiting LoadData!");
                return ConvertTo<T>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// ConvertTo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }


        /// <summary>
        /// ConvertTo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="rows"></param>
        /// <returns></returns>
        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>
        /// ConvertTo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        /// <summary>
        /// CreateItem
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value);
                    }
                    catch(Exception ex)
                    {
                        //swallow exception
                    }
                }
            }

            return obj;
        }

        /// <summary>
        /// CreateTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }

        /// <summary>
        /// CloseConnection
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    log.Info("Closing Connection");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }
        #endregion
    }
}
