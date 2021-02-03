using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site_pessoal_dinamico.Models
{
    public class experiencia_profissional
    {
        public int experiencia_profissionalId { get; set; }

        [Display(Name = "Função")] 
        public string funcao { get; set; }

        [Display(Name = "Nome da Empresa")] 
        public string empresa { get; set; }

        [Display(Name = "Descrição")]
        public string descricao_exp { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Início")]
        public DateTime dataInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Fim")]
        public DateTime dataFim { get; set; }
      
    }
}
