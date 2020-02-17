using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SimpleForum.DataAccess
{
    public class DbAccess
    {
        private SqlConnection Connection;
        private SqlCommand Command;
        private string UniversalConnectionString;

        public SqlDataReader DataReader { get; set; }

        public DbAccess(string connString) => UniversalConnectionString = connString;

        public DbAccess InitializeProcedure(string storedProcedure)
        {

            Connection = new SqlConnection(UniversalConnectionString);
            Command = new SqlCommand(storedProcedure, Connection);
            Command.CommandType = System.Data.CommandType.StoredProcedure;
            return this;
        }

        public DbAccess InitializeProcedure(string storedProcedure, string connString)
        {

            Connection = new SqlConnection(connString);
            Command = new SqlCommand(storedProcedure, Connection);
            Command.CommandType = System.Data.CommandType.StoredProcedure;
            return this;
        }

        public DbAccess RunQuery(string query)
        {
            Connection = new SqlConnection(UniversalConnectionString);
            Command = new SqlCommand(query, Connection);
            return this;
        }


        public DbAccess RunQuery(string query, string connString)
        {
            Connection = new SqlConnection(connString);
            Command = new SqlCommand(query, Connection);
            return this;
        }

        public void ExecuteReader()
        {
            Connection.Open();
            DataReader = Command.ExecuteReader();
        }

        public void AddParam<T>(T value, string parameter, SqlDbType dbType, int size)
        {
            Command.Parameters.Add(parameter, dbType, size).Value = value;
        }

        public void Close()
        {
            DataReader.Close();
            Connection.Close();
        }
    }
}
