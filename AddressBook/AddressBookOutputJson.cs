using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookOutputJson : IAddressBookOutput
    {
        private string GetLine(KeyValuePair<string, Address> address)
        {
            string output = "{";
            output += System.Environment.NewLine;
            output += String.Format("  \"{0}\" : \"{1}\"", "name", address.Key);
            foreach (KeyValuePair<string, string> prop in address.Value.GetAddress())
            {
                output += ",";
                output += System.Environment.NewLine;
                output += String.Format("  \"{0}\" : \"{1}\"", prop.Key, prop.Value);
            }
            output += System.Environment.NewLine;
            output += "}";
            return output;
        }
        public string ToString(Dictionary<string, Address> addressBook)
        {
            string output = "[";
            for (int i = 0; i < addressBook.Count; ++i)
            {
                output += GetLine(addressBook.ElementAt(i));

                if (i != (addressBook.Count - 1))
                    output += ",";
            }
            output += "]";
            return output;
        }
    }
}
