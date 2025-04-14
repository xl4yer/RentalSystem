namespace RentalSystem.Models
{
    public class Receipt
    {
        public string Id { get; set; } = string.Empty;
        public double ReservationFee { get; set; }
        public double RentalFee { get; set; }

    }
}
