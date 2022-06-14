using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            HttpClient client = new HttpClient();

            var token = string.Empty;
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            string endpoint = "https://localhost:44397/api/Authentication";
            client.BaseAddress = new Uri(endpoint);
            var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            var Response = client.PostAsync(endpoint, content);
            var result = Response.Result;

            if (result.IsSuccessStatusCode)
            {
                var stringJWT = result.Content.ReadAsStringAsync().Result;
                JWT jwt = JsonConvert.DeserializeObject
  <JWT>(stringJWT);
                HttpContext.Session.SetString("token", jwt.Token);

                ViewBag.Message = "User logged in successfully!";
                //HttpContext.Session["token"] = token.ToString();
                //return View();

                return RedirectToAction("Index", "Student");

            }
            else
                return View();


        }
        public class JWT
        {
            public string Token { get; set; }
        }

    }
}
