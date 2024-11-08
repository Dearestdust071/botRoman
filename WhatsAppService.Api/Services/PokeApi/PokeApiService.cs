namespace WhatsAppService.Api.Services.PokeApi{

    public class PokeApiService : IPokeApiService {


        private readonly string endpoint = "https://pokeapi.co/api/v2/pokemon";

        public async Task<string> TraerPokemon (string NombrePokemon){
            var client = new HttpClient();
            // Signo de peso es para concatenar variables
            string uri = $"{endpoint}/{NombrePokemon}";
            var response = await client.GetAsync(uri);
            
            if(response.IsSuccessStatusCode){
                string responseContent = await response.Content.ReadAsStringAsync(); 
                return responseContent;
            }
            return string.Empty;

        }



    }



}