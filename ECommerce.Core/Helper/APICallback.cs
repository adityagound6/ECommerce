using System.Text.Json;
using Newtonsoft.Json;

namespace ECommerce.Core.Helper
{
    public class APICallback<T>
    {
        public async static Task<CustomHTTPResponse<T?>> CallFunction(string endpoint,StringContent content = null)
        {
            using (HttpClient client = new HttpClient())
            {
                string? data = null;
                HttpResponseMessage? responseMessage = null;
                if (content != null)
                {
                    responseMessage = await client.PostAsync(endpoint, content);
                }
                else
                {
                    responseMessage = await client.GetAsync(endpoint);
                }
                if (responseMessage.IsSuccessStatusCode)
                {
                    data = await responseMessage.Content.ReadAsStringAsync();
                    if (data == "[]")
                    {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                        return new CustomHTTPResponse<T>
                        {
                            Success = true,
                            Message = "No Data Found",
                            //Result = ;
                        };
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
                    }
                    var result = JsonConvert.DeserializeObject<T>(data);
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                    return new CustomHTTPResponse<T>
                    {
                        Success = true,
                        Message = "",
                        Result = JsonConvert.DeserializeObject<T>(data)
                    };
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
                }
                else
                {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
                    return new CustomHTTPResponse<T>
                    {
                        Success = false,
                        Message = await responseMessage.Content.ReadAsStringAsync()
                    };
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
                }
            }
        }
    }

    public class CustomHTTPResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}