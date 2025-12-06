namespace BackEvoEventos.Dtos
{
    public class UpdateRequestDto
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateOnly EventDate { get; set; }
        public int EventAttendees { get; set; }
        public string EventLocation { get; set; }
        public Guid? IdStatusRequest { get; set; }
        public Guid? IdEventType { get; set; }
        public string Message { get; set; }

        // Lista de servicios (opcional para actualizar)
        public List<Guid>? Services { get; set; }
    }
}
