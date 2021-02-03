using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site_pessoal_dinamico.Models
{
    public class experiencia_profissional
    {
        public int experiencia_profissionalId { get; set; }

        public string funcao { get; set; }
 
        public string empresa { get; set; }

        public string descricao_exp { get; set; }

        public DateTime dataInicio { get; set; }

        public DateTime dataFim { get; set; }
      
    }
}
