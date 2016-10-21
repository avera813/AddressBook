using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookOutputXml : AddressBookOutput
    {
        protected override string GetLine(KeyValuePair<string, Address> address)
        {
            string output = "  <entry>";
            output += System.Environment.NewLine;
            output += String.Format("    <name>{0}</name>", address.Key);
            output += System.Environment.NewLine;
            foreach (KeyValuePair<string, string> prop in address.Value.GetAddress())
            {
                output += String.Format("    <{0}>{1}</{0}>", prop.Key, prop.Value);
                output += System.Environment.NewLine;
            }
            output += "  </entry>";
            return output;
        }

        public override string ToString(Dictionary<string, Address> addressBook)
        {
            string output = "<items>";
            for (int i = 0; i < addressBook.Count; ++i)
            {
                output += System.Environment.NewLine;
                output += GetLine(addressBook.ElementAt(i));
            }
            output += System.Environment.NewLine;
            output += "</items>";
            return output;
        }        
    }
}
