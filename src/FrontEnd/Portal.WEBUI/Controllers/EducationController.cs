using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Portal.DataAccessLayer.Concrete;
using Portal.EntityLayer;
using Portal.WEBUI.Dtos.EducationDto;
using Portal.WEBUI.Dtos.UserEducationDto;
using Portal.WEBUI.Models.CartModelsForMvc;
using System.Net.Http;
using System.Text;
//using Portal.WEBUI..Utils;

namespace Portal.WEBUI.Controllers
{
    [AllowAnonymous]
    public class EducationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public EducationController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }
        public async Task< IActionResult> Index()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var addedId =user.Id;



            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5276/api/UserEducation/UserIdList/{addedId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserEducationDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EducationDetail(int id)
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems = (from c in context.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CategoryName,
                                                          Value = c.CategoryId.ToString(),

                                                      }).ToList();

            ViewBag.dgr1 = selectedListItems;


          

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5276/api/Education/EducationWithImage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultEducationDto>(jsonData);

                return View(values);
            }
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost] //hangi kullanıcının hangi kursa katıldığı
        public async Task<IActionResult> EducationDetail(ResultEducationDto resultEdDto)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
          

            UserEducation userEducation = new UserEducation();

            userEducation.Id = user.Id;
            userEducation.EducationId = resultEdDto.EducationId;
            userEducation.IsCourseFinished = false;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(userEducation);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5276/api/UserEducation", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();




            
            
        }






    }
}
