using ChatGptDeneme;
using ChatGptDeneme.Services;
using OpenAI.GPT3.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        services.AddHostedService<OpenAıCompletionService>();
        
    })
    .Build();


host.Run();