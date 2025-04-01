namespace ProyectoFFXIV.Models
{
    public class EventParticipant
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string UserId { get; set; }
        public string CharacterClass { get; set; }

        // Relaciones
        public CalendarEvent Event { get; set; }
        public ApplicationUser User { get; set; }
    }
}