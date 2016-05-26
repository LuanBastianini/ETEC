using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchou.Domain.Entities
{
    public class BAR_Usuario
    {
        public int Num_SeqlUsuario { get; set; }
        public string Nom_Usua { get; set; }
        public string Email { get; set; }
        public string Num_Senha { get; set; }

        public StringBuilder SenhaCriptog 
        { 
            get {
                if (Num_Senha != null)
                {
                    UnicodeEncoding encoding = new UnicodeEncoding();
                    byte[] hashBytes;
                    using (HashAlgorithm hash = SHA1.Create())
                        hashBytes = hash.ComputeHash(encoding.GetBytes(Num_Senha));

                    StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
                    foreach (byte b in hashBytes)
                    {
                        hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
                    }
                    return hashValue;
                }

                return null;
            } 
        }
    }
}
