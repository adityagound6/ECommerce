using ECommerce.Core.Model;
using Newtonsoft.Json;

namespace ECommerce.Core.Helper
{
    public class ApiCall<T>
    {
        public async static Task<GeneralResultList<T>> CallFunction(string endpoint,StringContent content = null)
        {
            GeneralResultList<T> respose = new GeneralResultList<T>();
            using(HttpClient client = new HttpClient())
            {
                string data = null;
                HttpResponseMessage? responseMessage = null;
                if(content == null)
                {
                    responseMessage = await client.GetAsync(endpoint);
                }
                else
                {
                    responseMessage = await client.PostAsync(endpoint,content);
                }
                if (responseMessage.IsSuccessStatusCode)
                {
                    data = await responseMessage.Content.ReadAsStringAsync();
                    respose.Result = JsonConvert.DeserializeObject<T>(data);
                    respose.isSuccess = true;
                    respose.Message = "";
                }
                else
                {
                    respose.isSuccess = false;
                    respose.Message = await responseMessage.Content.ReadAsStringAsync();
                }
            }
            return respose;
        }
    }
}
