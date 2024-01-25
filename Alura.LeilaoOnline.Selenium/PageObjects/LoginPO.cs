using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;

        private By byInputLogin;
        private By byInputSenha;
        private By byInputBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;

            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byInputBotaoLogin = By.Id("btnLogin");
        }

        public LoginPO Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");

            return this;
        }

        private LoginPO PreencherFormulario(string login, string senha)
        {
            return InformarEmail(login).InformarSenha(senha);
        }

        private LoginPO SubmeteFormulario()
        {
            driver.FindElement(byInputBotaoLogin).Click();

            return this;
        }

        public void EfetuarLoginComCredenciais(string login, string senha)
        {
            Visitar()
                .PreencherFormulario(login, senha)
                .SubmeteFormulario();
        }

        public LoginPO InformarEmail(string login)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }

        public LoginPO InformarSenha(string senha)
        {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO EfetuarLogin()
        {
            SubmeteFormulario();
            return this;
        }
    }
}
