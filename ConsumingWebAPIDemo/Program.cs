using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ConsumingWebAPIDemo.Services;
using ConsumingWebAPIDemo.IService;
using System.Threading;

namespace ConsumingWebAPIDemo
{

    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
    class Program
    {
       
        private static string Username = string.Empty;
        private static string Password = string.Empty;
        private static string baseAddress = "http://localhost:61521/";
        static void Main(string[] args)
        {
            Username = "admin";
            Password = "admin";
            Token token = null;
            token = GetAccessToken(Username, Password);
            if (!string.IsNullOrEmpty(token.AccessToken))
            {

                ActionService actionServiceForAllProducts = new ActionService(new GetAllProductsAction());
                actionServiceForAllProducts.TakeAction(token.AccessToken, baseAddress);
                Thread.Sleep(2000);

                ActionService getProductAction = new ActionService(new GetProductAction());
                getProductAction.TakeAction(token.AccessToken, baseAddress);
                Thread.Sleep(2000);

                ActionService addAction = new ActionService(new AddAction());
                addAction.TakeAction(token.AccessToken, baseAddress);
                Thread.Sleep(2000);

                ActionService editAction = new ActionService(new EditAction());
                editAction.TakeAction(token.AccessToken, baseAddress);
                Thread.Sleep(2000);

                ActionService deleteAction = new ActionService(new DeleteAction());
                deleteAction.TakeAction(token.AccessToken, baseAddress);
              
            }
            else
            {
                Console.WriteLine(token.Error);
            }
            Console.ReadLine();
        }
        public static Token GetAccessToken(string username, string password)
        {
            Token token = new Token();
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            var RequestBody = new Dictionary<string, string>
                {
                {"grant_type", "password"},
                {"username", username},
                {"password", password},
                };
            var tokenResponse = client.PostAsync(baseAddress + "token", new FormUrlEncodedContent(RequestBody)).Result;

            if (tokenResponse.IsSuccessStatusCode)
            {
                var JsonContent = tokenResponse.Content.ReadAsStringAsync().Result;
                token = JsonConvert.DeserializeObject<Token>(JsonContent);
                token.Error = null;
            }
            else
            {
                token.Error = "Not able to generate Access Token Invalid usrename or password";
            }
            return token;
        }
      
    }
}
