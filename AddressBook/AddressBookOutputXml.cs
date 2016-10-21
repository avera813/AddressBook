using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookOutputXml : IAddressBookOutput
    {
        public string ToString(KeyValuePair<string, Address> address)
        {
            string output = "<contact>";
            output += System.Environment.NewLine;
            output += String.Format("  <name>{0}</name>", address.Key);
            output += System.Environment.NewLine;
            foreach(KeyValuePair<string,string> prop in address.Value.GetAddress())
            {
                output += String.Format("  <{0}>{1}</{0}>", prop.Key, prop.Value);
                output += System.Environment.NewLine;
            }
            output += "</contact>";
            return output;
        }
    }
}
