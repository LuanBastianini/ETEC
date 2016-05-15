using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchouBaseRepository.Infra
{
    public interface IDatabaseConnection
    {
        SqlConnection SqlConnection { get; set; }
        SqlTransaction SqlTransaction { get; set; }
        void OpenTransaction();
        void Commit();
        void Rollback();
        void Dispose();


    }
}
