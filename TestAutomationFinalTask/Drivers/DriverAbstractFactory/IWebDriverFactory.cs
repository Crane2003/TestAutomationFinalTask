using OpenQA.Selenium;

namespace TestAutomationFinalTask.Drivers.DriverAbstractFactory;

public interface IWebDriverFactory
{
    IWebDriver CreateDriver();
}
