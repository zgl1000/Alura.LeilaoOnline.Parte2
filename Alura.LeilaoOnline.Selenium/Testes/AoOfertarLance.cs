using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //Arrange
            new LoginPO(driver).EfetuarLoginComCredenciais("fulano@example.org", "123");

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1);

            //Act
            detalhePO.OfertarLance(300);

            //Assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until(drv => detalhePO.LanceAtual == 300);

            Assert.True(iguais);
        }
    }
}
