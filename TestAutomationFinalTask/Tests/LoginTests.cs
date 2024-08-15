using FluentAssertions;
using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers;
using TestAutomationFinalTask.Pages;
using TestAutomationFinalTask.Utils;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerClass, MaxParallelThreads = 4)]
namespace TestAutomationFinalTask.Tests;
public class LoginTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly LoginPage _loginPage;
    private readonly string randomCredentials = "qwerty";
    public LoginTests()
    {
        _driver = WebDriverManager.CreateDriver("edge");
        _loginPage = new LoginPage(_driver);
        _loginPage.Navigate();
        Logger.Log("Navigated to the Login page.");
    }

    [Theory]
    [InlineData("Username is required")]
    public void TestLoginForm_EmptyFields_UsernameIsRequiredError(string expectedMessage)
    {
        try
        {
            Logger.Log($"Testing login with empty inputs");
            _loginPage.EnterUsername(randomCredentials);
            _loginPage.EnterPassword(randomCredentials);
            _loginPage.ClearFields();
            _loginPage.ClickLogin();

            _loginPage.GetErrorMessage().Should().Contain(expectedMessage);
            Logger.Log($"Error message: {expectedMessage}.");
            Logger.Log("Test passed.");
        }
        catch (Exception ex)
        {
            Logger.Log($"Test failed with exception: {ex.Message}");
            Logger.Log($"Stack Trace: {ex.StackTrace}");

            throw;
        }
        finally
        {
            Logger.Log("Test completed.");
        }
    }

    [Theory]
    [InlineData("standard_user", "Password is required")]
    public void TestLoginForm_EmptyPassword_PasswordIsRequiredError(string username, string expectedMessage)
    {
        try
        {
            Logger.Log($"Testing login with Username: {username}, empty password");
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(randomCredentials);
            _loginPage.ClearPasswordField();
            _loginPage.ClickLogin();

            _loginPage.GetErrorMessage().Should().Contain(expectedMessage);
            Logger.Log($"Error message: {expectedMessage}.");
            Logger.Log("Test passed.");
        }
        catch (Exception ex)
        {
            Logger.Log($"Test failed with exception: {ex.Message}");
            Logger.Log($"Stack Trace: {ex.StackTrace}");

            throw;
        }
        finally
        {
            Logger.Log("Test completed.");
        }
    }

    [Theory]
    [InlineData("standard_user", "secret_sauce", "Swag Labs")]
    public void TestLoginForm_AcceptedCredentials_DashboardContainsSwagLabs(string username, string password, string expectedMessage)
    {
        try
        {
            Logger.Log($"Testing login with Username: {username}, Password: {password}");
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLogin();
            _loginPage.GetDashboardTitle().Should().Be(expectedMessage);
            Logger.Log($"Dashboard title: {expectedMessage}.");
            Logger.Log("Test passed.");
        }
        catch (Exception ex)
        {
            Logger.Log($"Test failed with exception: {ex.Message}");
            Logger.Log($"Stack Trace: {ex.StackTrace}");

            throw;
        }
        finally
        {
            Logger.Log("Test completed.");
        }
    }

    public void Dispose()
    {
        _driver.Quit();
        Logger.Log("Browser closed.\n");

        GC.SuppressFinalize(this);
    }
}
    /*  Run all tests in one method
        [Theory]
        [MemberData(nameof(DataProvider.LoginTestData), MemberType = typeof(DataProvider))]
        public void TestLoginForm(string username, string password, string expectedMessage)
        {
            try
            {
                Logger.Log($"Testing login with Username: {username}, Password: {password}");
                _loginPage.EnterUsername(randomCredentials);
                _loginPage.EnterPassword(randomCredentials);
                _loginPage.ClearFields();
                _loginPage.EnterUsername(username);
                _loginPage.EnterPassword(password);
                _loginPage.ClickLogin();

                if (expectedMessage == "Swag Labs")
                {
                    _loginPage.GetDashboardTitle().Should().Be(expectedMessage);
                    Logger.Log($"Dashboard title: {expectedMessage}.");
                }
                else
                {
                    _loginPage.GetErrorMessage().Should().Contain(expectedMessage);
                    Logger.Log($"Error message: {expectedMessage}.");
                }

                Logger.Log("Test passed.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Test failed with exception: {ex.Message}");
                Logger.Log($"Stack Trace: {ex.StackTrace}");

                throw;
            }
            finally
            {
                Logger.Log("Test completed.");
            }
        }*/
