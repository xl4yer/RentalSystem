namespace RentalSystem.Models
{
    public class Rentals
    {
        public string Id { get; set; } = "";
        public string GownId { get; set; } = "";
        public string UserId { get; set; } = "";
        public string Fullname { get; set; } = "";
        public DateTime? Date { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public string Type { get; set; } = "";
        public byte[]? Photo { get; set; }
        public string Name { get; set; } = "";
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";
        public double RentalFee { get; set; }
        public string Status { get; set; } = "";
    }
}
