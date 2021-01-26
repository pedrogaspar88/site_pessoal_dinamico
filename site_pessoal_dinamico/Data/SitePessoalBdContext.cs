using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace site_pessoal_dinamico.Data
{
    public class SitePessoalBdContext : DbContext
    {


        public SitePessoalBdContext(DbContextOptions<SitePessoalBdContext> options)
                : base(options)
            {

            }
        public DbSet<site_pessoal_dinamico.Models.distincao_premios> distincao_premios { get; set; }
        public DbSet<site_pessoal_dinamico.Models.experiencia_profissional> experiencia_profissional { get; set; }
        public DbSet<site_pessoal_dinamico.Models.formacao> formacao { get; set; }
        public DbSet<site_pessoal_dinamico.Models.outras_informacoes> outras_informacoes { get; set; }
        public DbSet<site_pessoal_dinamico.Models.skills> skills { get; set; }

    }
    }

