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
    class DeleteAction : IAction
    {
        public void DoAction(string AccessToken, string baseAddress)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var ApiDemoWithAuthResponse = client.DeleteAsync(baseAddress + "api/product/Delete?id=2").Result;

            if (ApiDemoWithAuthResponse.IsSuccessStatusCode)
            {
                var ApiDemoWithAuthResponseToGetproducts = client.GetAsync(baseAddress + "api/product/get").Result;
                if (ApiDemoWithAuthResponseToGetproducts.IsSuccessStatusCode)
                {
                    var JsonContent = ApiDemoWithAuthResponse.Content.ReadAsStringAsync().Result;
                    var JsonContentGetReq = ApiDemoWithAuthResponseToGetproducts.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("-----------Delete Product--------------------");
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
