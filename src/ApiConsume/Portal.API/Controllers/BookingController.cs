using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal.BusinessLayer.Abstract;
using Portal.EntityLayer;

namespace Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookingController(IBookingService bookingService, IWebHostEnvironment webHostEnvironment)
        {
            _bookingService = bookingService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            try
            {
                _bookingService.TInsert(booking);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
