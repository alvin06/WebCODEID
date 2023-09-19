using Azure;
using CODEID.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PagedList;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CODEID.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Messsage { get; set; }
        public List<UserComments> userComments { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            Messsage = "Hello World! Sorry not using pagination";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userComments = JsonConvert.DeserializeObject<List<UserComments>>(apiResponse);
                    userComments.ToPagedList(1, 10);
                }
            }
        }
    }
}