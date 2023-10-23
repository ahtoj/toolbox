using System;

namespace MyFunction1;

public class ExampleServiceBootstrapper
{
    public static IExampleService CreateInstance()
    {
        var messageToReturn = Environment.GetEnvironmentVariable("MessageToReturn");

        return new ExampleService(messageToReturn);
    }
}

