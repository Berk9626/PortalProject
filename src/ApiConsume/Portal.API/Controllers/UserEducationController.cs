using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.BusinessLayer.Abstract;
using Portal.EntityLayer;
using Portal.WEBUI.Dtos.EducationDto;
using Portal.WEBUI.Models.EducationWithImage;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEducationController : ControllerBase
    {
        
            private readonly IUserEducationService _UserEducationService;
             private readonly UserManager<AppUser> _userManager;
             private readonly IWebHostEnvironment _webHostEnvironment;
        public UserEducationController(IUserEducationService catservice, UserManager<AppUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _UserEducationService = catservice;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

       
        [HttpGet("UserIdList/{id}")]
        public IActionResult UserIdList(int id)
        {
           
            try
            {
                EducationWithImage educwimage = new EducationWithImage(_webHostEnvironment);

                var values = _UserEducationService.ListedByUserId(id);

                if (values != null && values.Count > 0)
                {
                    values.ForEach(item =>
                    {
                        item.Education.ImageFile = educwimage.GetImagebyEducation(item.Education.ImageFile);
                    });

                    return Ok(values);
                }
                else
                {
                    return Ok(new List<ResultEducationDto>());
                }



                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    




            //---------------------------------------------------------
            [HttpGet]
            public IActionResult UserEducationList()
            {
            


            try
                {
                    var values = _UserEducationService.TGetList();
                    return Ok(values);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            //---------------------------------------------------------
            [HttpGet("{id}")]
            public IActionResult GetUserEducation(int id)
            {
                try
                {
                    var model = _UserEducationService.TGetById(id);
                    return Ok(model);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            //---------------------------------------------------------
            [HttpPost]
            public IActionResult AddUserEducation(UserEducation UserEducation)
            {
                try
                {

                     _UserEducationService.TInsert(UserEducation);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            //---------------------------------------------------------
            [HttpPut]
            public IActionResult UpdateUserEducation(UserEducation UserEducation)
            {
                try
                {
                    _UserEducationService.TUpdate(UserEducation);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }

        }
}


