namespace TestAutomationFinalTask.Utils;

public static class DataProvider
{
    public static TheoryData<string, string, string> LoginTestData => new()
    {
        { string.Empty, string.Empty, "Username is required" },
        { "standard_user", string.Empty, "Password is required" },
        { "standard_user", "secret_sauce", "Swag Labs" }
    };
}
