using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Zialinski_task_NUnit.Driver
{
    public class DriverInitQuit
    {
        private IWebDriver Driver { get; set; }

        public IWebDriver InitDriver(string driverName)
        {
            switch (driverName)
            {
                case "Chrome":
                    Driver = new ChromeDriver();
                    break;
                case "Firefox":
                    Driver = new FirefoxDriver();
                    break;
            }
            return Driver;
        }

        public void QuitDriver(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
