namespace WhatsAppService.Api.Services.AmazonService
{
public interface IAmazonService{
        Task<string> RevisarProductos (string query, string page , string country, string sort_by, string product_condition);
}





}