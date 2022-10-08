using System.ComponentModel.DataAnnotations;

namespace CadastroAluno.Models
{
    public class Aluno
    {
        

        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Nome { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 5)]
        public string Turma { get; set; }
        [Required]
        [StringLength(2)]
        public double Media { get; set; }
        // Atribuir nome e turma
        public void AtualizarDados(string nome, string turma)
        {
            Nome = nome;
            Turma = turma;
        }
        // Maior que 5
        public bool VerificaAprovacao() 
            => Media > 5;

        public void AtualizaMedia(double novaMedia)
        {
            Media = novaMedia;
        }
    }
}
