using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Address
    {
        private string name;  // the name field 
        public string Name    // the Name property
        {
            get
            {
                return name;
            }
        }

        private string street;  // the street field 
        public string Street    // the Street property
        {
            get
            {
                return street;
            }
        }

        private string city;  // the city field 
        public string City    // the City property
        {
            get
            {
                return city;
            }
        }

        private string state;  // the state field 
        public string State    // the State property
        {
            get
            {
                return state;
            }
        }

        private string zip;  // the zip field 
        public string Zip    // the Zip property
        {
            get
            {
                return zip;
            }
        }

        private string country;  // the country field 
        public string Country    // the Country property
        {
            get
            {
                return country;
            }
        }

        // Constructor for an Address
        public Address(String name, String street, String city, String state, String zip, String country)
        {
            this.name = name;
            this.street = street;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.country = country;
        }

        public bool Equals(Address other)
        {
            if (other == null)
            {  // This is required
                return false;
            }
            return this.name.Equals(other.name) &&
              this.street.Equals(other.Street) &&
              this.city.Equals(other.City) &&
              this.state.Equals(other.State) &&
              this.zip.Equals(other.Zip) &&
              this.country.Equals(other.Country);
        }

        public static Address ConvertToAddress(string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                string[] address = input.Split(',');

                if (address.Length == 6)
                {
                    string name = address[0].Trim();
                    string street = address[1].Trim();
                    string city = address[2].Trim();
                    string state = address[3].Trim();
                    string zip = address[4].Trim();
                    string country = address[5].Trim();
                    return new Address(name, street, city, state, zip, country);
                }
                return null;
            }
            return null;
        }

        override public string ToString()
        {
            return name + ", " + street + ", " + city + ", " + state + ", " + zip + ", " + country;
        }
    }
}