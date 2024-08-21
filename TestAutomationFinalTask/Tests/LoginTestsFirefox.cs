using FluentAssertions;
using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers.Fixtures;
using TestAutomationFinalTask.Pages;
using TestAutomationFinalTask.Utils;

[assembly: CollectionBehavior(DisableTestParallelization = false, MaxParallelThreads = 4)]
namespace TestAutomationFinalTask.Tests;

[Collection("Firefox collection")]
public class LoginTestsFirefox
{
    private readonly string randomCredentials = "qwerty";

    [Theory]
    [MemberData(nameof(TestData.EmptyFieldData), MemberType = typeof(TestData))]
    public void GivenEmptyFields_WhenLoginIsAttempted_ThenUsernameErrorMessageIsDisplayed(string expectedMessage)
    {
        using var fixture = new FirefoxWebDriverFixture();
        IWebDriver driver = fixture.Driver;
        LoginPage loginPage = new(driver);

        // Given the user is on the login page
        loginPage.Navigate();
        Logger.LogNavigation();

        Logger.LogParameters(string.Empty, string.Empty);
        // When the user type any credentials into "Username" and "Password" fields   
        loginPage.EnterUsername(randomCredentials);
        loginPage.EnterPassword(randomCredentials);
        // And clear the inputs
        loginPage.ClearInputFields();
        // And hit the "Login" button
        loginPage.ClickLogin();
        // Then the error messages appears: "Username is required".
        loginPage.GetErrorMessage().Should().Contain(expectedMessage);

        Logger.LogExpectedMessage(expectedMessage);
        Logger.LogTestCompleted();
    }
}