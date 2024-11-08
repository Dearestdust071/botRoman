using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhatsAppService.Api.Models;
// using WhatsAppService.Api.Services.PokeApi;
using WhatsAppService.Api.Services.AmazonService;
using WhatsAppService.Api.Services.WhatsAppCloud;
using WhatsAppService.Api.Util;
using WhatsAppService.Api.Services.OpenAI.ChatGPT;

namespace WhatsAppService.Api.Controllers
{
    //Esto sirve para acceder al archivo "WhatsappController"
    [Route("api/whatsapp")]
    [ApiController]
    public class WhatsappController : Controller
    {
        // private readonly IPokeApiService _pokeApiService;
        private readonly IAmazonService _amazonService;
        private readonly IUtil _util;
        private readonly IWhatsAppCloudSendMessage _whatsAppCloudSendMessage;
        private readonly IChatGPTService _chatGPTService;

        //instancia del servicio


        //Consultor
        // [HttpPost("Pokemon")]
        public WhatsappController(IAmazonService amazonService, IUtil util, IWhatsAppCloudSendMessage whatsAppCloudSendMessage, IChatGPTService chatGPTService)
        {
            // _pokeApiService = pokeApiService;
            // Inyectamos el servicio cosa
            _amazonService = amazonService;
            _util = util;
            _whatsAppCloudSendMessage = whatsAppCloudSendMessage;
            _chatGPTService = chatGPTService;
        }

        // Esta ruta es para configurar mi webhook
        [HttpGet("webhook")]
        public IActionResult VerifyToken()
        {
            string AccesToken = "94a08da1fecbb6e8b46990538c7b50b2";
            string token = Request.Query["hub.verify_token"].ToString();
            string challenge = Request.Query["hub.challenge"].ToString();

            if (token == AccesToken && token != null && challenge != null)
            {
                return Ok(challenge);
            }
            else
            {
                return BadRequest();
            }
        }



        [HttpPost("webhook")]
        public async Task<IActionResult> RecibirMensaje([FromBody] WhatsAppModel body)
        {
            try
            {
                Message? Message = body.Entry?[0].Changes?[0].Value?.Messages?[0];

                if (Message != null)
                {

                    var userNumber = _util.TratarNumero(Message.From);

                    var userText = _util.GetUserText(Message);
            
                    var responseChatGPT = await _chatGPTService.Execute(userText);

                    object objectMessage = _util.TextMessage(responseChatGPT, userNumber);

                    await _whatsAppCloudSendMessage.Execute(objectMessage);

                    return Ok(objectMessage);

                }

                return BadRequest(new
                {
                    error = true,
                    msj = "Ocurrio un error"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = true,
                    msj = ex.Message
                });
            }

        }









        [HttpPost("Amazon")]
        public async Task<IActionResult> GetProducto([FromBody] AmazonModel body)
        {
            try
            {
                var response = await _amazonService.RevisarProductos(
                    body.query,
                    body.page,
                    body.country,
                    body.sort_by,
                    body.product_condition
                );
                return Content(response, "application/json");
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

