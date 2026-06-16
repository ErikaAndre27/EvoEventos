namespace BackEvoEventos.Dtos
{
    public class UpdateRequestDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly EventDate { get; set; }
        public int EventAttendees { get; set; }
        public string EventLocation { get; set; } = string.Empty;
        public Guid? IdStatusRequest { get; set; }
        public Guid? IdEventType { get; set; }
        public string Message { get; set; } = string.Empty;

        // Lista de servicios (opcional para actualizar)
        public List<Guid>? Services { get; set; }
    }
}
