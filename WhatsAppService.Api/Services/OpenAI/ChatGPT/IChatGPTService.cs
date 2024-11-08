
namespace WhatsAppService.Api.Services.OpenAI.ChatGPT{


    public interface IChatGPTService
    {
            Task<string> Execute(string textuser);
    }



}