using Microsoft.EntityFrameworkCore;
using scadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace scadastro.Db
{
    public class ScadastroDbContext : DbContext
    {
        public ScadastroDbContext(DbContextOptions<ScadastroDbContext> options) : base(options) { }


        public DbSet<Aluno> Alunos { get; set; }

        public DbSet<Documento> Documentos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Documento)
                .WithOne(b => b.Aluno)
                .HasForeignKey<Documento>(b => b.AlunoId);
        }

    }
}
