using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBook
    {
        private Address[] addresses;

        private static int numberOfAddressBooks = 0;
        public static int countAddressBooks()
        {
            return numberOfAddressBooks;
        }

        public AddressBook()
        {
            numberOfAddressBooks++;
            addresses = new Address[3];
            addresses[0] = new Address("Joe Bloggs", "1 New St.", "Birmingham", "England", "B01 3TN", "UK");
            addresses[1] = new Address("Jane Smith", "123 Fake St.", "Denver", "CO", "80123", "USA");
            addresses[2] = new Address("John Doe", "16 S 31st St.", "Boulder", "CO", "80304", "USA");
        }

        private int findIndex(Address address)
        {
            for (int index = 0; index < addresses.Length; ++index)
                if (addresses[index].Equals(address))
                    return index;
            return -1;  // not found, returning an "impossible?" index
        }

        public Address[] GetAll()
        {
            return addresses;
        }

        public void AddAddress(Address addressToAdd)
        {
            int index = findIndex(addressToAdd);
            if (!(index >= 0 && index < addresses.Length))
            {
                // create a new larger array
                Address[] revisedAddresses = new Address[addresses.Length + 1];
                // copy existing addresses into the new array
                for (int i = 0; i < addresses.Length; i++)
                    revisedAddresses[i] = addresses[i];
                // copy the new address into the array
                revisedAddresses[addresses.Length] = addressToAdd;
                // replace the old array with the new array
                this.addresses = revisedAddresses;
            }
        }

        public void UpdateAddress(Address oldAddress, Address updatedAddress)
        {
            int index = findIndex(oldAddress);
            this.addresses[index] = updatedAddress;
        }

        public void RemoveAddress(Address addressToRemove)
        {
            int index = findIndex(addressToRemove);
            if(index >= 0 && index < addresses.Length)
            {
                // create a new smaller array
                Address[] revisedAddresses = new Address[addresses.Length - 1];

                // set counter for included addresses
                int i = 0;

                foreach (Address address in addresses)
                {
                    // set condition to increment counter when match is not found
                    if (!address.Equals(addresses[index]))
                    {
                        revisedAddresses[i] = address;
                        i++;
                    }
                }

                // replace the old array with the new array
                this.addresses = revisedAddresses;
            }
        }

        //public Address Find(string search) // future enhancement?
        //{
        //}

        //public void Sort() // What does this even mean?
        //{
        //}

        public void Print() // Print contacts
        {
            foreach (Address address in addresses)
            {
                Console.WriteLine(address.ToString());
            }
        }
    }
}