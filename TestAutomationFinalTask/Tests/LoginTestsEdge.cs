using FluentAssertions;
using OpenQA.Selenium;
using TestAutomationFinalTask.Drivers.Fixtures;
using TestAutomationFinalTask.Pages;
using TestAutomationFinalTask.Utils;

namespace TestAutomationFinalTask.Tests;

[Collection("Edge collection")]
public class LoginTestsEdge
{
    [Theory]
    [MemberData(nameof(TestData.ValidLoginData), MemberType = typeof(TestData))]
    public void GivenValidCredentials_WhenLoginIsAttempted_ThenDashboardTitleIsDisplayed(string username, string password, string expectedMessage)
    {
        using var fixture = new EdgeWebDriverFixture();
        IWebDriver driver = fixture.Driver;
        LoginPage loginPage = new(driver);

        // Given the user is on the login page
        loginPage.Navigate();
        Logger.LogNavigation();

        Logger.LogParameters(username, password);
        // When the user type credentials in username which are under Accepted username are sections      
        loginPage.EnterUsername(username);
        // And enter password as "secret sauce"
        loginPage.EnterPassword(password);
        // And hit the "Login" button
        loginPage.ClickLogin();
        // Then title “Swag Labs” appears in the dashboard
        loginPage.GetDashboardTitle().Should().Be(expectedMessage);

        Logger.LogSuccessfulLogin(expectedMessage);
        Logger.LogTestCompleted();
    }
}