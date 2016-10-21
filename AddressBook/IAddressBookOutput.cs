using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    interface IAddressBookOutput
    {
        string ToString(KeyValuePair<string, Address> address);
    }
}
