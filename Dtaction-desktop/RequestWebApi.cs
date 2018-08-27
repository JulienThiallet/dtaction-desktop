using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dtaction_desktop
{
    static class RequestWebApi
    {
        private static string Uri = "http://dtaction.azurewebsites.net/";

        public static User GetUser(string pseudo, string psw)
        {  
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/user/getbypseudopsw/{pseudo}/{psw}").Result;

            if (response.IsSuccessStatusCode)
            {
                User user = null;
                user = response.Content.ReadAsAsync<User>().Result;
                return user;
            }
            return null;
        }
    }
}
