using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBook
    {
        private Dictionary<string, Address> addresses;

        private static int numberOfAddressBooks = 0;
        public static int countAddressBooks()
        {
            return numberOfAddressBooks;
        }

        public AddressBook()
        {
            addresses = new Dictionary<string, Address>();
            numberOfAddressBooks++;
        }

        public Dictionary<string, Address> GetAll()
        {
            return addresses;
        }

        public void Add(string name, Address address)
        {
            if (!addresses.ContainsKey(name))
                addresses.Add(name, address);
        }
        
        public void Update(string name, string keyToUpdate, string newValue)
        {
            if (addresses.ContainsKey(name))
            {
                if (!keyToUpdate.Equals("name"))
                {
                    addresses[name].setSpec(keyToUpdate, newValue);
                }
                else if(keyToUpdate.Equals("name") && addresses.ContainsKey(name))
                {
                    Address tempAddress = addresses[name];
                    addresses.Remove(name);
                    addresses.Add(newValue, tempAddress);
                }
            }
        }
        
        public void Remove(string name)
        {
            if (addresses.ContainsKey(name))
                addresses.Remove(name);
        }

        public Dictionary<string,Address> Find(string key, string query)
        {
            key = key.ToLower();
            query = query.ToLower();

            Dictionary<string, Address> tempAddressBook = new Dictionary<string, Address>();
            foreach (KeyValuePair<string, Address> pair in addresses)
            {
                if (pair.Value.getSpec(key).ToLower().Contains(query) || key.Equals("name") && pair.Key.ToLower().Contains(query))
                {
                    tempAddressBook.Add(pair.Key, pair.Value);
                }
            }
            return tempAddressBook;
        }

        public void Sort(string key)
        {
            key = key.ToLower();
            Dictionary<string, Address> tempList = new Dictionary<string, Address>();
            if (key.Equals("name"))
            {                
                foreach (KeyValuePair<string, Address> item in addresses.OrderBy(prop => prop.Key))
                {
                    tempList.Add(item.Key, item.Value);
                }
            }
            else
            {
                foreach (KeyValuePair<string, Address> item in addresses.OrderBy(prop => prop.Value.getSpec(key)))
                {
                    tempList.Add(item.Key, item.Value);
                }
            }
            addresses = tempList;
        }
    }
}