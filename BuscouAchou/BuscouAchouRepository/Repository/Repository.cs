using BuscouAchou.Domain.Entities;
using BuscouAchou.Infra.Data;
using BuscouAchouBaseRepository.Infra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchouRepository
{
    public class Repository : BaseRepository
    {
        private enum procidures 
        {
            BARSP_InsUsuario,
            BARSP_VerificaUsuario,
            BARSP_VerificaUsuarioLogado
        }

        public void Post(BAR_Usuario entitie) 
        {
            ExecuteProcedure(procidures.BARSP_InsUsuario);
            AddParameter("@Nom_Usua", entitie.Nom_Usua);
            AddParameter("@Email", entitie.Email);
            AddParameter("@Num_SenhaCrip", entitie.SenhaCriptog.ToString());
            ExecuteNonQuery();
        }

        public int VerificaUsuario(string Email) 
        {
            ExecuteProcedure(procidures.BARSP_VerificaUsuario);
            AddParameter("@Email", Email);
            return ExecuteNonQueryWithReturn<int>();
        }
    }

}
