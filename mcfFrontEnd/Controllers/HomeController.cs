using mcfFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

namespace mcfFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseURL = "http://localhost:5165/api/MCF/";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var locationdata = new List<Location>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync("getall_location");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    locationdata = JsonConvert.DeserializeObject<List<Location>>(result);

                }
            }
            List<SelectListItem> ListLocation = new List<SelectListItem>();
            foreach (var item in locationdata)
            {
                ListLocation.Add(new SelectListItem { Value = item.LocationId, Text = item.LocationName });
            }

            ViewBag.LocationList = ListLocation;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> InsertBPKB(BPKB bpkb)
        {
            bpkb.CreateBy = "admin";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.PostAsJsonAsync("insert_bpkb", bpkb);
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> LoginForm(UserLogin userlogin)
        {
            var islogin = 0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.PostAsJsonAsync("login", userlogin);
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
                    islogin = 1;
                }
            }
            if (islogin == 1)
            {
                return RedirectToAction("Index");
            }
            else { 
                return RedirectToAction("Login");
            }
        }
        public async Task<IActionResult> bpkb()
        {
            var bpkbList = new List<BPKB>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync("GetallBPKB");
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    bpkbList = JsonConvert.DeserializeObject<List<BPKB>>(result);

                }
            }
            return View(bpkbList.ToList());
        }
    }
}
