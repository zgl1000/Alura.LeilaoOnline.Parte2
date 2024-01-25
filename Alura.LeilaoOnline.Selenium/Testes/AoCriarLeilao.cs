using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminEInfoValidarDeveCadastrarLeilao()
        {
            //Arrange
            var loginPO = new LoginPO(driver);

            loginPO.EfetuarLoginComCredenciais("admin@example.org", "123");

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilão de Coleção 2",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris quis viverra nisl. Pellentesque scelerisque quam sed orci tempus lacinia. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Praesent aliquet faucibus nisi, et accumsan enim egestas vel. Quisque accumsan, nisl sed scelerisque commodo, quam diam viverra neque, non rhoncus enim odio semper magna. Aliquam a ligula sollicitudin, porta nibh at.",
                "Item de Colecionador",
                4000,
                "C:\\Users\\guita\\Pictures\\images.png",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40));

            //Act
            novoLeilaoPO.SubmeteFormulario();

            //Assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
