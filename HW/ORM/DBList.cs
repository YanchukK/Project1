using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace ConsoleAppWithDB
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
            string sql = $"SELECT * FROM [dbo].[{this.dataType.Name}]";
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DataTable dt = ds.Tables[0];

                DataRow row = dt.NewRow();
                foreach (var prop in this.dataType.GetProperties())
                    row[prop.Name] = prop.GetValue(t) ?? DBNull.Value;

                dt.Rows.Add(row);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
                ds.Clear();
                adapter.Fill(ds);
            }

            return default(T);
        }

        public T GetById(int id)
        {
            var t = this.data.FirstOrDefault(e => e.Id == id);

            if(t != null)
            {
                return t;
            }

            this.GetAll();

            return this.data.First(e => e.Id == id);
        }
         

        public IEnumerable<T> GetAll()
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                string cndText = $"select * from [dbo].[{this.dataType.Name}]";
                SqlCommand sqlCommand = new SqlCommand(cndText, connection);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

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
                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    string cndText = $"DELETE FROM [dbo].[{this.dataType.Name}] WHERE id = {t.Id}";
                    SqlCommand sqlCommand = new SqlCommand(cndText, connection);

                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                return true;
            }
        }
    }
}
