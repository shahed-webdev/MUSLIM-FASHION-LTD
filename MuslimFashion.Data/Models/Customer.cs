namespace MuslimFashion.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Registration Registration { get; set; }
    }
}