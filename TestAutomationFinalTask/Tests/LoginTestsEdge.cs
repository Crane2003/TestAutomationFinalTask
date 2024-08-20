using FluentAssertions;
using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers;
using TestAutomationFinalTask.Pages;
using TestAutomationFinalTask.Utils;

namespace TestAutomationFinalTask.Tests;

[Collection("Edge collection")]
public class LoginTestsEdge : IDisposable
{
    private bool _disposed;

    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;
    readonly EdgeWebDriverFixture _fixture;
    public LoginTestsEdge(EdgeWebDriverFixture fixture)
    {
        _fixture = fixture;
        _driver = _fixture.Driver;
        _loginPage = new LoginPage(_driver);
        // Given the user is on the login page
        _loginPage.Navigate();
        Logger.LogNavigation();
    }

    [Theory]
    [MemberData(nameof(TestData.ValidLoginData), MemberType = typeof(TestData))]
    public void GivenValidCredentials_WhenLoginIsAttempted_ThenDashboardTitleIsDisplayed(string username, string password, string expectedMessage)
    {
        Logger.LogParameters(username, password);
        // When the user type credentials in username which are under Accepted username are sections
        // And enter password as "secret sauce"
        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(password);
        // And hit the "Login" button
        _loginPage.ClickLogin();
        // Then title “Swag Labs” appears in the dashboard
        _loginPage.GetDashboardTitle().Should().Be(expectedMessage);

        Logger.LogSuccessfulLogin(expectedMessage);
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