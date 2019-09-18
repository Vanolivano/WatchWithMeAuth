using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Domains;
using BusinessLogicLayer.ViewModels.RoomViewModels;

namespace BusinessLogicLayer.AreaServices.RoomService.RoomFactory.Impl
{
    public class RoomFactory : IRoomFactory
    {
        public RoomView CastToRoomView(Room room)
        {
            return new RoomView
            {
                Id = room.Id,
                Name = room.Name,
                Status = room.Status,
                CreatorId = room.Users.First().Id
            };
        }

        public Room CreateRoom(string creatorId, List<AppUser> users)
        {
            return new Room
            {
                Name = "WelcomeRoom",
                Status = "Open",
                CreatorId = creatorId,
                Users = users
            };
        }
    }
}