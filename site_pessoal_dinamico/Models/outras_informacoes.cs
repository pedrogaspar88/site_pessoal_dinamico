using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site_pessoal_dinamico.Models
{
    public class outras_informacoes
    {
        public int outras_informacoesId { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        public string descricao_informacao { get; set; }
    }
}
