using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookSingleton
    {
        private static readonly AddressBookSingleton Instance = new AddressBookSingleton();
        private AddressBookSingleton() { }

        public static AddressBookSingleton GetInstance()
        {
            return Instance;
        }
        public AddressBookOutput GetOutput(AddressBookOutputFormat format)
        {
            switch (format)
            {
                case AddressBookOutputFormat.JSON:
                    return new AddressBookOutputJson();
                case AddressBookOutputFormat.XML:
                    return new AddressBookOutputXml();
                default:
                    return new AddressBookOutputText();
            }
        }
    }
}
