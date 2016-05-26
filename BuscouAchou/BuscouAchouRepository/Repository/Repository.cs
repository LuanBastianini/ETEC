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
    public static class ProcedureExtension
    {
        public static T ReadAttr<T>(this IDataReader reader, string attrName)
        {

            if (reader[attrName] == DBNull.Value || string.IsNullOrEmpty(reader[attrName].ToString()))
                return default(T);

            var tipoT = typeof(T);
            var tipoR = reader[attrName].GetType();

            return tipoR == tipoT || (tipoT.GetGenericArguments().Any() && tipoR == tipoT.GenericTypeArguments[0])
                    ? (T)reader[attrName]
                    : (T)Convert.ChangeType(reader[attrName], typeof(T));

        }
    }

    public class Repository : BaseRepository
    {
        private enum procidures 
        {
            BARSP_InsUsuario,
            BARSP_VerificaEmail,
            BARSP_UsuarioLogado,
            BARSP_VerificaSenha,
            BARSP_SelDadosUsuario,
            BARSP_UpdDadosUsuario
        }

        public void Post(BAR_Usuario entitie) 
        {
            ExecuteProcedure(procidures.BARSP_InsUsuario);
            AddParameter("@Nom_Usua", entitie.Nom_Usua);
            AddParameter("@Email", entitie.Email);
            AddParameter("@Num_SenhaCrip", entitie.SenhaCriptog.ToString());
            ExecuteNonQuery();
        }

        public int VerificaEmail(string email) 
        {
            ExecuteProcedure(procidures.BARSP_VerificaEmail);
            AddParameter("@Email", email);
            return ExecuteNonQueryWithReturn<int>();
        }

        public int UsuarioLogado(string email, string senha) 
        {
            ExecuteProcedure(procidures.BARSP_UsuarioLogado);
            AddParameter("@EmailLog",email);
            AddParameter("@SenhaLog", senha);
            return ExecuteNonQueryWithReturn<int>();
        }

        public BAR_Usuario GetDadosUsuario(int codUsua)
        {
            ExecuteProcedure(procidures.BARSP_SelDadosUsuario);

            AddParameter("@Num_SeqlUsuario", codUsua);

            using (var r = ExecuteReader())
            {
                var listUsua = new BAR_Usuario();

                if (r.Read())
                {
                    listUsua.Nom_Usua = r.ReadAttr<string>("Nom_Usua");
                    listUsua.Email = r.ReadAttr<string>("Email");
                }

                return listUsua;
            }
        }
        public void PutDadosUsuario(int codUsua, BAR_Usuario entitie ) 
        {
            ExecuteProcedure(procidures.BARSP_UpdDadosUsuario);

            AddParameter("@Num_SeqlUsuario", codUsua);
            AddParameter("@Nom_Usua", entitie.Nom_Usua);
            AddParameter("@Email", entitie.Email);
            AddParameter("@Num_SenhaCrip", entitie.SenhaCriptog.ToString());
            ExecuteNonQuery();
        }
    }
}
