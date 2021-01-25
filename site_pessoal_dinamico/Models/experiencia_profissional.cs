using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site_pessoal_dinamico.Models
{
    public class experiencia_profissional
    {
        public int experiencia_profissioalId { get; set; }

        public string funcao { get; set; }

        public string empresa { get; set; }

        public string descricao { get; set; }

        public DateTime data { get; set; }
    }
}
