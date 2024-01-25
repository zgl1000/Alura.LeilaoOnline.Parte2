using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public class SelectMaterialize
    {
        private IWebDriver driver;
        private IWebElement selectWrapper;
        private IEnumerable<IWebElement> opcoes;

        public SelectMaterialize(IWebDriver driver, By locatorSelectWrapper)
        {
            this.driver = driver;
            selectWrapper = driver.FindElement(locatorSelectWrapper);
            opcoes = selectWrapper.FindElements(By.CssSelector("li>span"));
        }

        public IEnumerable<IWebElement> Options => opcoes;

        private void OpenWrapper()
        {
            selectWrapper.Click();
        }

        private void LoseFocus()
        {
            selectWrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);
        }

        public void DeselectAll()
        {
            OpenWrapper();

            opcoes.ToList().ForEach(p =>
            {
                p.Click();
            });

            LoseFocus();
        }

        public void SelectByText(List<string> options)
        {
            OpenWrapper();

            options.ForEach(option =>
            {
                opcoes.Where(p => p.Text.Contains(option))
                  .ToList()
                  .ForEach(p =>
                  {
                      p.Click();
                  });
            });

            LoseFocus();
        }
    }
}
