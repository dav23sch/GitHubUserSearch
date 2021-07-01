using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GitHubSearch.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public UserResponse Get(string user, int page)
        {
            string url = $"https://api.github.com/search/users?q={user}&page={page}";
            UserResponse response = new UserResponse();
            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";

                try
                {
                    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    {
                        string reader = responseReader.ReadToEnd();
                        response = JsonConvert.DeserializeObject<UserResponse>(reader);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return response;
        }
    }
}
