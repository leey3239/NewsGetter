using System;
using System.Net.Http;
using System.Text.Json;

public class GrabData
{
    private readonly string BaseApi;
    private readonly string ApiKey;
    private readonly HttpClient HttpClient;
    public GrabData(string baseApi, string apiKey)
	{
        HttpClient = new();
        BaseApi = baseApi;
        ApiKey = apiKey;
	}
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };
    public async Task<List<NewsDto>> GetNews(string type)
    {
        string url = $"{BaseApi}/news?category={type}&token={ApiKey}";

        HttpResponseMessage response = await HttpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        List<NewsDto> newsDtoList = JsonSerializer.Deserialize<List<NewsDto>>(responseBody, _options) ?? new();

        return newsDtoList;
    }


}
