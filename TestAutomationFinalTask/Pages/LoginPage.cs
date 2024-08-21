using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFinalTask.Pages;

public class LoginPage(IWebDriver driver)
{
    private readonly IWebDriver _driver = driver;
    private readonly string _url = "https://www.saucedemo.com/";
    private readonly WebDriverWait _wait = new(driver, TimeSpan.FromSeconds(5));

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
    public void ClearInputFields()
    {
        // UsernameField.Clear() doesn`t work
        ClearFields(UsernameField, PasswordField);
    }
    public void ClearPasswordField()
    {
        ClearField(PasswordField);
    }

    private static void ClearFields(params IWebElement[] fields)
    {
        foreach (var field in fields)
        {
            ClearField(field);
        }
    }

    private static void ClearField(IWebElement field)
    {
        while (!field.GetAttribute("value").Equals(""))
        {
            field.SendKeys(Keys.Backspace);
        }
    }

    private IWebElement WaitAndFindElement(By by)
    {
        return _wait.Until(driver => driver.FindElement(by));
    }
}
