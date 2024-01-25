using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogado()
        {
            //Arrange
            new LoginPO(driver)
                .Visitar()
                .InformarEmail("fulano@example.org")
                .InformarSenha("123")
                .EfetuarLogin();
            //.EfetuarLoginComCredenciais("fulano@example.org", "123");

            //Act
            var dashboardPO = new DashboardInteressadaPO(driver);
            dashboardPO.Menu.EfetuarLogout();

            //Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
