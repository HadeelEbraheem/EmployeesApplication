using EmployeeManagement.Helper;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;

namespace EmployeeManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        EmployeeAPI employeesAPI = new EmployeeAPI();

        private readonly IConfiguration Configuration;

        public EmployeeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            List<EmployeeInfo> employeeInfo = new List<EmployeeInfo>();
            HttpClient client = employeesAPI.Initial();
            client.DefaultRequestHeaders.Add("ApiKey", Configuration["ApiKey"]);
            HttpResponseMessage response = await client.GetAsync("Employee/GetEmployeeList");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                employeeInfo = JsonConvert.DeserializeObject<List<EmployeeInfo>>(result);
            }

            return View(employeeInfo);
        }

      

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeInfo employeeInfo )
        {
            var json = JsonConvert.SerializeObject(employeeInfo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = employeesAPI.Initial();
            client.DefaultRequestHeaders.Add("ApiKey", Configuration["ApiKey"]);
            HttpResponseMessage response = await client.PostAsync("Employee/Add",data);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        
    }
   

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            EmployeeInfo employeeInfo = new EmployeeInfo();
            HttpClient client = employeesAPI.Initial();
            client.DefaultRequestHeaders.Add("ApiKey", Configuration["ApiKey"]);
            HttpResponseMessage response = await client.GetAsync("Employee/Find/"+id);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                employeeInfo = JsonConvert.DeserializeObject<EmployeeInfo>(result);
            }

            return View(employeeInfo);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeInfo employeeInfo)
        {
            var json = JsonConvert.SerializeObject(employeeInfo);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = employeesAPI.Initial();
            client.DefaultRequestHeaders.Add("ApiKey", Configuration["ApiKey"]);
            HttpResponseMessage response = await client.PutAsync("Employee/Update/"+employeeInfo.EmployeeId, data);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = employeesAPI.Initial();
            client.DefaultRequestHeaders.Add("ApiKey", Configuration["ApiKey"]);
            HttpResponseMessage response = await client.DeleteAsync("Employee/Delete/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
                return View();
            }

    }
}
