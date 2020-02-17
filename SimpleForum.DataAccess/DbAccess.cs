using SimpleForum.Domain.Forum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SimpleForum.DataAccess
{
    public class DbAccess
    {
        private SqlConnection Connection;
        private SqlCommand Command;
        private string UniversalConnectionString;

        public SqlDataAdapter DataAdapter { get; set; }

        public DbAccess(string connString) => UniversalConnectionString = connString;

        public DbAccess InitializeQuery(string query, string connString = null)
        {
            Connection = new SqlConnection(connString ?? UniversalConnectionString);
            DataAdapter = new SqlDataAdapter(query, Connection);
            return this;
        }

        public DbAccess InitializeProcedure(string storedProcedure, string connString = null)
        {

            Connection = new SqlConnection(connString ?? UniversalConnectionString);
            DataAdapter = new SqlDataAdapter(storedProcedure, Connection);
            DataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            return this;
        }
    
        public void AddParam<T>(T value, string parameter, SqlDbType dbType, int size)
        {
            DataAdapter.SelectCommand.Parameters.Add(parameter, dbType, size).Value = value;
        }

    }
}
