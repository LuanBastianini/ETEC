using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchouBaseRepository.Infra
{
    public class DatabaseConnection : IDatabaseConnection, IDisposable
    {
        public DatabaseConnection()
        {
            SqlConnection = new SqlConnection(string.Format(@"data source=LUAN\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=BuscouAchouReceitas"));
        }

        public SqlConnection SqlConnection { get; set; } 

        public SqlTransaction SqlTransaction { get; set; }

        public void OpenTransaction()
        {
            if (SqlConnection.State == ConnectionState.Broken)
            {
                SqlConnection.Close();
                SqlConnection.Open();
            }

            if (SqlConnection.State == ConnectionState.Closed)
                SqlConnection.Open();

            SqlTransaction = SqlConnection.BeginTransaction();
        }

        public void Commit()
        {
            SqlTransaction.Commit();
            SqlTransaction.Dispose();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
            SqlTransaction.Dispose();
        }

        public void Dispose()
        {
            SqlConnection.Close();
        }
    }
}
