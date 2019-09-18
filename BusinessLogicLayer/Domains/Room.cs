using System.Collections.Generic;

namespace BusinessLogicLayer.Domains
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string CreatorId { get; set; }

        public List<AppUser> Users { get; set; }
    }
}