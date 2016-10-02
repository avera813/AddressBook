using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBook
    {
        //private Address[] addresses;
        private List<Address> addresses = new List<Address>();

        private static int numberOfAddressBooks = 0;
        public static int countAddressBooks()
        {
            return numberOfAddressBooks;
        }

        public AddressBook()
        {
            numberOfAddressBooks++;
            addresses.Add(new Address("Joe Bloggs", "1 New St.", "Birmingham", "England", "B01 3TN", "UK"));
            addresses.Add(new Address("Jane Smith", "123 Fake St.", "Denver", "CO", "80123", "USA"));
            addresses.Add(new Address("John Doe", "16 S 31st St.", "Boulder", "CO", "80304", "USA"));
        }

        private int findIndex(Address address)
        {
            
            for (int index = 0; index < addresses.Count(); ++index)
                if (addresses.ElementAt(index).Equals(address))
                    return index;
            return -1;  // not found, returning an "impossible?" index
        }

        public List<Address> GetAll()
        {
            return addresses;
        }

        public void AddAddress(Address addressToAdd)
        {
            int index = findIndex(addressToAdd);
            if (!(index >= 0 && index < addresses.Count()))
            {
                addresses.Add(addressToAdd);
            }
        }

        public void UpdateAddress(Address oldAddress, Address updatedAddress)
        {
            int index = findIndex(oldAddress);
            if (index >= 0 && index < addresses.Count())
            {
                addresses.RemoveAt(index);
                addresses.Insert(index, updatedAddress);
            }
        }

        public void RemoveAddress(Address addressToRemove)
        {
            int index = findIndex(addressToRemove);
            if (index >= 0 && index < addresses.Count())
            {
                addresses.RemoveAt(index);
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