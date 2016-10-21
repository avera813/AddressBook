using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookOutputText : IAddressBookOutput
    {
        public string GetLine(KeyValuePair<string, Address> address)
        {
            return address.Key + ", " + address.Value.ToString();
        }

        public string ToString(Dictionary<string, Address> addressBook)
        {
            string output = "";
            for (int i = 0; i < addressBook.Count; ++i)
            {
                output += GetLine(addressBook.ElementAt(i));
                if(i != (addressBook.Count - 1))
                    output += System.Environment.NewLine;
            }
            return output;
        }
    }
}
