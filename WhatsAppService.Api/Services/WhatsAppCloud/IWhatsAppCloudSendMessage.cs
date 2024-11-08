namespace WhatsAppService.Api.Services.WhatsAppCloud
{

    public interface IWhatsAppCloudSendMessage{
        Task<bool> Execute(object model);
    }
}




