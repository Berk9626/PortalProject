using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.BusinessLayer.Abstract;
using Portal.EntityLayer;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService catservice)
        {
            _categoryService = catservice;
        }
        //---------------------------------------------------------
        [HttpGet]
        public IActionResult CategoryList()
        {
            try
            {
                var values = _categoryService.TGetList();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var model = _categoryService.TGetById(id);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                _categoryService.TInsert(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        //---------------------------------------------------------
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                _categoryService.TUpdate(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
