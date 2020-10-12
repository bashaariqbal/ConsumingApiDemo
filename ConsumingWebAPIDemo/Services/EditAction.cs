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
    class EditAction : IAction
    {
        public void DoAction(string AccessToken, string baseAddress)
        {
            var product = new Product
            {
                Id = 1,
                ProductName = "Car Edit",
                Price = 2000

            };

            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            var RequestBody = new Dictionary<string, string>
                {
                  {"Id", product.Id.ToString()},
                  {"Price", product.Price.ToString()},
                  {"ProductName", product.ProductName},
                };
            var ApiDemoWithAuthResponse = client.PutAsync(baseAddress + "api/product/Edit", new FormUrlEncodedContent(RequestBody)).Result;

            if (ApiDemoWithAuthResponse.IsSuccessStatusCode)
            {
                var ApiDemoWithAuthResponseToGetproducts = client.GetAsync(baseAddress + "api/product/get").Result;
                if (ApiDemoWithAuthResponseToGetproducts.IsSuccessStatusCode)
                {
                    var JsonContent = ApiDemoWithAuthResponse.Content.ReadAsStringAsync().Result;
                    var JsonContentGetReq = ApiDemoWithAuthResponseToGetproducts.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("-----------Edit Product--------------------");
                    Console.WriteLine();
                    Console.WriteLine("ApiDemoWithAuthResponse : " + JsonContent.ToString());
                    Console.WriteLine("ApiDemoWithAuthResponse All Products: " + JsonContentGetReq.ToString());
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------");
                }

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
