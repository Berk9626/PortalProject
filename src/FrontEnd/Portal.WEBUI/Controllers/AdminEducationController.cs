using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Portal.DataAccessLayer.Concrete;
using Portal.EntityLayer;
using Portal.WEBUI.Dtos.EducationDto;
using System.Text;

namespace Portal.WEBUI.Controllers
{
    [AllowAnonymous]
    public class AdminEducationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminEducationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
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
            var responseMessage = await client.GetAsync("http://localhost:5276/api/Education/GetAllWithImages");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEducationDto>>(jsonData);

                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddEducation()
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems = (from c in context.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CategoryName,
                                                          Value = c.CategoryId.ToString(),

                                                      }).ToList();

            ViewBag.dgr3 = selectedListItems;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddEducation(CreateEducationDto model)
        {
            Education education = new Education();
            if (model.ImageFile != null)
            {
                var extension = Path.GetExtension(model.ImageFile.FileName);
                string newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/educationImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                model.ImageFile.CopyTo(stream);
                education.ImageFile = newImageName;
                education.EducationName = model.EducationName;
                education.EducationDescribtion = model.EducationDescribtion;
                education.Quantity = model.Quantity;
                education.Price = model.Price;
                education.Kontenjan = model.Kontenjan;
                education.CategoryId = model.CategoryId;


            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(education);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5276/api/Education", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> UpdateEducation(int id)
        {
            Context context = new Context();
            List<SelectListItem> selectedListItems = (from c in context.Categories.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = c.CategoryName,
                                                          Value = c.CategoryId.ToString(),

                                                      }).ToList();

            ViewBag.dgr5 = selectedListItems;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5276/api/Education/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEducationDto>(jsonData);

                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEducation(UpdateEducationDto model)
        {
            //UpdateProductValidator validationRules = new UpdateProductValidator();
            Education education = new Education();

            //FluentValidation.Results.ValidationResult result = validationRules.Validate(model);
            //if (result.IsValid)
            //{
            if (model.ImagePath != null)
            {
                var extension = Path.GetExtension(model.ImagePath.FileName);
                string newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/educationImages/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                model.ImagePath.CopyTo(stream);
                education.ImageFile = newImageName;
                education.EducationId = model.EducationId;
                education.EducationName = model.EducationName;
                education.EducationDescribtion = model.EducationDescribtion;
                education.Quantity = model.Quantity;
                education.Price = model.Price;
                education.Kontenjan = model.Kontenjan;
                education.CategoryId = model.CategoryId;

            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(education);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5276/api/Education", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
            //}
        }
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5276/api/Education/DeleteEducation/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
