
using WhatsAppService.Api.Services.PokeApi;
using WhatsAppService.Api.Services.AmazonService;
using WhatsAppService.Api.Services.WhatsAppCloud;
using WhatsAppService.Api.Util;
using WhatsAppService.Api.Services.OpenAI.ChatGPT;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//primero abrimos la interfaz y despues el servicio
builder.Services.AddSingleton<IPokeApiService, PokeApiService>();
builder.Services.AddSingleton<IAmazonService, AmazonService>();
builder.Services.AddSingleton<IUtil, Util>();
builder.Services.AddSingleton<IWhatsAppCloudSendMessage, WhatsAppCloudSendMessage>();
builder.Services.AddSingleton<IChatGPTService, ChatGPTService>();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();