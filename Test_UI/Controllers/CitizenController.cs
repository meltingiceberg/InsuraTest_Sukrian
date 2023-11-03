using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Test_UI.Models;

namespace Test_UI.Controllers
{
    public class CitizenController : Controller
    {
        private readonly ILogger<CitizenController> _logger;
        private readonly HttpClient _httpClient;

        public CitizenController(ILogger<CitizenController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // GET: CitizenController
        public ActionResult Index()
        {
            List<CitizenViewModel> list = new List<CitizenViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                list = JsonConvert.DeserializeObject<List<CitizenViewModel>>(data)!;
                foreach(CitizenViewModel item in list)
                {
                    item.StatusPerkawinanText = ((StatusPerkawinanEnum)item.StatusPerkawinan).ToString();
                }
            }
            return View(list);
        }

        // GET: CitizenController/Details/5
        public ActionResult Details(int id)
        {
            CitizenViewModel? citizen = null;
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                citizen = JsonConvert.DeserializeObject<CitizenViewModel>(data);
                if(citizen != null)
                {
                    citizen.StatusPerkawinanText = ((StatusPerkawinanEnum)citizen.StatusPerkawinan).ToString();
                }
            }
            return View(citizen);
        }

        // GET: CitizenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CitizenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CitizenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CitizenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CitizenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CitizenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
