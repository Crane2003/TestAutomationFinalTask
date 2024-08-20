using FluentAssertions;
using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers;
using TestAutomationFinalTask.Pages;
using TestAutomationFinalTask.Utils;

[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 4)]
namespace TestAutomationFinalTask.Tests;

[Collection("Firefox collection")]
public class LoginTestsFirefox : IDisposable
{
    private bool _disposed;

    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;
    private readonly string randomCredentials = "qwerty";
    readonly FirefoxWebDriverFixture _fixture;
    public LoginTestsFirefox(FirefoxWebDriverFixture fixture)
    {
        _fixture = fixture;
        _driver = _fixture.Driver;
        _loginPage = new LoginPage(_driver);
        // Given the user is on the login page
        _loginPage.Navigate();
        Logger.LogNavigation();
    }

    [Theory]
    [MemberData(nameof(TestData.EmptyFieldData), MemberType = typeof(TestData))]
    public void GivenEmptyFields_WhenLoginIsAttempted_ThenUsernameErrorMessageIsDisplayed(string expectedMessage)
    {
        Logger.LogParameters(string.Empty, string.Empty);

        // When the user type any credentials into "Username" and "Password" fields   
        _loginPage.EnterUsername(randomCredentials);
        _loginPage.EnterPassword(randomCredentials);
        // And clear the inputs
        _loginPage.ClearFields();
        // And hit the "Login" button
        _loginPage.ClickLogin();
        // Then the error messages appears: "Username is required".
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