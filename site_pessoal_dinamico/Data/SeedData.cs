using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using site_pessoal_dinamico.Models;

namespace site_pessoal_dinamico.Data
{
    public class SeedData
    {
        private const string NOME_UTILIZADOR_ADMIN_PADRAO = "admin@ipg.pt";
        private const string PASSWORD_UTILIZADOR_ADMIN_PADRAO = "@UPsk1ll";

        private const string ROLE_ADIMINISTRADOR = "Administrador";
        //private const string ROLE_CLIENTE = "Cliente";
        private const string ROLE_GESTOR = "Gestor";
        internal static void PreencheDados(SitePessoalBdContext bd)
        {
            DistincaoPremios(bd);
            InsereSkills(bd);
            InsereOutrasInf(bd);
            InsereFormacao(bd);
            InsereExpPro(bd);

        }

        internal static async Task InsereUtilizadoresFicticiosAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            //IdentityUser cliente = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "joao@ipg.pt", "Secret123$");
            //await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, cliente, ROLE_CLIENTE);

            IdentityUser gestor = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, "jose@ipg.pt", "@UPsk1ll");
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, gestor, ROLE_GESTOR);
        }

        internal static async Task InsereRolesAsync(RoleManager<IdentityRole> gestorRoles)
        {
            await CriaRoleSeNecessario(gestorRoles, ROLE_ADIMINISTRADOR);
            //await CriaRoleSeNecessario(gestorRoles, ROLE_CLIENTE);
            await CriaRoleSeNecessario(gestorRoles, ROLE_GESTOR);
            
        }

        private static async Task CriaRoleSeNecessario(RoleManager<IdentityRole> gestorRoles, string funcao)
        {
            if (!await gestorRoles.RoleExistsAsync(funcao))
            {
                IdentityRole role = new IdentityRole(funcao);
                await gestorRoles.CreateAsync(role);
            }
        }
        internal static async Task InsereAdministradorPadraoAsync(UserManager<IdentityUser> gestorUtilizadores)
        {
            IdentityUser utilizador = await CriaUtilizadorSeNaoExiste(gestorUtilizadores, NOME_UTILIZADOR_ADMIN_PADRAO, PASSWORD_UTILIZADOR_ADMIN_PADRAO);
            await AdicionaUtilizadorRoleSeNecessario(gestorUtilizadores, utilizador, ROLE_ADIMINISTRADOR);
        }

        private static async Task AdicionaUtilizadorRoleSeNecessario(UserManager<IdentityUser> gestorUtilizadores, IdentityUser utilizador, string role)
        {
            if (!await gestorUtilizadores.IsInRoleAsync(utilizador, role))
            {
                await gestorUtilizadores.AddToRoleAsync(utilizador, role);
            }
        }

        private static async Task<IdentityUser> CriaUtilizadorSeNaoExiste(UserManager<IdentityUser> gestorUtilizadores, string nomeUtilizador, string password)
        {
            IdentityUser utilizador = await gestorUtilizadores.FindByNameAsync(nomeUtilizador);

            if (utilizador == null)
            {
                utilizador = new IdentityUser(nomeUtilizador);
                await gestorUtilizadores.CreateAsync(utilizador, password);
            }

            return utilizador;

        }

        private static void DistincaoPremios(SitePessoalBdContext bd)
        {
            if (bd.distincao_premios.Any()) return;


            bd.distincao_premios.AddRange(new distincao_premios[] {
                new distincao_premios
                {
                    descricao_distincao="Participação na 16º edição do concurso Poliempreende(Concurso de Vocação Empresarial).Destaque para: " +
                    " 1º lugar a nível regional, " +
                    " 3º lugar a nível nacional, " +
                    " Com o projeto HEF(Hydroponic Evolution Farm)"
                },
            });
            bd.SaveChanges();
        }

        public static void InsereSkills(SitePessoalBdContext bd)
        {
            if (bd.skills.Any()) return;


            bd.skills.AddRange(new skills[] {
                new skills
                {
                    descricao_skills="Auditor de Sistemas Integrados de Gestão: Qualidade, Ambiente e Segurança"
                },
                 new skills
                {
                    descricao_skills="Implementação ou verificação das normas relacionadas com Sistemas Integrados de Gestão (nomeadamente ISO 9001; NP4469-1, SA8000, ISO 26000; ISO 14000 e OHSAS 18000)"
                }, new skills
                {
                    descricao_skills="Técnicas laboratoriais na área da biologia, química, bioquímica, microbiologia, toxicologia e ambiente"
                }, new skills
                {
                    descricao_skills="Realização do curso de formação contínua em Trabalho em Equipa, organizado pela Universidade da Beira Interior"
                },
            });
            bd.SaveChanges();
        }
        public static void InsereOutrasInf(SitePessoalBdContext bd)
        {
            if (bd.outras_informacoes.Any()) return;


            bd.outras_informacoes.AddRange(new outras_informacoes[] {
                new outras_informacoes
                {
                    descricao_informacao="Membro do conselho pedagógico da Escola Superior de Tecnologia e Gestão de Setembro 2017 a Novembro de 2019"
                },
                 new outras_informacoes
                {
                    descricao_informacao="Participação no programa Jovens Embaixadores de Córdoba organizado pelo Ayuntamiento De Córdoba de Dezembro de 2015 a Julho de 2016"
                }, new outras_informacoes
                {
                    descricao_informacao="Praticante de xadrez amador"
                },
            });
            bd.SaveChanges();
        }

        public static void InsereFormacao(SitePessoalBdContext bd)
        {
            if (bd.formacao.Any()) return;


            bd.formacao.AddRange(new formacao[] {
                new formacao
                {
                    nome_instituicao="Instituto Politécnico da Guarda",
                    nome_curso="Sistemas Integrados de Gestão",
                    nivel= "Nível 7",
                    competencias="Integrar os diferentes sistemas de gestão, especificamente de responsabilidade social, qualidade, ambiente e segurança no trabalho, com a gestão da prevenção e riscos, de forma a aproveitar sinergias, " +
                                  " Realizar auditorias na forma individualizada ou integrada, aos sistemas de gestão",
                    dataInicio= new DateTime(2017,01,13),
                    dataFim=new DateTime(2022,06,06),

                },
                  new formacao
                {
                    nome_instituicao="Universidade da Beira Interior",
                    nome_curso="Bioquímica",
                    nivel= "Nível 6",
                    competencias="Execução de procedimentos laboratoriais utilizados no estudo dos microrganismos seguindo as normas de segurança em microbiologia,"+
                                   " Conhecimentos fundamentais de química nomeadamente sobre as teorias da ligação química, leis de gases, sólidos cristalinos e termodinâmica química," +
                                   " Monitorização de linhas de água através da determinação de sólidos, CQO, CBO, azoto Kjeldahl e Amoniacal e fósforo, bem como ensaios de respirometria",
                    dataInicio=new DateTime(2006,09,04),
                    dataFim=new DateTime(2016,06,05),
                }
            });
            bd.SaveChanges();
        }
        public static void InsereExpPro(SitePessoalBdContext bd)
        {
            if (bd.experiencia_profissional.Any()) return;


            bd.experiencia_profissional.AddRange(new experiencia_profissional[] {
    
                new experiencia_profissional
                {
                    funcao = "Corporate Functional Safety Test Technican",
                    empresa = "Coficab",
                    descricao_exp = "Apoiar na análise dos registos de qualidade associados ao plano de controlo," +
                                    " Apoiar nos ajustes ao plano de controlo/processo",
                    dataInicio = new DateTime(2018,04,05),
                    dataFim = new DateTime(2019,02,01),


                },
                new experiencia_profissional
                {
                    funcao = "Químico",
                    empresa = "Universidade da Beira Interior",
                    descricao_exp = "Produção de celulose nanofibrilada a partir de celulose de madeira," +
                                    " Conversão do gel de celulose em filamento através de um processo de extrusão com posterior troca de solvente",
                    dataInicio = new DateTime (2017,06,01),
                    dataFim = new DateTime (2017,07,30),


                },
            }); ;
            bd.SaveChanges();

        }
    }
}

