using Farabeh.MyBuilding.Framework.Results;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Farabeh.MyBuilding.Framework.HttpClinet;

public class BaseHttpClient
{
    private readonly HttpClient _client;

    public BaseHttpClient(HttpClient httpClient)
    {
        _client = httpClient;

        var baseAddress = _client.BaseAddress;
        HttpClientHandler clientHandler = new HttpClientHandler();
        clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
        {
            return true;
        };

        _client = new HttpClient(clientHandler);
        _client.BaseAddress = baseAddress;

        _client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa-IR"));
    }

    protected async Task<Result<T>> GetAsync<T>(string url)
    {
        AppContext.SetSwitch("System.Net.Http.UseSocketsHttpHandler", false);

        try
        {
            var responce = await _client.GetAsync(url);
            return await responce.ToResult<T>();
        }
        catch (Exception ex)
        {
            return Result.Fail<T>(ex.Message);
        }
    }

    protected async Task<Result<TOutput>> PostAsync<TInput, TOutput>(TInput data, string url)
    {
        try
        {
            var categoryJson = GetStringContent(data);
            var response = await _client.PostAsync(url, categoryJson);
            return await response.ToResult<TOutput>();
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(ex.Message);
        }
    }

    protected async Task<Result<TOutput>> PutAsync<TInput, TOutput>(TInput data, string url)
    {
        try
        {
            var categoryJson = GetStringContent(data);
            var response = await _client.PutAsync(url, categoryJson);
            return await response.ToResult<TOutput>();
        }
        catch (Exception ex)
        {
            return Result.Fail<TOutput>(ex.Message);
        }
    }

    protected async Task<Result> PutAsync<TInput>(TInput data, string url)
    {
        try
        {
            var categoryJson = GetStringContent(data);
            var response = await _client.PutAsync(url, categoryJson);
            return response.ToResult();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    protected async Task<Result> DeleteAsync(string url)
    {
        try
        {
            var response = await _client.DeleteAsync(url);
            return response.ToResult();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    protected async Task<Result> DeleteAsync<TInput>(TInput input, string url)
    {
        try
        {
            var inputJson = GetStringContent(input);
            var request = new HttpRequestMessage(HttpMethod.Delete, url);
            request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
            request.Content = inputJson;
            var response = await _client.SendAsync(request);
            return response.ToResult();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.Message);
        }
    }

    private StringContent GetStringContent<T>(T t)
    {
        return new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
    }
}
