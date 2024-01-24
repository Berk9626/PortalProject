using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portal.EntityLayer;
using Portal.WEBUI.Dtos.AppUserProfileDto;
using System.Text;

namespace Portal.WEBUI.Controllers
{
    [AllowAnonymous]
    public class AppUserProfileController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserManager<AppUser> _userManager;

        public AppUserProfileController(IHttpClientFactory httpClientFactory, UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }
        public async Task< IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var addedId = user.Id;
            
            ResultAppUserProfileDto dto= new ResultAppUserProfileDto();
           dto.FirstName= user.FirstName;
           dto.LastName= user.LastName;
            dto.Email = user.Email;


            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ResultAppUserProfileDto dto)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var findingUserId = user.Id;

            user.FirstName= dto.FirstName;
            user.LastName= dto.LastName;
            user.Email= dto.Email;

            var client2 = _httpClientFactory.CreateClient();
            var jsonData2 = JsonConvert.SerializeObject(user);
            StringContent content2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
            var responseMessage2 = await client2.PutAsync("http://localhost:5276/api/AppUser", content2);


            //var newAppUserProfile = new AppUserProfile() 
            //{
            //    AppUser= findingUserId,
            //    FirstName= dto.FirstName,
            //    LastName= dto.LastName,
            //    Email= dto.Email,
            //    Address= dto.Address,
            //    Birthday= dto.Birthday,
            //    City = dto.City,
            //    PostalCode= dto.PostalCode,
            //    Phone = dto.Phone,
            //    ImageFile = dto.ImageFile,
            //    Country= dto.Country,
            //    Gender= dto.Gender,
            
            //};
            AppUserProfile appUserProfile = new AppUserProfile();
            appUserProfile.AppUser= user;
            appUserProfile.FirstName = dto.FirstName;
            appUserProfile.LastName = dto.LastName;
            appUserProfile.Email = dto.Email;
            appUserProfile.Address = dto.Address;
            appUserProfile.Birthday= dto.Birthday;
            appUserProfile.City= dto.City;
            appUserProfile.PostalCode= dto.PostalCode;
            appUserProfile.Phone= dto.Phone;
            appUserProfile.ImageFile= dto.ImageFile;
            appUserProfile.Country= dto.Country;
            appUserProfile.Gender= dto.Gender;



          

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(appUserProfile);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5276/api/AppUserProfile", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();




           
        }
    }
}
