using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace site_pessoal_dinamico.Models
{
    public class skills
    {
        public int skillsId { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [Display(Name = "Descrição")]
        public string descricao_skills { get; set; }
    }
}
