using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace scadastro.Models
{
    [Table("CI01_ALUNO")]
    public class Aluno
    {
        [Key]
        [Column("CI01_ID_ALUNO")]
        public int Id { get; set; }

        [Column("CI01_NM_ALUNO")]
        public string Nome { get; set; }

        [Column("CI01_NU_ALUNO")]
        public string Cpf { get; set; }

        [Column("CI01_NM_NACIONALIDADE")]
        public string Nacionalidade { get; set; }

        [Column("CI01_NU_CEP")]
        public string Cep { get; set; }

        [Column("CI01_NU_ESTADO")]
        public string Estado { get; set; }

        [Column("CI01_NM_CIDADE")]
        public string Cidade { get; set; }

        [Column("CI01_NM_LOGADOURO")]
        public string Logadouro { get; set; }

        [Column("CI01_NM_EMAIL")]
        public string Email { get; set; }

        [Column("CI01_NU_TELEFONE")]
        public string Telefone { get; set; }

        public Documento Documento { get; set; }



    }
}
