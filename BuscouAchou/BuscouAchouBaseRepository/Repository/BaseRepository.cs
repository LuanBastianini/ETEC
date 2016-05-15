using BuscouAchouBaseRepository.Infra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchou.Infra.Data
{
    public class BaseRepository
    {
        protected readonly IDatabaseConnection Connection;

        public BaseRepository()
        {
            DatabaseConnection connection = new DatabaseConnection();
            Connection = connection;
        }

        protected SqlCommand SqlCommand { get; set; }

        //TRANSACTION
        public void OpenTransaction()
        {
            Connection.OpenTransaction();
        }

        public void RollbackTransaction()
        {
            Connection.Rollback();
        }

        public void CommitTransaction()
        {
            Connection.Commit();
        }

        //CONNECTION
        protected void OpenConnection()
        {
            if (SqlCommand.Connection.State == ConnectionState.Broken)
            {
                SqlCommand.Connection.Close();
                SqlCommand.Connection.Open();
            }

            if (SqlCommand.Connection.State == ConnectionState.Closed)
                SqlCommand.Connection.Open();
        }

        public void CloseConnection()
        {
            Connection.SqlConnection.Close();
        }

        //PROCEDURE
        protected void ExecuteProcedure(object procedureName)
        {
            SqlCommand = new SqlCommand(procedureName.ToString(), Connection.SqlConnection, Connection.SqlTransaction)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 99999,
            };
        }

        //PARAMETERS
        protected void AddParameter(string parameterName, object parameterValue)
        {
            SqlCommand.Parameters.AddWithValue(parameterName, parameterValue);
        }

        protected void AddParameterOutput(string parameterName, object parameterValue, DbType parameterType)
        {
            var parameter = new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.Output,
                Value = parameterValue,
                DbType = parameterType
            };
            SqlCommand.Parameters.Add(parameter);
        }

        protected void AddParameterReturn(string parameterName = "@RETURN_VALUE", DbType parameterType = DbType.Int16)
        {
            var parameter = new SqlParameter
            {
                ParameterName = parameterName,
                Direction = ParameterDirection.ReturnValue,
                DbType = parameterType
            };

            SqlCommand.Parameters.Add(parameter);
        }

        protected string GetParameterOutput(string parameter)
        {
            return SqlCommand.Parameters[parameter].Value.ToString();
        }

        //EXECUTE
        protected int ExecuteNonQuery()
        {
            OpenConnection();
            return SqlCommand.ExecuteNonQuery();
        }

        protected int ExecuteNonQueryWithReturn()
        {
            AddParameterReturn();
            OpenConnection();
            SqlCommand.ExecuteNonQuery();
            return int.Parse(SqlCommand.Parameters["@RETURN_VALUE"].Value.ToString());
        }

        protected T ExecuteNonQueryWithReturn<T>()
        {
            AddParameterReturn();
            OpenConnection();
            SqlCommand.ExecuteNonQuery();
            var value = SqlCommand.Parameters["@RETURN_VALUE"].Value;
            if (value == DBNull.Value)
                return default(T);
            return (T)Convert.ChangeType(value, typeof(T));
        }

        //READER
        protected IDataReader ExecuteReader()
        {
            OpenConnection();
            return SqlCommand.ExecuteReader();
        }

        protected IDataReader ExecuteReader(CommandBehavior cb)
        {
            return SqlCommand.ExecuteReader(cb);
        }
    }
}
