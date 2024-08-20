using FluentAssertions;
using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers;
using TestAutomationFinalTask.Pages;
using TestAutomationFinalTask.Utils;

namespace TestAutomationFinalTask.Tests;

[Collection("Chrome collection")]
public class LoginTestsChrome : IDisposable
{
    private bool _disposed;

    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;
    private readonly string randomCredentials = "qwerty";
    readonly ChromeWebDriverFixture _fixture;
    public LoginTestsChrome(ChromeWebDriverFixture fixture)
    {
        _fixture = fixture;
        _driver = _fixture.Driver;
        _loginPage = new LoginPage(_driver);
        // Given the user is on the login page
        _loginPage.Navigate();
        Logger.LogNavigation();
    }

    [Theory]
    [MemberData(nameof(TestData.EmptyPasswordData), MemberType = typeof(TestData))]
    public void GivenUsernameAndEmptyPassword_WhenLoginIsAttempted_ThenPasswordErrorMessageIsDisplayed(string username, string expectedMessage)
    {
        Logger.LogParameters(username, string.Empty);
        // When the user type any credentials into "Username" and "Password" fields  
        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(randomCredentials);
        // And clear the "Password" input
        _loginPage.ClearPasswordField();
        // And hit the "Login" button
        _loginPage.ClickLogin();
        // Then the error messages appears: "Password is required"
        _loginPage.GetErrorMessage().Should().Contain(expectedMessage);

        Logger.LogExpectedMessage(expectedMessage);
        Logger.LogTestCompleted();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _driver.Quit();
                Logger.LogBrowserClosed();

                _driver.Dispose();
            }

            _disposed = true;
        }
    }
}
