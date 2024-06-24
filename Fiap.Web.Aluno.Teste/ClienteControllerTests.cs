using Fiap.Web.Aluno.Models;
using Fiap.Web.Aluno.Controllers;
using FIap.Web.Aluno.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Web.Aluno.Teste
{
    public class ClienteControllerTests
    {
        // Mock do contexto do banco de dados
        private readonly Mock<DataBaseContext> _mockContext;

        // Controlador que será testado
        private readonly ClienteController _clienteController;

        // Mock do DbSet para ClienteModel
        private readonly DbSet<ClienteModel> _mockSet;

        public ClienteControllerTests()
        {
            // Inicializando o mock de contexto
            _mockContext = new Mock<DataBaseContext>();

            // Cria e configura o mock DbSet
            _mockSet = MockDbSet();

            // Configura o contexto mock para retornar o DbSet mock quando a propriedade Clientes for acessada
            _mockContext.Setup(m => m.Cliente).Returns(_mockSet);

            // Inicializa o controlador com o contexto mock
            _clienteController = new ClienteController(_mockContext.Object);
        }

        // Método para criar e configurar um DbSet mock para ClienteModel
        private DbSet<ClienteModel> MockDbSet()
        {
            // Lista de cliente para simular dados no banco de dados
            var data = new List<ClienteModel>
            {
                new ClienteModel { ClienteId = 1, Nome = "Cliente 1" },
                new ClienteModel { ClienteId = 2, Nome = "Cliente 2" },
            }.AsQueryable();

            // Cria o mock DbSet
            var mockSet = new Mock<DbSet<ClienteModel>>();

            // Configurar comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<ClienteModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ClienteModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ClienteModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ClienteModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Index_ReturnsViewWithClients()
        {
            // Act
            // Invoca o método de controlador para testar seu comportamento
            var result = _clienteController.Index();

            // Assert
            // Verifica se o resultado obtido é do ViewResult
            var viewResult = Assert.IsType<ViewResult>(result);

            // Verifica se o model retornado pelo ViewResult pode ser atribuido a uma coleção de ClienteModel
            var model = Assert.IsAssignableFrom<IEnumerable<ClienteModel>>(viewResult.Model);

            // Verifica se o número do modelo do cliente é igual a 2
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void Index_ReturnsViewWithoutClients()
        {
            // Arrange
            // Limpa o mock DbSet para simular uma condição onde não existem clientes no banco de dados
            _mockSet.RemoveRange(_mockSet.ToList());

            // Configura o contexto mock para retornar o DbSet vazio quando a propriedade Clientes for acessada
            _mockContext.Setup(m => m.Cliente).Returns(_mockSet);

            // Act
            // Chama o método Index do controlador para testar o comportamento com uma lista vazia
            var result = _clienteController.Index();

            // Assert
            // Verifica se o resultado obtido é do tipo ViewResult
            var viewResult = Assert.IsType<ViewResult>(result);

            // Confirma que o modelo associado à ViewResult é uma coleção vazia de ClienteModel
            var model = Assert.IsAssignableFrom<IEnumerable<ClienteModel>>(viewResult.Model);

            // Checa se o modelo está vazio, valisdando o cenário de nenhum cliente presente
            Assert.Empty(model);
        }

        [Fact]
        public void Index_ThrowsException_WhenDatabaseFails()
        {
            // Arrange
            // Configura o contexto mock para lançar uma exceção quando a propriedade Clientes for acessada, simulando uma falha no banco de dados
            _mockContext.Setup(m => m.Cliente).Throws(new System.Exception("Database Error"));

            // Act &amp; Assert
            // Verifica se a chamada ao método Index lança uma exceção, conforme esperado durante a falha do banco de dados
            Assert.Throws<System.Exception>(() => _clienteController.Index());
        }
    }
}
