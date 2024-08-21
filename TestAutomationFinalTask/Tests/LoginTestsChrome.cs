using FluentAssertions;
using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers.Fixtures;
using TestAutomationFinalTask.Pages;
using TestAutomationFinalTask.Utils;

namespace TestAutomationFinalTask.Tests;

[Collection("Chrome collection")]
public class LoginTestsChrome
{
    private readonly string randomCredentials = "qwerty";

    [Theory]
    [MemberData(nameof(TestData.EmptyPasswordData), MemberType = typeof(TestData))]
    public void GivenUsernameAndEmptyPassword_WhenLoginIsAttempted_ThenPasswordErrorMessageIsDisplayed(string username, string expectedMessage)
    {
        using var fixture = new ChromeWebDriverFixture();
        IWebDriver driver = fixture.Driver;
        LoginPage loginPage = new(driver);

        // Given the user is on the login page
        loginPage.Navigate();
        Logger.LogNavigation();

        Logger.LogParameters(username, string.Empty);
        // When the user type any credentials into "Username" and "Password" fields  
        loginPage.EnterUsername(username);
        loginPage.EnterPassword(randomCredentials);
        // And clear the "Password" input
        loginPage.ClearPasswordField();
        // And hit the "Login" button
        loginPage.ClickLogin();
        // Then the error messages appears: "Password is required"
        loginPage.GetErrorMessage().Should().Contain(expectedMessage);

        Logger.LogExpectedMessage(expectedMessage);
        Logger.LogTestCompleted();
    }
}
