using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.BusinessLayer.Abstract;
using Portal.EntityLayer;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileService _appUserProfileService;
        public AppUserProfileController(IAppUserProfileService service)
        {
            _appUserProfileService = service;
        }
        [HttpPut]
        public IActionResult UpdateAppUserProfile(AppUserProfile appuserprofile)
        {
            try
            {
                _appUserProfileService.TUpdate(appuserprofile);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
