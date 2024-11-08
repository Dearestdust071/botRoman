using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace WhatsAppService.Api.Services.WhatsAppCloud
{

    public class WhatsAppCloudSendMessage : IWhatsAppCloudSendMessage
    {

        // private readonly string endpoint = "https://graph.facebook.com/v20.0/142689948936579/messages";

        // public async Task<bool> EnviarMensaje(string token, object body)
        // {
        //     var client = new HttpClient();
        //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        //     string uri = $"{endpoint}";
        //     object message = body;
        //     string jsonContent = JsonSerializer.Serialize(message);
        //     var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        //     var response = await client.PostAsync(uri, content);
        //     if (response.IsSuccessStatusCode)
        //     {
        //         string responseContent = await response.Content.ReadAsStringAsync();
        //         return responseContent;
        //     }
        //     return string.Empty;

        // }


        public async Task<bool> Execute(object model)
        {
            var client = new HttpClient();
            var byteData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model));

            using (var content = new ByteArrayContent(byteData))
            {
                string endpoint = "https://graph.facebook.com";
                string phoneNumberId = "142689948936579";
                string accessToken = "EAAHMkNepFcsBO0CMWaMyHQIVDyVZAZAovhtif5eYwJPNkyQ3o0PF74ODe8U7nnpsMW4rhmgmQkmnZBHvP8Hg4y4EeQwGXwZB8qcpPAGfJ4574eKipyqZCHzPeA8bp9xMQmv7IZCII9f976P643A4VZBo25iTzeEL3lbAZBmDUdkJJ3tB3nEf0CeEv2AvrzakVxDK";
                string uri = $"{endpoint}/v18.0/{phoneNumberId}/messages";

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                var response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
        }




    }



}