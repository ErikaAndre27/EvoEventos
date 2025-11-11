namespace BackEvoEventos.Models
{
    public class Auditory
    {
        public DateTime CreatedAt { get; set; } = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(-5)).DateTime;
        public DateTime? UpdatedAt { get; set; }
    }
}
