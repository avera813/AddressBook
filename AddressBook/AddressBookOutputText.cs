using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookOutputText : IAddressBookOutput
    {
        public string ToString(KeyValuePair<string, Address> address)
        {
            return address.Key + ", " + address.Value.ToString();
        }
    }
}
