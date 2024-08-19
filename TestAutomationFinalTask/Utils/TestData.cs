namespace TestAutomationFinalTask.Utils;

public static class TestData
{
    public static TheoryData<string> EmptyFieldData =>
        new()
        {
        { "Username is required" }
        };

    public static TheoryData<string, string> EmptyPasswordData =>
        new()
        {
        { "standard_user", "Password is required" }
        };

    public static TheoryData<string, string, string> ValidLoginData =>
        new()
        {
        { "standard_user", "secret_sauce", "Swag Labs" }
        };
}
