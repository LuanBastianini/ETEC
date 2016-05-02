using BuscouAchou.Domain;
using BuscouAchouRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchou.Aplication
{
    public class Aplication
    {
        private Repository repository;

        public SqlDataReader listaReceitas()
        {
            using (repository = new Repository()) 
            {
                var strQuery = "SELECT * from BAR_Receita";
                return repository.ExecutaComandoComRetorno(strQuery);
            }
        }
    }
}
