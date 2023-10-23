using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

namespace MyFunction1.Tests;

public class FunctionTest
{
    [Fact]
    public void TestToUpperFunction()
    {

        // Invoke the lambda function and confirm the string was upper cased.
        var function = new Function();
        var context = new TestLambdaContext();
        var casing = function.FunctionHandler("hello world", context);

        Assert.Equal("hello world", casing.Lower);
        Assert.Equal("HELLO WORLD", casing.Upper);
    }

    [Fact]
    public async Task Handler_Returns_Message_From_Example_Service()
    {
        var testMessage = "Hello, world!  Testing...";

        var exampleServiceMock = new Mock();

        exampleServiceMock
            .Setup(m => m.GetMessageToReturn())
            .Returns(Task.FromResult(testMessage));

        // here we use the overloaded ctor to inject mocks
        var function = new Function(exampleServiceMock.Object);

        var result = await function.Handler(new ExampleEvent());

        // assert that the message we told the service mock to return is equal to the one
        // the function returns in the result.
        Assert.Equal(testMessage, result.Message);
    }
}