using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace backend_lab.Tests
{
    [TestClass]
    public class CountryUITests
    {
        private IWebDriver driver;
        private string baseUrl = "http://localhost:8080/";

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestMethod]
        public void CrearPais_Y_VerificarConfirmacion_Test()
        {
            driver.Navigate().GoToUrl(baseUrl + "#/");

            IWebElement botonAgregar = driver.FindElement(By.XPath("//button[contains(text(), 'Agregar país')]"));
            botonAgregar.Click();

            IWebElement inputNombre = driver.FindElement(By.Id("name"));
            IWebElement inputContinente = driver.FindElement(By.Id("continent"));
            IWebElement inputIdioma = driver.FindElement(By.Id("language"));

            inputNombre.SendKeys("Japón");
            inputContinente.SendKeys("Asia");
            inputIdioma.SendKeys("Japonés");

            IWebElement botonGuardar = driver.FindElement(By.XPath("//button[contains(text(), 'Guardar')]"));
            botonGuardar.Click();

            string urlActual = driver.Url;
            Assert.IsTrue(urlActual.Contains("#/"), "La aplicación no redirigió a la lista de países tras guardar.");

            IWebElement filaNuevoPais = driver.FindElement(By.XPath("//td[contains(text(), 'Japón')]"));
            Assert.IsNotNull(filaNuevoPais, "El país 'Japón' no se encontró en la tabla de la lista después de crearlo.");
        }

        [TestCleanup]
        public void TeardownTest()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}