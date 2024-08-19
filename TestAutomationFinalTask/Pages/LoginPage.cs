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

    private IWebElement UsernameField => WaitAndFindElement(By.CssSelector("#user-name"));
    private IWebElement PasswordField => WaitAndFindElement(By.CssSelector("#password"));
    private IWebElement LoginButton => WaitAndFindElement(By.CssSelector("#login-button"));
    private IWebElement ErrorMessage => WaitAndFindElement(By.CssSelector(".error-message-container.error"));

    public void Navigate() => _driver.Navigate().GoToUrl(_url);
    public void EnterUsername(string username) => UsernameField.SendKeys(username);
    public void EnterPassword(string password) => PasswordField.SendKeys(password);
    public void ClickLogin() => LoginButton.Click();
    public string GetErrorMessage() => ErrorMessage.Text;
    public string GetDashboardTitle()
    {
        IWebElement DashboardTitle = WaitAndFindElement(By.CssSelector(".app_logo"));
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

    private IWebElement WaitAndFindElement(By by)
    {
        return _wait.Until(driver => driver.FindElement(by));
    }
}
