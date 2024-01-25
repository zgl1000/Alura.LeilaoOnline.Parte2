using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaDashboard()
        {
            //Arrange
            var loginPO = new LoginPO(driver);

            //Act
            loginPO.EfetuarLoginComCredenciais("fulano@example.org", "123");

            //Assert
            Assert.Contains("Dashboard", driver.PageSource);
        }

        [Fact]
        public void DadoCredenciaisInvalidasDeveIrContinuarLogin()
        {
            //Arrange
            var loginPO = new LoginPO(driver);

            //Act
            loginPO.EfetuarLoginComCredenciais("fulano@example.org", "456");

            //Assert
            Assert.Contains("Login", driver.PageSource);
        }
    }
}
