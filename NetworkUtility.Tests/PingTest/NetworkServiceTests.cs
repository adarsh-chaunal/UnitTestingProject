using FluentAssertions;
using NetworkUtility.Ping;

namespace NetworkUtility.Tests.PingTest;
public class NetworkServiceTests
{
    [Fact] // helps test runner to know this method needs to be tested.
    public void NetworkService_SendPing_ReutrnString()
    {
        // Arrange - variable, classes, mocks
        var pingService = new NetworkService();

        // Act
        var result = pingService.SendPing();

        // Assert (We can use the xUnit's built in Assert method but dev's generally use Fluent Assertion as it is the best framework for showing error messages)
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Ping Sent!");
        result.Should().Contain("Success", Exactly.Once());
    }

    [Theory] // just like [Fact], but it lets you pass the variables([InlineData]).
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
    {
        // Arrange
        var pingService = new NetworkService();

        // Act
        var result = pingService.PingTimeout(a, b);

        // Assert
        result.Should().Be(expected);
        result.Should().BeGreaterThanOrEqualTo(2);
        result.Should().NotBeInRange(-10000, 0);

    }
}
