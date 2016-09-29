using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Program
    {
        private static AddressBook contacts;

        static void Usage()
        {
            Console.WriteLine("Usage: AddressBook [command] ");
            Console.WriteLine("Where command is one of: ");
            Console.WriteLine("    list  - list the addresses.");
            Console.WriteLine("    add   - add to the addresses.");
            Console.WriteLine("    find  - find an address that matches.");
            Console.WriteLine("    update  - edit or update an address that matches.");
            Console.WriteLine("    remove  - remove an address that matches.");
            System.Environment.Exit(1);
        }

        static void List()
        {
            Address[] addressList = contacts.GetAll();
            for (int i = 0; i < addressList.Length; i++)
            {
                Console.WriteLine(addressList[i].ToString());
            }
        }

        static void Main(string[] args)
        {
            contacts = new AddressBook();

            if (null == args || 0 == args.Length || args[0].Equals(" "))
            {
                Usage();
            }

            if (args[0].Equals("list", StringComparison.CurrentCultureIgnoreCase))
            {
                List();
            }
            else if (args[0].Equals("add", StringComparison.CurrentCultureIgnoreCase))
            {
                if (args.Length < 2)
                {
                    Usage();
                }
                else
                {
                    string[] address = args[1].Split(',');
                    
                    if (address.Length == 6)
                    {
                        string nameToAdd = address[0].Trim();
                        string streetToAdd = address[1].Trim();
                        string cityToAdd = address[2].Trim();
                        string stateToAdd = address[3].Trim();
                        string zipToAdd = address[4].Trim();
                        string countryToAdd = address[5].Trim();

                        contacts.Add(new Address(nameToAdd, streetToAdd, cityToAdd, stateToAdd, zipToAdd, countryToAdd));

                        List();
                    }
                    else
                    {
                        Usage();
                    }
                }
            }
            else if (args[0].Equals("update", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine();
            }
            else if (args[0].Equals("remove", StringComparison.CurrentCultureIgnoreCase))
            {
                if (args.Length < 2)
                {
                    Usage();
                }
                else
                {
                    string[] address = args[1].Split(',');

                    if (address.Length == 6)
                    {
                        string nameToRemove = address[0].Trim();
                        string streetToRemove = address[1].Trim();
                        string cityToRemove = address[2].Trim();
                        string stateToRemove = address[3].Trim();
                        string zipToRemove = address[4].Trim();
                        string countryToRemove = address[5].Trim();

                        contacts.Remove(new Address(nameToRemove, streetToRemove, cityToRemove, stateToRemove, zipToRemove, countryToRemove));

                        List();
                    }
                    else
                    {
                        Usage();
                    }
                }
            }

            // perhaps we'll consider find, sort, print some other week

            else
            {
                Usage();
            }
        }
    }
}