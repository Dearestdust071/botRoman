namespace WhatsAppService.Api.Services.AmazonService{

    public class AmazonService : IAmazonService {


        private readonly string endpoint = "https://real-time-amazon-data.p.rapidapi.com/search?";

        public async Task<string> RevisarProductos (string query, string page , string country, string sort_by, string product_condition ){
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "real-time-amazon-data.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "c1eeafe456msh8f9a955c6e3aaadp12a8e3jsna4b00dc655c4");
            // Signo de peso es para concatenar variables
            string uri = $"{endpoint}query={query}&page={page}&country={country}&sort_by={sort_by}&product_condition={product_condition}";
        var response = await client.GetAsync(uri);

            if(response.IsSuccessStatusCode){
                string responseContent = await response.Content.ReadAsStringAsync(); 
                return responseContent;
            }
            return string.Empty;

        }



    }



}