namespace BackEvoEventos.Dtos
{
    public class CreateUserDto
    {
        public string Names { get; set; }
        public string Surnames { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public Guid IdDocumentType { get; set; }
        public string DocumentNumber { get; set; }

        public Guid IdRole { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }
    }
}
