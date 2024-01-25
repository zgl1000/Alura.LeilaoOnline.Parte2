﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    internal class DetalheLeilaoPO
    {
        private IWebDriver driver;

        private By byInputValor;
        private By byBotaoOfertar;
        private By byLanceAtual;


        public DetalheLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;

            byInputValor = By.Id("Valor");
            byBotaoOfertar = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }

        public double LanceAtual 
        { 
            get 
            {
                var valorTexto = driver.FindElement(byLanceAtual).Text;

                return double.Parse(valorTexto, System.Globalization.NumberStyles.Currency);
            }
        }

        public void Visitar(int idLeilao)
        {
            driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}");
        }

        internal void OfertarLance(double valor)
        {
            driver.FindElement(byInputValor).Clear();
            driver.FindElement(byInputValor).SendKeys(valor.ToString());

            driver.FindElement(byBotaoOfertar).Click();
        }
    }
}
