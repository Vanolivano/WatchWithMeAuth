using System.Security.Claims;
using BusinessLogicLayer.AreaServices.UserService;
using BusinessLogicLayer.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace BusinessLogicLayer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IUserAreaService _userAreaService;

        public RoomController(ILogger<RoomController> logger, IUserAreaService userAreaService)
        {
            _logger = logger;
            _userAreaService = userAreaService;
        }

        [HttpGet]
        public RoomView Get()
        {
            var users = _userAreaService.GetUsers();
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = new AppUser
            {
                Id = "1",
                FirstName = "Ivanov"
            };
            var room = new RoomView
            {
                Id = 1,
                Name = "WelcomRoom",
                Status = "Open",
                CreatorId = "1"
            };
            return room;
        }
    }
    public class RoomView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string CreatorId { get; set; }
    }
}
