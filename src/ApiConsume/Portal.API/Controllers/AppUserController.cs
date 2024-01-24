using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.BusinessLayer.Abstract;
using Portal.EntityLayer;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUser)
        {
            _appUserService = appUser;
        }
        [HttpPut]
        public IActionResult UpdateAppUser(AppUser appUser)
        {
            try
            {
                _appUserService.TUpdate(appUser);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
