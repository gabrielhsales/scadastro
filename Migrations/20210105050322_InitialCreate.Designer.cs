﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using scadastro.Db;

namespace scadastro.Migrations
{
    [DbContext(typeof(ScadastroDbContext))]
    [Migration("20210105050322_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("scadastro.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CI01_ID_ALUNO")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cep")
                        .HasColumnName("CI01_NU_CEP")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cidade")
                        .HasColumnName("CI01_NM_CIDADE")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cpf")
                        .HasColumnName("CI01_NU_ALUNO")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnName("CI01_NM_EMAIL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Estado")
                        .HasColumnName("CI01_NU_ESTADO")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logadouro")
                        .HasColumnName("CI01_NM_LOGADOURO")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nacionalidade")
                        .HasColumnName("CI01_NM_NACIONALIDADE")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnName("CI01_NM_ALUNO")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnName("CI01_NU_TELEFONE")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CI01_ALUNO");
                });

            modelBuilder.Entity("scadastro.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CI02_ID_DOCUMENTOS")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlunoId")
                        .HasColumnName("CI02_ID_ALUNO")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CpfMae")
                        .HasColumnName("CI02_NU_CPF_MAE")
                        .HasColumnType("TEXT");

                    b.Property<string>("CpfPai")
                        .HasColumnName("CI02_NU_CPF_PAI")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnName("CI02_DH_CADASTRO")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("CI02_DT_NASCIMENTO_ALUNO")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EmissaoRg")
                        .HasColumnName("CI02_DT_EMISSAO_RG_ALUNO")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mae")
                        .HasColumnName("CI02_NM_MAE")
                        .HasColumnType("TEXT");

                    b.Property<string>("Pai")
                        .HasColumnName("CI02_NM_PAI")
                        .HasColumnType("TEXT");

                    b.Property<string>("Rg")
                        .HasColumnName("CI02_NU_RG_ALUNO")
                        .HasColumnType("TEXT");

                    b.Property<char>("Sexo")
                        .HasColumnName("CI02_TP_SEXO_ALUNO")
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefoneResponavel")
                        .HasColumnName("CI02_NU_TELEFONE_RESPONSAVEL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId")
                        .IsUnique();

                    b.ToTable("CI02_DOCUMENTOS");
                });

            modelBuilder.Entity("scadastro.Models.Documento", b =>
                {
                    b.HasOne("scadastro.Models.Aluno", "Aluno")
                        .WithOne("Documento")
                        .HasForeignKey("scadastro.Models.Documento", "AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
