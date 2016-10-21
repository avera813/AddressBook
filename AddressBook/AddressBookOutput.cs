using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    abstract class AddressBookOutput
    {
        protected abstract string GetLine(KeyValuePair<string, Address> address);
        public abstract string ToString(Dictionary<string, Address> addressBook);
    }
}
