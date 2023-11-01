using Microsoft.EntityFrameworkCore;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;
using Shared.Entities;
using Shared.Repository;

namespace ChatGptDeneme.Services;

public class OpenAıCompletionService : BackgroundService
{
    private readonly IOpenAIService _openAıService;
    private readonly IGeneralRepository _generalRepository;

    public OpenAıCompletionService(IOpenAIService openAıService, IGeneralRepository generalRepository)
    {
        _openAıService = openAıService;
        _generalRepository = generalRepository;
    }

    protected override async Task<AıResponse> ExecuteAsync(CancellationToken stoppingToken)
    {
        AıResponse response = new();

        var user = await _generalRepository.Query<User>().FirstOrDefaultAsync(_ => _.Id == 61, cancellationToken: stoppingToken); // Kullanıcıdan gelen Id değeri ile sorgulanacak
        
        while (true)
        {
            Console.Write("::");

            CompletionCreateResponse result = await _openAıService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = Console.ReadLine(),
                MaxTokens = 1000
            }, Models.TextDavinciV3, cancellationToken: stoppingToken);

            response.Message = result.Choices[0].Text;
            response.Id = user.Id;
            user.Responses.Add(response);

            Console.WriteLine(response.Message);
        }
        
    }
}