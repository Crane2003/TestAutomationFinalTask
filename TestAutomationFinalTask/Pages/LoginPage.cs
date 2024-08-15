using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinalTask.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly string _url = "https://www.saucedemo.com/";
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    private IWebElement UsernameField => _driver.FindElement(By.CssSelector("#user-name"));
    private IWebElement PasswordField => _driver.FindElement(By.CssSelector("#password"));
    private IWebElement LoginButton => _driver.FindElement(By.CssSelector("#login-button"));
    private IWebElement ErrorMessage => _driver.FindElement(By.CssSelector(".error-message-container.error"));

    public void Navigate() => _driver.Navigate().GoToUrl(_url);
    public void EnterUsername(string username) => UsernameField.SendKeys(username);
    public void EnterPassword(string password) => PasswordField.SendKeys(password);
    public void ClickLogin() => LoginButton.Click();
    public string GetErrorMessage() => ErrorMessage.Text;
    public string GetDashboardTitle()
    {
        IWebElement DashboardTitle = _driver.FindElement(By.CssSelector(".app_logo"));
        return DashboardTitle.Text;
    }
    public void ClearFields()
    {
        // UsernameField.Clear() doesn`t work
        while (!UsernameField.GetAttribute("value").Equals(""))
        {
            UsernameField.SendKeys(Keys.Backspace);
        }
        ClearPasswordField();
    }
    public void ClearPasswordField()
    {
        while (!PasswordField.GetAttribute("value").Equals(""))
        {
            PasswordField.SendKeys(Keys.Backspace);
        }
    }
}
