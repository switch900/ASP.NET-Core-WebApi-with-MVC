using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookClient.Models;
using BookApi.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace BookClient.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string url = "https://bookapiawh.azurewebsites.net/api/books";

        public HomeController()
        {
        }
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var books = new List<Book>();

            using (var response = client.GetAsync(url).Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject(jsonResult);
                    books = JsonConvert.DeserializeObject<List<Book>>(jsonResult);
                }
            }
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Display(string id)
        {
            Book book = null;
           
            using (var response = client.GetAsync(url+"/"+id).Result)

            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<Book>(jsonResult);
                }
            }
            return View(book);
        }
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
