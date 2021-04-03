namespace MuslimFashion.Data
{
    public class CustomerAddress
    {
        public int CustomerAddressId { get; set; }
        public int CustomerRegistrationId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsDefault { get; set; }
    }
}