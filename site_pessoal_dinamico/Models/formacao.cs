using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace site_pessoal_dinamico.Models
{
    public class formacao
    {
        public int formacaoId { get; set; }

        public string nome_instituicao { get; set; }

        public string nome_curso { get; set; }

        public string nivel { get; set; }

        public string competencias { get; set; }

        public DateTime dataInicio { get; set; }

        public DateTime dataFim { get; set; }
    }
}
