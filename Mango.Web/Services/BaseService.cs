using System.Text;
using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;

namespace Mango.Web.Services;

public class BaseService : IBaseService
{
    public ResponseDto ResponseModel { get; set; }
    public IHttpClientFactory HttpClient { get; set; }
    
    public BaseService(IHttpClientFactory httpClient)
    {
        ResponseModel = new ResponseDto();
        HttpClient = httpClient;
    }


    public async Task<T?> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var client = HttpClient.CreateClient("MangoAPI");
            var message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();
            if (apiRequest.Data is not null)
            {
                var jsonData = JsonConvert.SerializeObject(apiRequest.Data);
                message.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }

            message.Method = apiRequest.ApiType switch
            {
                SD.ApiType.POST => HttpMethod.Post,
                SD.ApiType.PUT => HttpMethod.Put,
                SD.ApiType.DELETE => HttpMethod.Delete,
                _ => HttpMethod.Get
            };

            var apiResponse = await client.SendAsync(message);
            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

            return apiResponseDto;
        }
        catch (Exception e)
        {
            var dto = new ResponseDto
            {
                DisplayMessage = "Error",
                ErrorMessages = new List<string>
                {
                    Convert.ToString(e.Message)
                },
                IsSuccess = false
            };

            var res = JsonConvert.SerializeObject(dto);
            var apiResponseDto = JsonConvert.DeserializeObject<T>(res);

            return apiResponseDto;
        }
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}