using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchou.Domain
{
    public class ReceitaDataModel
    {
        public int Num_SeqlReceitas { get; set; }
        public int Num_SeqlUsua { get; set; }
        public string Nom_Receita { get; set; }
        public string Ind_LibComp { get; set; }
        public short Temp_Prep { get; set; }
        public short Rend_Porc { get; set; }
    }
}
