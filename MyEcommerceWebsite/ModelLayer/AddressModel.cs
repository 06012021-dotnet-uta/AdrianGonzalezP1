using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    /// <summary>
    /// This Model represents an address
    /// </summary>
    public class AddressModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public AddressModel() { }

        /// <summary>
        /// This constructor is reponsible for initialzing the AddressModel object.
        /// </summary>
        /// <param name="Street"></param>
        /// <param name="City"></param>
        /// <param name="State"></param>
        /// <param name="Zipcode"></param>
        public AddressModel(string Street, string City, string State, string Zipcode)
        {
            this.Street = Street;
            this.City = City;
            this.State = State;
            this.ZipCode = Zipcode;
        }
    }
}
