using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdmDeveMostrarTresCategorias()
        {
            //Arrange
            new LoginPO(driver).EfetuarLoginComCredenciais("admin@example.org", "123");

            var novoLeilaoPO = new NovoLeilaoPO(driver);

            //Act
            novoLeilaoPO.Visitar();

            //Assert
            Assert.Equal(3, novoLeilaoPO.Categorias.Count());
        }
    }
}
