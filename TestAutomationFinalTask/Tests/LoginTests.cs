using FluentAssertions;
using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers;
using TestAutomationFinalTask.Pages;
using TestAutomationFinalTask.Utils;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 4)]
namespace TestAutomationFinalTask.Tests;

[Collection("Edge collection")]
public class LoginTests : IClassFixture<EdgeWebDriverFixture>, IDisposable
{
    private bool _disposed;

    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;
    private readonly string randomCredentials = "qwerty";
    public LoginTests()
    {
        EdgeWebDriverFixture fixture = new();
        _driver = fixture.Driver;
        _loginPage = new LoginPage(_driver);
        _loginPage.Navigate();
        LogNavigation();
    }

    [Theory]
    [MemberData(nameof(TestData.EmptyFieldData), MemberType = typeof(TestData))]
    public void GivenEmptyFields_WhenLoginIsAttempted_ThenUsernameErrorMessageIsDisplayed(string expectedMessage)
    {
        LogParameters(string.Empty, string.Empty);

        _loginPage.EnterUsername(randomCredentials);
        _loginPage.EnterPassword(randomCredentials);
        _loginPage.ClearFields();
        _loginPage.ClickLogin();

        _loginPage.GetErrorMessage().Should().Contain(expectedMessage);

        LogExpectedMessage(expectedMessage);
        LogTestCompleted();
    }

    [Theory]
    [MemberData(nameof(TestData.EmptyPasswordData), MemberType = typeof(TestData))]
    public void GivenUsernameAndEmptyPassword_WhenLoginIsAttempted_ThenPasswordErrorMessageIsDisplayed(string username, string expectedMessage)
    {
        LogParameters(username, string.Empty);

        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(randomCredentials);
        _loginPage.ClearPasswordField();
        _loginPage.ClickLogin();

        _loginPage.GetErrorMessage().Should().Contain(expectedMessage);

        LogExpectedMessage(expectedMessage);
        LogTestCompleted();

    }

    [Theory]
    [MemberData(nameof(TestData.ValidLoginData), MemberType = typeof(TestData))]
    public void GivenValidCredentials_WhenLoginIsAttempted_ThenDashboardTitleIsDisplayed(string username, string password, string expectedMessage)
    {
        LogParameters(username, password);

        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(password);
        _loginPage.ClickLogin();
        _loginPage.GetDashboardTitle().Should().Be(expectedMessage);

        LogSuccessfulLogin(expectedMessage);
        LogTestCompleted();
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
                LogBrowserClosed();

                _driver.Dispose();
            }

            _disposed = true;
        }
    }

    private static void LogTestCompleted()
    {
        Logger.Log("Test passed.");
        Logger.Log("Test completed.");
    }

    private static void LogBrowserClosed()
    {
        Logger.Log("Browser closed.\n");
    }

    private static void LogNavigation()
    {
        Logger.Log("Navigated to the Login page.");
    }

    private static void LogParameters(string username, string password)
    {
        Logger.Log($"Testing login with Username: {username}, Password: {password}");
    }

    private static void LogExpectedMessage(string message)
    {
        Logger.Log($"Error message: {message}.");
    }

    private static void LogSuccessfulLogin(string message)
    {
        Logger.Log($"Dashboard title: {message}.");
    }
}