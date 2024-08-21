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
    public class BpkbController : Controller
    {
        private readonly ILogger<BpkbController> _logger;
        string baseURL = "http://localhost:5165/api/MCF/";
        public BpkbController(ILogger<BpkbController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
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
            return View(bpkbList);
        }
        public async Task<IActionResult> Create()
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
        public async Task<IActionResult> Edit(string Id)
        {
            var bpkb = new BPKB();
            var locationdata = new List<Location>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.GetAsync("getbpkbbyid?id="+Id);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    bpkb = JsonConvert.DeserializeObject<BPKB>(result);

                }
                client.DefaultRequestHeaders.Accept.Clear();
                response = await client.GetAsync("getall_location");
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
            return View(bpkb);
        }
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
        public async Task<IActionResult> EditBPKB(BPKB bpkb)
        {
            bpkb.CreateBy = "admin";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.PostAsJsonAsync("edit_bpkb", bpkb);
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.DeleteAsync("delete_bpkb?id=" + Id);
                if (response.IsSuccessStatusCode)
                {
                    await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }

}