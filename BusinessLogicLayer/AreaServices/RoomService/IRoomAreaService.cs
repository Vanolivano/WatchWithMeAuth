using BusinessLogicLayer.ViewModels.RoomViewModels;

namespace BusinessLogicLayer.AreaServices.RoomService
{
    public interface IRoomAreaService
    {
        RoomView CreateRoom(string currentUser);
    }
}