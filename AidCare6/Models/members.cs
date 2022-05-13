using System.Collections.Generic;

namespace AidCare6.Models
{
    public class members
    {
        public int membersId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<membersevents> membersevents { get; set; }
        public ICollection<donations> donations { get; set; }
    }
}
