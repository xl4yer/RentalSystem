namespace RentalSystem.Models
{
    public class Gowns
    {
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public byte[]? Photo { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public double Fee { get; set; }
    }
}
