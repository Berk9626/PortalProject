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
    public class EducationController : ControllerBase
    {

        private readonly IEducationService _educationService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public EducationController(IEducationService education, IWebHostEnvironment webHostEnvironment)
        {
            _educationService = education;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("EducationWithImage/{id}")]
        public IActionResult GetEducationWImage(int id)
        {
            try
            {
                EducationWithImage educationwithImage = new EducationWithImage(_webHostEnvironment);
                var model = _educationService.TGetById(id);
                if (model != null)
                {
                    model.ImageFile = educationwithImage.GetImagebyEducation(model.ImageFile);
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }






        //---------------------------------------------------------
        [HttpGet]
        public IActionResult EducationList()
        {
            try
            {
                var values = _educationService.TGetList();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetEducation(int id)
        {
            try
            {
                var model = _educationService.TGetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            try
            {
                _educationService.TInsert(education);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateEducation(Education education)
        {
            try
            {
                _educationService.TUpdate(education);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetAllWithImages")]
        public async Task<IActionResult> GetAllWithImages()
        {
            try
            {
                EducationWithImage educwimage = new EducationWithImage(_webHostEnvironment);
                var productlist = _educationService.TGetList();

                if (productlist != null && productlist.Count > 0)
                {
                    productlist.ForEach(item =>
                    {
                        item.ImageFile = educwimage.GetImagebyEducation(item.ImageFile);
                    });

                    return Ok(productlist);
                }
                else
                {
                    return Ok(new List<ResultEducationDto>());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


       
        [HttpDelete("DeleteEducation/{id}")]
        public IActionResult DeleteEducation(int id)
        {
            try
            {
                var values = _educationService.TGetById(id);
                _educationService.TDelete(values);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        //[HttpDelete("DeletedStatusEducation/{id}")]
        //public IActionResult DeletedStatusEducation(int id)
        //{
        //    try
        //    {
        //        var values = _EducationService.GetById(id);
        //        _EducationService.Delete(values);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
        //---------------------------------------------------------
        //[HttpGet("GetActivesEducation")]
        //public IActionResult GetActivesEducation()
        //{
        //    try
        //    {
        //        var values = _EducationService.GetActives();
        //        return Ok(values);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
        ////---------------------------------------------------------
        //[HttpGet("GetActiveEducation/{id}")]
        //public IActionResult GetActiveEducation(int id)
        //{
        //    try
        //    {
        //        var values = _EducationService.GetById(id);
        //        _EducationService.GetActive(values);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}
        //---------------------------------------------------------
    }
}
