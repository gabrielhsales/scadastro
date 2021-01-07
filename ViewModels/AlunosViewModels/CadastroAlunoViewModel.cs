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
    public class CadastroAlunoViewModel
    {
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


        public JsonResult ValidaCampos(SeducController sd)
        {
            var db = sd.Db;
            var jaExisteCpf = db.Alunos.Any(a=> a.Cpf == Helper.FormatarCPF(Cpf));

            if (jaExisteCpf)
            {
                sd.ModelState.AddModelError(nameof(Cpf), "Cpf já cadastrado");
            }






            return null;
        }







    }
}
