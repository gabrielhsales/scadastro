using Microsoft.AspNetCore.Mvc;
using scadastro.Controllers;
using scadastro.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace scadastro.ViewModels.AlunosViewModels
{
    public class ListagemAlunosViewModel
    {
        public List<Listagem> ListAluno { get; set; }

        public Cadastro CadastrAluno { get; set; }

        public class Listagem
        {
            public int Id { get; set; }

            public string Nome { get; set; }

            public string Cpf { get; set; }

            public string Nacionalidade { get; set; }

            public string Cep { get; set; }

            public string Estado { get; set; }

            public string Cidade { get; set; }

            public string Logadouro { get; set; }

            public string Email { get; set; }

            public string Telefone { get; set; }

            public string Mae { get; set; }

            public string CpfMae { get; set; }

            public string Pai { get; set; }

            public string CpfPai { get; set; }

            public string TelefoneResponavel { get; set; }

            public string Rg { get; set; }

            public string EmissaoRg { get; set; }

            public string DataNascimento { get; set; }

            public char Sexo { get; set; }
        }


        public class Cadastro
        {

            public int? Id { get; set; }

            [Display(Name = "Nome")]
            [Required(ErrorMessage = "Nome é obrigatorio")]
            public string Nome { get; set; }

            [Display(Name = "CPF")]
            [Required(ErrorMessage = "CPFé obrigatorio")]
            public string Cpf { get; set; }

            [Display(Name = "Nacionalidade")]
            [Required(ErrorMessage = "Nacionalidade é obrigatorio")]
            public string Nacionalidade { get; set; }

            [Display(Name = "CEP")]
            [Required(ErrorMessage = "CEP é obrigatorio")]
            public string Cep { get; set; }

            [Display(Name = "Estado")]
            [Required(ErrorMessage = "Estado é obrigatorio")]
            public string Estado { get; set; }

            [Display(Name = "Cidade")]
            [Required(ErrorMessage = "Cidade é obrigatorio")]
            public string Cidade { get; set; }

            [Display(Name = "Logadouro")]
            [Required(ErrorMessage = "Logadouro é obrigatorio")]
            public string Logadouro { get; set; }

            [Display(Name = "Email")]
            [Required(ErrorMessage = "Email é obrigatorio")]
            public string Email { get; set; }

            [Display(Name = "Telefone")]
            [Required(ErrorMessage = "Telefone é obrigatorio")]
            public string Telefone { get; set; }

            [Display(Name = "Nome da mãe")]
            [Required(ErrorMessage = "Nome da mãe é obrigatorio")]
            public string Mae { get; set; }

            [Display(Name = "Cpf da mãe")]
            [Required(ErrorMessage = "Cpf da mãe é obrigatorio")]
            public string CpfMae { get; set; }

            [Display(Name = "Nome do pai")]
            public string Pai { get; set; }

            [Display(Name = "Cpf do pai")]
            public string CpfPai { get; set; }

            [Display(Name = "Telefone do responsavel")]
            [Required(ErrorMessage = "Telefone do responsavel é obrigatorio")]
            public string TelefoneResponavel { get; set; }

            [Display(Name = "Rg")]
            [Required(ErrorMessage = "Rg é obrigatorio")]
            public string Rg { get; set; }


            [Display(Name = "Data emissão do Rg")]
            [Required(ErrorMessage = "Data emissão do Rg é obrigatorio")]
            public DateTime EmissaoRg { get; set; }


            [Display(Name = "Data de nascimento")]
            [Required(ErrorMessage = "Data de nascimento é obrigatorio")]
            public DateTime DataNascimento { get; set; }


            [Display(Name = "Tipo do sexo")]
            public char Sexo { get; set; }


        }




        public JsonResult ValidaCampos(SeducController sd)
        {
            if (!string.IsNullOrWhiteSpace(CadastrAluno.CpfPai) && CadastrAluno.Id == null)
            {

                var db = sd.Db;
                var jaExisteCpf = db.Alunos.Any(a => a.Cpf == Helper.CpfSemFormatacao(CadastrAluno.Cpf));

                if (jaExisteCpf)
                {
                    sd.ModelState.AddModelError(nameof(CadastrAluno.Cpf), "Cpf já cadastrado");
                }
            }






            return null;
        }


    }
}
