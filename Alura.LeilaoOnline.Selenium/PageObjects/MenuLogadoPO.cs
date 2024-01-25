using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver driver;

        private By byLogoutLink;
        private By byMeuPerfilLink;

        public MenuLogadoPO(IWebDriver driver)
        {
            this.driver = driver;
            
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);

            var acaoLogout = new Actions(driver);
            acaoLogout.MoveToElement(linkMeuPerfil);
            acaoLogout.MoveToElement(linkLogout);
            acaoLogout.Click();
            acaoLogout.Build();

            acaoLogout.Perform();
        }
    }
}
