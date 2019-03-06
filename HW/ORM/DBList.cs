using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

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
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                string cndText = $"insert * from [dbo].[{this.dataType.Name}] ()";
                SqlCommand sqlCommand = new SqlCommand(cndText, connection);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
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

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            T t = Activator.CreateInstance<T>();

                            foreach(var prop in this.dataType.GetProperties())
                            {
                                prop.SetValue(t, reader[prop.Name]);
                            }

                            this.data.Add(t);

                        }
                    }
                }
            }

            return this.data;
        }

        public T Update(T t)
        {
            return default(T);
        }

        public bool Delete(T t)
        {
            return true;
        }
    }
}
