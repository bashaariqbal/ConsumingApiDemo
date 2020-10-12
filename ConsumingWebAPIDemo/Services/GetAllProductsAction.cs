using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ConsumingWebAPIDemo.IService;


namespace ConsumingWebAPIDemo.Services
{
    public class GetAllProductsAction : IAction
    {
        public void DoAction(string AccessToken, string baseAddress)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            var ApiDemoWithAuthResponse = client.GetAsync(baseAddress + "api/product/get").Result;

            if (ApiDemoWithAuthResponse.IsSuccessStatusCode)
            {
                var JsonContent = ApiDemoWithAuthResponse.Content.ReadAsStringAsync().Result;
                //Token Message = JsonConvert.DeserializeObject<Token>(JsonContent);  
                Console.WriteLine("-----------All Products--------------------");
                Console.WriteLine();
                Console.WriteLine("ApiDemoWithAuthResponse : " + JsonContent.ToString());
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------");
            }
            else
            {
                Console.WriteLine("ApiDemoWithAuthResponse, Error : " + ApiDemoWithAuthResponse.StatusCode);
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------");
            }
        }
    }
}
