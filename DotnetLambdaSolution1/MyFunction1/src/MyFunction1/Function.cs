using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace MyFunction1;

public class Function
{
    private readonly IExampleService exampleService;

    // Default ctor
    public Function()
        : this(ExampleServiceBootstrapper.CreateInstance()) { }

    // Injection ctor
    public Function(IExampleService exampleService)
    {
        this.exampleService = exampleService;
    }

    [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
    public async Task<ExampleResult> FunctionHandler(ExampleEvent lambdaEvent)
    {
        var message = await this.exampleService.GetMessageToReturn();

        return new ExampleResult
        {
            Message = message
        };
    }
}

public record Casing(string Lower, string Upper);