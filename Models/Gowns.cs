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
        public string Status { get; set; } = "";
        public string? _Fee
        {
            get { return Fee.ToString("0.00"); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Fee = 0;
                }
                else
                {
                    Fee = double.Parse(value);
                }

            }
        }
    }
}
