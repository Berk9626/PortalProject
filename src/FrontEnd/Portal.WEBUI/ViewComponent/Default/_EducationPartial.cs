using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portal.WEBUI.Dtos.EducationDto;

namespace Portal.WEBUI.ViewComponent.Default
{
    public class _EducationPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _EducationPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

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
    }
}
