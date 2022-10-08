using CadastroAluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Contrato
namespace CadastroAluno.Contracts
{ 
    public interface IAlunoRepository
    {
        // Atribuir os ID certo
        List<Aluno> Index();
        Aluno Details(int? id);
        Aluno Create(Aluno cliente);
        Aluno Edit(int? id, Aluno cliente);
        int Delete(int id);
    }
}