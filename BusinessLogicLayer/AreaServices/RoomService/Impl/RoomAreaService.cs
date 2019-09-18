using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.AreaServices.RoomService.RoomFactory;
using BusinessLogicLayer.Domains;
using BusinessLogicLayer.ViewModels.RoomViewModels;
using DataAccessLayer.UnitOfWork;

namespace BusinessLogicLayer.AreaServices.RoomService.Impl
{
    public class RoomAreaService : IRoomAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoomFactory _roomFactory;
        public RoomAreaService(IUnitOfWork unitOfWork, IRoomFactory roomFactory)
        {
            _unitOfWork = unitOfWork;
            _roomFactory = roomFactory;
        }
        public RoomView CreateRoom(string currentUserId)
        {
            var room = _unitOfWork.GetRepository<Room>().GetAll().FirstOrDefault(x => x.CreatorId == currentUserId);
            var currentUser = _unitOfWork.GetRepository<AppUser>().FindBy(x => x.Id == currentUserId);
            if (room == null)
            {
                room = _unitOfWork.GetRepository<Room>().AddAndSave(_roomFactory.CreateRoom(currentUserId, new List<AppUser> { currentUser }));
            }
            return _roomFactory.CastToRoomView(room);
        }
    }
}