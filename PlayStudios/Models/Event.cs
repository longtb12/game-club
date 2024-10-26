namespace PlayStudios.Models
{
    public class Event : BaseEntity
    {
        public int ClubId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public GameClub Club { get; set; }
    }
}
