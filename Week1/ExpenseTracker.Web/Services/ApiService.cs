using System.Net.Http.Json;
using ExpenseTracker.Web.Models;
using System.Text.Json;

namespace ExpenseTracker.Web.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ApiService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _baseUrl = config["ApiSettings:BaseUrl"]!;
    }

    public async Task<List<TransactionResponseDto>> GetTransactions(Guid userId)
    {
        return await _httpClient.GetFromJsonAsync<List<TransactionResponseDto>>(
            $"{_baseUrl}/api/transactions?userId={userId}"
        ) ?? new List<TransactionResponseDto>();
    }

    public async Task<decimal> GetTotal(Guid userId)
    {
        var response = await _httpClient.GetAsync(
            $"{_baseUrl}/api/transactions/total?userId={userId}"
        );

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadFromJsonAsync<Dictionary<string, decimal>>();

        return json?["total"] ?? 0;
    }



    public async Task<List<CategoryAnalyticsDto>> GetByCategory(Guid userId)
    {
        return await _httpClient.GetFromJsonAsync<List<CategoryAnalyticsDto>>(
            $"{_baseUrl}/api/transactions/by-category?userId={userId}"
        ) ?? new List<CategoryAnalyticsDto>();
    }
}