using System.Collections.Generic;
using BusinessLogicLayer.Domains;
using BusinessLogicLayer.ViewModels.RoomViewModels;

namespace BusinessLogicLayer.AreaServices.RoomService.RoomFactory
{
    public interface IRoomFactory
    {
        RoomView CastToRoomView(Room room);
        Room CreateRoom(string creatorId, List<AppUser> users);
    }
}