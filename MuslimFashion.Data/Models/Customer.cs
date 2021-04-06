using System.Collections.Generic;

namespace MuslimFashion.Data
{
    public class Customer
    {
        public Customer()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Registration Registration { get; set; }
        public ICollection<CustomerAddress> CustomerAddress { get; set; }
    }
}