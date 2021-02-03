using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site_pessoal_dinamico.Models
{
    public class formacao
    {
        public int formacaoId { get; set; }

        [Display(Name = "Nome da Instituição")] 
        public string nome_instituicao { get; set; }


        [Display(Name = "Curso")] 
        public string nome_curso { get; set; }


        [Display(Name = "Nível")] 
        public string nivel { get; set; }


        [Display(Name = "Principais Competências")]
        public string competencias { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data Início")] 
        public DateTime dataInicio { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data Fim")]
        public DateTime dataFim { get; set; }
    }
}
