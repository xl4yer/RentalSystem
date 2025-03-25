namespace RentalSystem.Models
{
    public class Reservation
    {
        public string Id { get; set; } = "";
        public string Fullname { get; set; } = "";
        public DateTime Date { get; set; }
        public DateTime PickupDate { get; set; }
        public string Type { get; set; } = "";
        public byte[]? Photo { get; set; }
        public string Name { get; set; } = "";
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
        public double Fee { get; set; }
    }


}
