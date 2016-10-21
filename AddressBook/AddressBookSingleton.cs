using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookSingleton
    {
        private static AddressBookSingleton INSTANCE = new AddressBookSingleton();
        private AddressBookSingleton() { }

        public static AddressBookSingleton GetInstance()
        {
            return INSTANCE;
        }
        public AddressBookOutput GetOutput(string format)
        {
            format = format.ToUpper();
            switch (format)
            {
                case "JSON":
                    return new AddressBookOutputJson();
                case "XML":
                    return new AddressBookOutputXml();
                default:
                    return new AddressBookOutputText();
            }
        }
    }
}
