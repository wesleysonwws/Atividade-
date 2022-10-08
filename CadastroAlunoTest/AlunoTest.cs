using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunoTest
{
    public class AlunoTest
    {
        [Theory]
        [InlineData("wesleyson", "Turma 1")]
        [InlineData("pedro", "Turma 3")]
        [InlineData(" ", " ")]
        [InlineData("J ", " 2")]
        [InlineData("", "")]
        [InlineData("wesleyson", "Turma 1")]
        [InlineData("wesleyson", "Turma 1")]
        public void AtualizarDados(string nome, string turma)
        {
            // Atualizando os nome e turma
            Aluno aluno = new Aluno();
            aluno.AtualizarDados(nome, turma);
            Assert.Equal(aluno.Nome, nome);
            Assert.Equal(aluno.Turma, turma);
        }
        // Usando Theory
        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        
        public void VerificarAprovacao_MediaMaior(int n1)
        {
            Aluno aluno = new Aluno();
            aluno.Media = n1;
            var media = aluno.VerificaAprovacao();
            Assert.True(media);
        }
        [Theory]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        public void AtualizarDados_Media(double novaMedia)
        {

            Aluno aluno = new Aluno();
            aluno.AtualizaMedia(novaMedia);
            Assert.Equal(aluno.Media, novaMedia);
        }
    }
}
