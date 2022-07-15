namespace CoachingApp.DTO
{
    public class CoachStatusDTO
    {
       public int ClientId { get; set; }
        public int SubId { get; set; }
        public DateTime StartDate { get; set; }
        public bool status { get; set; }

        public DateTime RequestDate { get; set; }
    }
}
