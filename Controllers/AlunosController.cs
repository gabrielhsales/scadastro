using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scadastro.Db;
using scadastro.Models;
using scadastro.Utils;
using scadastro.ViewModels.AlunosViewModels;

namespace scadastro.Controllers
{
    //[Authorize]
    public class AlunosController : SeducController
    {
        public AlunosController(ScadastroDbContext context) : base(context)
        {
        }







        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult Listagem()
        {
            var alunos = db.Alunos.Select(a => new ListagemAlunosViewModel.Listagem
            {
                Id = a.Id,
                Nome = a.Nome,
                Cpf = Helper.FormatarCPF(a.Cpf),
                //Nacionalidade = a.Nacionalidade,
                //Cep = Helper.FormatarCEP(a.Cep),
                //Estado = a.Estado,
                //Cidade = a.Cidade,
                //Logadouro = a.Logadouro,
                Email = a.Email,
                Telefone = Helper.FormatarTelefone(a.Telefone),
                //CpfMae = Helper.FormatarCPF(a.Documento.CpfMae),
                //CpfPai = Helper.FormatarCPF(a.Documento.CpfPai),
                DataNascimento = a.Documento.DataNascimento.ToShortDateString(),
                //EmissaoRg = a.Documento.EmissaoRg.ToShortDateString(),
                Mae = a.Documento.Mae,
                //Pai = a.Documento.Pai,
                //Rg = a.Documento.Rg,
                //Sexo = a.Documento.Sexo,
                TelefoneResponavel = Helper.FormatarTelefone(a.Documento.TelefoneResponavel.ToString())
            }).ToList();

            var model = new ListagemAlunosViewModel();

            model.ListAluno = alunos;

            return View(model);
        }

        [HttpPut]
        [Route("[controller]/Cadastro")]
        public IActionResult Cadastro(ListagemAlunosViewModel model)
        {

            model.ValidaCampos(this);


            if (ModelState.IsValid)
            {
                if (model.CadastrAluno.Id != null)
                {
                    //return RedirectToAction("EditarCadastro", new { id = model.CadastrAluno.Id, model = model.CadastrAluno }, );
                    return EditarCadastro(model.CadastrAluno.Id.Value, model);
                }
                try
                {
                    using (var transaciont = db.Database.BeginTransaction())
                    {

                        Aluno aluno = new Aluno()
                        {
                            Nome = model.CadastrAluno.Nome.Trim(),
                            Cep = Helper.CepSemFormatacao(model.CadastrAluno.Cep).Trim(),
                            Cidade = model.CadastrAluno.Cidade,
                            Estado = model.CadastrAluno.Estado,
                            Cpf = Helper.CpfSemFormatacao(model.CadastrAluno.Cpf).Trim(),
                            Email = model.CadastrAluno.Email,
                            Logadouro = model.CadastrAluno.Logadouro.Trim(),
                            Nacionalidade = model.CadastrAluno.Nacionalidade,
                            Telefone = Helper.TelefoneSemFormatacao(model.CadastrAluno.Telefone),

                        };

                        db.Alunos.Add(aluno);
                        db.SaveChanges();


                        Documento documento = new Documento()
                        {
                            Aluno = aluno,
                            AlunoId = aluno.Id,
                            CpfMae = Helper.CpfSemFormatacao(model.CadastrAluno.CpfMae),
                            CpfPai = Helper.CpfSemFormatacao(model.CadastrAluno.CpfPai),
                            Pai = model.CadastrAluno.Pai,
                            DataNascimento = model.CadastrAluno.DataNascimento,
                            EmissaoRg = model.CadastrAluno.EmissaoRg,
                            Mae = model.CadastrAluno.Mae,
                            Rg = model.CadastrAluno.Rg,
                            Sexo = model.CadastrAluno.Sexo,
                            TelefoneResponavel = long.Parse(Helper.TelefoneSemFormatacao(model.CadastrAluno.TelefoneResponavel)),
                        };

                        db.Documentos.Add(documento);
                        db.SaveChanges();

                        transaciont.Commit();



                        return Json(new { sucesso = true, Msg = "Cadastrado com sucesso" });
                    }

                }
                catch (Exception e)
                {

                    return Json(new { sucesso = false, Msg = "Erro de processamento " + e.Message });

                }


            }
            else
            {
                model.ListAluno = db.Alunos.Select(a => new ListagemAlunosViewModel.Listagem
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    Cpf = Helper.FormatarCPF(a.Cpf),
                    Email = a.Email,
                    Telefone = Helper.FormatarTelefone(a.Telefone),
                    DataNascimento = a.Documento.DataNascimento.ToShortDateString(),
                    Mae = a.Documento.Mae,
                    TelefoneResponavel = Helper.FormatarTelefone(a.Documento.TelefoneResponavel.ToString())
                }).ToList();



                return View("~/Views/Alunos/Listagem.cshtml", model);
            }




 
        }



        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                var aluno = db.Alunos.FirstOrDefault(a => a.Id == id);


