using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client = null;
        HttpClient InitHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44397/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;


        }

        public async Task<ActionResult> Index()
        {
            using (client = InitHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("Students");


                if (response.IsSuccessStatusCode)
                {
                    List<Student> list = await response.Content.ReadAsAsync<List<Student>>();
                    return View(list);
                }
                else
                {
                    ViewBag.msg = response.StatusCode;
                    return View();
                }


            }

            
        }

        public async Task<ActionResult> Details(int id)
        {
            using (client = InitHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("Students/"+ id);


                if (response.IsSuccessStatusCode)
                {
                    Student student= await response.Content.ReadAsAsync<Student>();
                    return View(student);
                }
                else
                {
                    ViewBag.msg = response.StatusCode;
                    return View();
                }


            }


        }

        [HttpGet]
        public  async Task<ActionResult> Create()
        {
            return View(new Student());

        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            using (client = InitHttpClient())
            {
                 HttpResponseMessage response = await client.PostAsJsonAsync("Students", student);
                
                if (response.IsSuccessStatusCode)
                {
                   
                    return RedirectToAction("Index");
                }
                else
                { 
                    return View();
                }


            }


        }
    }
}

