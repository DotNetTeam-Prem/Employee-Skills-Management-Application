namespace EmployeeSkills.Web.Helpers;

public static class TextHelper
{
    public static string Capitalize(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        return char.ToUpper(text[0]) + text.Substring(1);
    }
}