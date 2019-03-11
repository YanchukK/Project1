using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.ComponentModel;

namespace MyORM
{
    public class DBList<T> where T : Entity
    {
        protected List<T> data;

        protected Type dataType;

        public string ConnectionString { get; set; }

        public DBList(string connectionString)
        {
            this.ConnectionString = connectionString;

            this.data = new List<T>();

            this.dataType = typeof(T);
        }


        public T Insert(T t)
        {
            string sql = $"SELECT * FROM {this.dataType.Name}";
            using (var connection = new MySqlConnection(this.ConnectionString))
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];

                DataRow row = dt.NewRow();
                foreach (var prop in this.dataType.GetProperties())
                    row[prop.Name] = prop.GetValue(t) ?? DBNull.Value;

                dt.Rows.Add(row);

                MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);
                adapter.Update(ds);
                ds.Clear();
                adapter.Fill(ds);
            }

            return default(T);
        }


        public T GetById(int id)
        {
            var t = this.data.FirstOrDefault(e => e.Id == id);

            if (t != null)
            {
                return t;
            }

            this.GetAll();

            return this.data.First(e => e.Id == id);
        }


        public IEnumerable<T> GetAll()
        {
            using (var connection = new MySqlConnection(this.ConnectionString))
            {
                string cndText = $"select * from {this.dataType.Name}";
                MySqlCommand sqlCommand = new MySqlCommand(cndText, connection);
                connection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlCommand);

                DataSet ds = new DataSet();

                adapter.Fill(ds);

                foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        T item = GetItem<T>(row);
                        data.Add(item);
                    }
                }
            }

            return this.data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T t = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo prop in temp.GetProperties())
                {
                    if (prop.Name == column.ColumnName)
                        prop.SetValue(t, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return t;
        }


        public T Update(T t)
        {
            //using (var connection = new MySqlConnection(this.ConnectionString))
            //{
            //    string cndText = $"UPDATE {this.dataType.Name}" +
            //        $"SET " + t +
            //        $" WHERE id = {t.Id}";
            //    MySqlCommand sqlCommand = new MySqlCommand(cndText, connection);

            //    connection.Open();
            //    sqlCommand.ExecuteNonQuery();
            //}


            return default(T);
        }

        public bool Delete(T t)
        {
            if (GetAll().Count() == 0)
            {
                return false;
            }
            else
            {
                using (var connection = new MySqlConnection(this.ConnectionString))
                {
                    string cndText = $"DELETE FROM {this.dataType.Name} WHERE id = {t.Id}";
                    MySqlCommand sqlCommand = new MySqlCommand(cndText, connection);

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }

                return true;
            }
        }
    }
}
