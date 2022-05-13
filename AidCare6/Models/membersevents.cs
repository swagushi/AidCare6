namespace AidCare6.Models
{
    public class membersevents
    {
        public int memberseventsId { get; set; }
        public string memberseventsName { get; set; }
        public string Email { get; set; }
        public string DateRegistered { get; set; }
        public int membersID { get; set; }
        public int eventsID { get; set; }
        public members members { get; set; }
        public events events { get; set; }
    }
}
