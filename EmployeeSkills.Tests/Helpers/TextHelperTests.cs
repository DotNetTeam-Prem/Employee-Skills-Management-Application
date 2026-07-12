using EmployeeSkills.Web.Helpers;
using Xunit;

namespace EmployeeSkills.Tests.Helpers;

public class TextHelperTests
{
    [Theory]
    [InlineData("prem", "Prem")]
    [InlineData("john", "John")]
    [InlineData("Amit", "Amit")]
    public void Capitalize_Should_Return_Correct_Value(string input, string expected)
    {
        var result = TextHelper.Capitalize(input);

        Assert.Equal(expected, result);
    }
}