                if (aluno == null)
                    return Json(new { sucesso = false, msg = "não encontrado aluno" });


                db.Alunos.Remove(aluno);
                db.SaveChanges();

                return Json(new { sucesso = true, msg = "deletado com sucesso" });
            }
            catch (Exception e)
            {

                return StatusCode(500, new { sucesso = false, msg = "erro ao processar " + e.Message });
            }

        }



        [HttpGet]
        [Route("[controller]/[action]/{id}")]
        public IActionResult Editar(int id)
        {
            try
            {
                var aluno = db.Alunos
                    .Where(a => a.Id == id).
                    Include(a => a.Documento)
                    .Select(a => new
                    {
                        a.Id,
                        a.Nome,
                        Cep = Helper.FormatarCEP(a.Cep),
                        a.Cidade,
                        a.Estado,
                        Cpf = Helper.FormatarCPF(a.Cpf),
                        a.Email,
                        a.Logadouro,
                        a.Nacionalidade,
                        Telefone = Helper.FormatarTelefone(a.Telefone),
                        CpfMae = Helper.FormatarCPF(a.Documento.CpfMae),
                        CpfPai = Helper.FormatarCPF(a.Documento.CpfPai),
                        a.Documento.Pai,
                        DataNascimento = Helper.FormatarDataInput(a.Documento.DataNascimento.ToShortDateString()),
                        EmissaoRg = Helper.FormatarDataInput(a.Documento.EmissaoRg.ToShortDateString()),
                        a.Documento.Mae,
                        a.Documento.Rg,
                        a.Documento.Sexo,
                        TelefoneResponavel = Helper.FormatarTelefone(a.Documento.TelefoneResponavel.ToString()),
                    }).FirstOrDefault();


                if (aluno == null)
                    return Json(new { sucesso = false, msg = "não encontrado aluno" });


                return Json(new { sucesso = true, msg = "carregado com sucesso", resultado = aluno });
            }
            catch (Exception e)
            {

                return Json(new { sucesso = false, msg = "erro ao processar " + e.Message });
            }

        }

        public JsonResult EditarCadastro(int id, ListagemAlunosViewModel model)
        {
            try
            {
                var aluno = db.Alunos.Where(a => a.Id == id).Include(a => a.Documento).FirstOrDefault();


                if (aluno == null)
                    return Json(new { sucesso = false, msg = "não encontrado aluno" });

                using (var transaciotn = db.Database.BeginTransaction())
                {

                    aluno.Nome = model.CadastrAluno.Nome.Trim();
                    aluno.Cep = Helper.CepSemFormatacao(model.CadastrAluno.Cep).Trim();
                    aluno.Cidade = model.CadastrAluno.Cidade;
                    aluno.Estado = model.CadastrAluno.Estado;
                    aluno.Cpf = Helper.CpfSemFormatacao(model.CadastrAluno.Cpf).Trim();
                    aluno.Email = model.CadastrAluno.Email;
                    aluno.Logadouro = model.CadastrAluno.Logadouro.Trim();
                    aluno.Nacionalidade = model.CadastrAluno.Nacionalidade;
                    aluno.Telefone = Helper.TelefoneSemFormatacao(model.CadastrAluno.Telefone);


                    aluno.Documento.CpfMae = Helper.CpfSemFormatacao(model.CadastrAluno.CpfMae);
                    aluno.Documento.CpfPai = Helper.CpfSemFormatacao(model.CadastrAluno.CpfPai);
                    aluno.Documento.Pai = model.CadastrAluno.Pai;
                    aluno.Documento.DataNascimento = model.CadastrAluno.DataNascimento;
                    aluno.Documento.EmissaoRg = model.CadastrAluno.EmissaoRg;
                    aluno.Documento.Mae = model.CadastrAluno.Mae;
                    aluno.Documento.Rg = model.CadastrAluno.Rg;
                    aluno.Documento.Sexo = model.CadastrAluno.Sexo;
                    aluno.Documento.TelefoneResponavel = long.Parse(Helper.TelefoneSemFormatacao(model.CadastrAluno.TelefoneResponavel));

                    db.SaveChanges();
                    transaciotn.Commit();

                }


                return Json(new { sucesso = true, msg = "atualizado com sucesso" });
            }
            catch (Exception e)
            {

                return Json(new { sucesso = false, msg = "erro ao processar " + e.Message });
            }

        }






    }
}
