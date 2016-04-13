using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirVinyl.Model
{
    // Address is a complex type (no key)

    [ComplexType]
    public class Address
    {
        [StringLength(200)]
        public string Street { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(100)]
        public string Country { get; set; }
    }
}
