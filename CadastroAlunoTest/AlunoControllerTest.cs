using CadastroAluno.Contracts;
using CadastroAluno.Controllers;
using CadastroAluno.Models;
using CadastroAluno.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CadastroAlunoTest
{
    public class AlunoControllerTest
    {
        // Ussando Moq
        Mock<IAlunoRepository> _repository;
        Aluno alunoValido;
        Aluno alunoValido1;

        public AlunoControllerTest()
        {
            _repository = new Mock<IAlunoRepository>();
            alunoValido = new Aluno()
            {
                Id = 1,
                Nome = "Nome",
                Media = 8,
                Turma = "Turma 1"
            };
            alunoValido1 = new Aluno()
            {
                Id = -2,
                Nome = "",
                Media = 11,
                Turma = ""
            };
        }

        [Fact]
        public void ChamaAlunos_ExecutaAcao_RetornaOkAction()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            // Action
            var result = controller.Index();
            // Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact(DisplayName = "Index  Chama Repo 1 Vez")]
        public void ModelStateValida_ChamaRepositorioUmaVez()
        {
            //Assert
            AlunosController controller = new AlunosController(_repository.Object);
            controller.Index();
            

            _repository.Verify(repo => repo.Index(), Times.Once);
        }
        [Fact(DisplayName = "ALuno Inexistente NotFound")]
        public void AlunoInexistente_RetornaNotFound()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            //Act
            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);
            //Assert
            var consulta = controller.Details(2);

            Assert.IsType<NotFoundResult>(consulta);
        }
        [Fact(DisplayName = "Aluno Inexistente BadRequest")]
        public void AlunoInexistente_RetornBadRequest()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            //Act
            var consulta = controller.Details(-1);
            //Assert
            Assert.IsType<BadRequestResult>(consulta);
        }
        [Fact(DisplayName = "Details Chama Repo 1 Vez")]
        public void DetailsAluno_ModelStateValida_ChamaRepositorioUmaVez()
        {
            // Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            //Act
            _repository.Setup(repo => repo.Details(1));
            controller.Create(1);
            //Assert
            _repository.Verify(repo => repo.Details(1), Times.Once);
        }
        [Fact(DisplayName = "Details Return ViewResult")]
        public void ExecutaAcao_RetornaViewResul()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            //Act
            _repository.Setup(repo => repo.Details(1)).Returns(alunoValido);
            var result = controller.Create(1);
            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact(DisplayName = "Create Return ViewResult")]
        public void ExecutaAcao_RetornaViewResultSempre()
        {
            //Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            //Action
            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            // Assert
            var result = controller.Create(alunoValido);
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact(DisplayName = "[HttpPost] Create() ou RedirectToAction ")]
        public void ValidaDados_RetornaResposta()
        {   ////Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            //Action
            _repository.Setup(repo => repo.Create(alunoValido)).Returns(alunoValido);
            var result = controller.Create(alunoValido);
            // Assert
            _repository.Verify(repo => repo.Create(alunoValido), Times.Once);
            Assert.IsType<RedirectToActionResult>(result);
        }
        [Fact(DisplayName = " RedirectToAction ")]
        public void ValidaDados_RetornaResposta_NEgativo()
        {   ////Arrange
            AlunosController controller = new AlunosController(_repository.Object);
            controller.ModelState.AddModelError("", "");
            //Action

            var result = controller.Create(alunoValido1);
            // Assert
            _repository.Verify(repo => repo.Create(alunoValido1), Times.Never);
            Assert.IsType<ViewResult>(result);
        }


    }

}