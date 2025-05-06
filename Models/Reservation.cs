namespace RentalSystem.Models
{
    public class Reservation
    {
        public string Id { get; set; } = "";
        public string GownId { get; set; } = "";
        public string UserId { get; set; } = "";
        public string Fullname { get; set; } = "";
        public DateTime? Date { get; set; } = DateTime.Now;
        public DateTime? PickupDate { get; set; }
        public string Type { get; set; } = "";
        public byte[]? Photo { get; set; }
        public string Name { get; set; } = "";
        public string Color { get; set; } = "";
        public string Size { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
        public double ReservationFee { get; set; } = 500;
        public byte[]? Receipt { get; set; } = null;
        public double Fee { get; set; }
        public string Status { get; set; } = "";
        public double RentalFee { get; set; }
        public DateTime? DueDate { get; set; }
    }


}
