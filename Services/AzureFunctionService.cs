using System.Net.Http;
using System.Threading.Tasks;

public class AzureFunctionService : IAzureFunctionService
{
    private readonly HttpClient _httpClient;

    public AzureFunctionService(HttpClient httpClient){
       _httpClient = httpClient;
   }

   public async Task GetAzureFunctionResponse(){
       string response = await _httpClient.GetStringAsync("");
   } 
}