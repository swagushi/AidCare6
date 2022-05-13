using System.Collections.Generic;
namespace AidCare6.Models
{
    public class events
    {
        public int eventsID { get; set; }
        public string eventsLocation { get; set; }
        public string eventsDateTime { get; set; }
        public ICollection<membersevents> membersevents { get; set; }
    }
}
