namespace MuslimFashion.ViewModel
{
    public class CustomerAddressCrudModel
    {
        public int CustomerAddressId { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsDefault { get; set; }
    }
}