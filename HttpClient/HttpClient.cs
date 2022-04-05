using SysBot.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace SysBot.ACNHOrders.HttpDodoClient
{
    public class HttpDodoClientClass
    {

        private string Username { get; }
        private string Password { get; }
        private string URI { get; }

        private static readonly HttpClient client = new HttpClient();

        public HttpDodoClientClass(string username, string password, string uriEndpoint)
        {
            
            Username = username;
            Password = password;
            URI = uriEndpoint;

        }

        public async Task<string> DodoPostMehtod(string island, string code)
        {

            var values = new Dictionary<string, string>
            {
                { "island", island },
                { "code", code },
                { "username", Username },
                { "password", Password }
            };

            try
            {
                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(URI, content);

                var responseString = await response.Content.ReadAsStringAsync();
                
                return responseString;

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}