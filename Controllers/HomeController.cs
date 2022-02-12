using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SystemTextJson.Models;

namespace SystemTextJson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JsonSerializerOptions _jOpt;

        public HomeController(ILogger<HomeController> logger, JsonSerializerOptions jOpt)
        {
            _logger = logger;
            _jOpt = jOpt;
        }

        public IActionResult Index()
        {
            User user = new User() {
                UserId = new Guid("10000000-0000-0000-0000-000000000000"),
                UserName = "Tushar",
                UserPassword = "Password",
                UserAge = 33,
                UserRole = UserType.Admin,
                dtCreated = DateTime.Now
            };

            var jsonOption = new JsonSerializerOptions() {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                WriteIndented = true
            };
            jsonOption.Converters.Add(new JsonStringEnumConverter());

            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            string str = JsonSerializer.Serialize(user);
            string str2 = JsonSerializer.Serialize(user, jsonOption);
            string str3 = JsonSerializer.Serialize(user, options);
            string str4 = JsonSerializer.Serialize(user, _jOpt);

            User user2 = JsonSerializer.Deserialize<User>(str);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
