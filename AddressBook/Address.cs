using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Address
    {
        private Dictionary<string, string> address;

        // Constructor for an Address
        public Address(string street, string city, string state, string zip, string country)
        {
            address = new Dictionary<string, string>();
            address.Add("street", "");
            address.Add("city", "");
            address.Add("state", "");
            address.Add("zip", "");
            address.Add("country", "");
        }

        public void setSpec(string key, string value)
        {
            if(address.ContainsKey(key))
            {
                address.Remove(key);
                address.Add(key, value);
            }
        }

        public string getSpec(string key)
        {
            if(address.ContainsKey(key))
            {
                return address[key];
            }
            return "";
        }
        /*
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
        */
        override public string ToString()
        {
            return address["street"] + ", " + address["city"] + ", " + address["state"] + ", " + address["zip"] + ", " + address["country"];
        }
    }
}