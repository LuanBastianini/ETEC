using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscouAchou.Domain.DataModels
{
    public class ReceitasBuscadasDataModel
    {
        public ReceitasBuscadasDataModel()
        {
            Ingredientes = new List<IngredientesDataModel>();
            ModoPreparo = new List<ModoPreparoDataModel>();
        }

        public int Num_SeqlReceitas { get; set; }
        public string Nom_Receita { get; set; }
        public short Temp_Prep { get; set; }
        public short Rend_Porc { get; set; }
        public string Nom_Usua { get; set; }

        public List<IngredientesDataModel> Ingredientes { get; set; }
        public List<ModoPreparoDataModel> ModoPreparo { get; set; }

        public string NomeImagem 
        { 
            get 
            {
                return string.Format("{0}.jpg", Num_SeqlReceitas);
            }
        }
    }
}
