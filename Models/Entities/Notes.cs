namespace Todo_App_Backend.Models.Entities
{
    public class Notes
    {
        public Guid Id { get; set; }

        public required string Description { get; set; }
    }
}
