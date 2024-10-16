using ConsumirApi_Capitalismo.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ConsumirApi_Capitalismo.Services;

public class RonSwansonService : IRonSwansonService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public RonSwansonService(HttpClient httpClient, ILogger<RonSwansonService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<string> GetRandomRonSwansonText()
    {
        string randomText = $"https://ron-swanson-quotes.herokuapp.com/v2/quotes/";

        var sendRandom = await _httpClient.GetAsync(randomText);

        if (sendRandom.IsSuccessStatusCode)
        {
            string responseRadom = await sendRandom.Content.ReadAsStringAsync();
            _logger.LogInformation("Text generated successfully.");
            return responseRadom;
        } 
        else
        {
            _logger.LogWarning("Unable to provide text");
            return "Not Found";
        }
    }

    public async Task<string> GetRonSwansonId(int id)
    {
        string randomTextId = $"https://ron-swanson-quotes.herokuapp.com/v2/quotes/{id}";
         
        var OkSendRandom = await _httpClient.GetAsync(randomTextId);

        if (OkSendRandom.IsSuccessStatusCode)
        {
            var generateRandomId = await OkSendRandom.Content.ReadAsStringAsync();
            _logger.LogInformation($"The text by id {id} generated successfully");
            return generateRandomId;
        }
        else
        {
            _logger.LogWarning("Id not found or invalid");
            return "Invalid or not found id";
        }
    }

    public async Task<string> GetRonSwansonTerm()
    {
        string randonTerm = $"https://ron-swanson-quotes.herokuapp.com/v2/quotes/term";

        var sendTerm = await _httpClient.GetAsync(randonTerm);

        if (sendTerm.IsSuccessStatusCode)
        {
            var generateTerm = await sendTerm.Content.ReadAsStringAsync();
            _logger.LogInformation("The text term generated sucessfully");
            return generateTerm;
        }
        else
        {
            _logger.LogWarning("Not possible generated term");
            return "Term invalid";
        }
    }
}
