namespace RentalSystem.Models
{
    public class Gowns
    {
        public string Id { get; set; } = "";
        public string Type { get; set; } = "";
        public byte[]? Photo { get; set; }
        public string Name { get; set; } = "";
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";
        public double Fee { get; set; }
    }
}
