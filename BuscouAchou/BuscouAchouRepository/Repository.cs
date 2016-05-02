using BuscouAchou.Infra.Data;
using BuscouAchouBaseRepository.Infra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchouRepository
{
    public class Repository : BaseRepository
    {
        public Repository(IDatabaseConnection connection ) : base(connection)
        {
        }
         

    }

}
