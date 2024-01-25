
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //Arrange - dado chrome aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "José Guilherme",
                email: "joseshirotori@email.com",
                senha: "123",
                confirmaSenha: "123");

            //Act - efetuo o registro
            registroPO.SubmeteFormulario();

            //Assert - devo ser direcionado para um página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
        }

        [Theory]
        [InlineData("", "jose@email.com", "123", "123")]
        [InlineData("João Silva", "jose", "123", "123")]
        [InlineData("João Silva", "jose@email.com", "123", "456")]
        [InlineData("João Silva", "jose@email.com", "123", "")]
        public void DadoInfoInvalidasDeveContinuarNaHome(string nome, string email, string senha, string confirmaSenha)
        {
            //Arrange - dado chrome aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: nome,
                email: email,
                senha: senha,
                confirmaSenha: confirmaSenha);

            //Act - efetuo o registro
            registroPO.SubmeteFormulario();

            //Assert - devo ser direcionado para um página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //Act
            registroPO.SubmeteFormulario();

            //Assert
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //Arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "daniel",
                senha: "",
                confirmaSenha: "");

            //Act
            registroPO.SubmeteFormulario();

            //Assert
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}
