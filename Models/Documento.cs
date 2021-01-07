using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace scadastro.Models
{
    [Table("CI02_DOCUMENTOS")]
    public class Documento
    {

        [Key]
        [Column("CI02_ID_DOCUMENTOS")]
        public int Id { get; set; }

        [Column("CI02_ID_ALUNO")]
        public int AlunoId { get; set; }

        [Column("CI02_NM_MAE")]
        public string Mae { get; set; }

        [Column("CI02_NU_CPF_MAE")]
        public string CpfMae { get; set; }

        [Column("CI02_NM_PAI")]
        public string Pai { get; set; }

        [Column("CI02_NU_CPF_PAI")]
        public string CpfPai { get; set; }

        [Column("CI02_NU_TELEFONE_RESPONSAVEL")]
        public long TelefoneResponavel { get; set; }

        [Column("CI02_NU_RG_ALUNO")]
        public string Rg { get; set; }


        [Column("CI02_DT_EMISSAO_RG_ALUNO")]
        public DateTime EmissaoRg { get; set; }


        [Column("CI02_DT_NASCIMENTO_ALUNO")]
        public DateTime DataNascimento { get; set; }


        [Column("CI02_TP_SEXO_ALUNO")]
        public char Sexo { get; set; }


        [Column("CI02_DH_CADASTRO")]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;


        public Aluno Aluno { get; set; }

    }
}
