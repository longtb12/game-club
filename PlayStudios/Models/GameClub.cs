namespace PlayStudios.Models
{
    public class GameClub : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
