

using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        private IWebDriver driver;

        private By byInputTitulo;
        private By byInputDescricao;
        private By byInputCategoria;
        private By byInputValorInicial;
        private By byInputImagem;
        private By byInputInicioPregao;
        private By byInputTerminoPregao;
        private By bySpanCategorias;
        private By byBotaoSalvar;
        private By bySelectCategoria;

        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byInputCategoria = By.ClassName("select-dropdown");
            bySpanCategorias = By.TagName("span");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byBotaoSalvar = By.TagName("button");
            bySelectCategoria = By.Id("Categoria");
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(
            string titulo,
            string descricao,
            string categoria,
            double valor,
            string imagem,
            DateTime inicio,
            DateTime termino)
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo);
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            driver.FindElement(byInputCategoria).Click();
            var categorias = driver.FindElements(bySpanCategorias);
            foreach (var span in categorias)
            {
                if (span.Text == categoria) span.Click();
            }
            driver.FindElement(byInputValorInicial).SendKeys(valor.ToString());
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy"));
            driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString("dd/MM/yyyy"));
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoSalvar).Click();
        }

        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(bySelectCategoria));

                return elementoCategoria.Options.Where(o => o.Enabled).Select(p => p.Text);
            }
        }
    }
}
