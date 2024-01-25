using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; set; }

        //Setup
        public TestFixture() 
        {
            Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);

            Driver.Manage().Window.Size = new System.Drawing.Size(1900, 1020);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //TearDown
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
