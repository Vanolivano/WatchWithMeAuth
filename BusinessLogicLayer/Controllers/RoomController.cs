using System.Security.Claims;
using BusinessLogicLayer.AreaServices.RoomService;
using BusinessLogicLayer.AreaServices.UserService;
using BusinessLogicLayer.Domains;
using BusinessLogicLayer.ViewModels.RoomViewModels;
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
        private readonly IRoomAreaService _roomAreaService;

        public RoomController(ILogger<RoomController> logger, IUserAreaService userAreaService, IRoomAreaService roomAreaService)
        {
            _logger = logger;
            _userAreaService = userAreaService;
            _roomAreaService = roomAreaService;
        }

        [HttpGet]
        public RoomView Get()
        {
            //var users = _userAreaService.GetUsers();
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var room = _roomAreaService.CreateRoom(currentUser);

            return room;
        }
        [HttpPost("[action]")]
        public void Edit([FromBody]RoomView roomView)
        {
            if(roomView.Id!=0)
            _roomAreaService.EditRoom(roomView);
        }
    }

}
