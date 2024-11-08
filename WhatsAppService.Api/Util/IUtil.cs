using WhatsAppService.Api.Models;
namespace WhatsAppService.Api.Util
{

    public interface IUtil
    {

        string GetUserText(Message message);
        object TextMessage(string message, string number);
        // string GetNumber(Message message);
        // string GetUserType(Message message);
        // object ImageMessage(string number, string link);
        // object LocationMessage(string number);
        // object ButtonMessage(string number);
        string TratarNumero(string numero);

    }



}