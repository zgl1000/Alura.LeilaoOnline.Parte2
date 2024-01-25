using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver driver;

        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;
        private By bySelectCategorias;

        public FiltroLeiloesPO(IWebDriver driver)
        {
            this.driver = driver;

            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
            bySelectCategorias = By.ClassName("select-wrapper");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);

            select.DeselectAll();

            select.SelectByText(categorias);

            driver.FindElement(byInputTermo).SendKeys(termo);

            if (emAndamento)
                driver.FindElement(byInputAndamento).Click();

            driver.FindElement(byBotaoPesquisar).Click();
        }
    }
}
