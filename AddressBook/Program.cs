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

        static void Usage(string command = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            switch (command)
            {
                case "add":
                    Console.WriteLine("Usage: AddressBook add \"John Smith, 123 Fake St., Seattle, WA, 98101, USA\"");
                    break;
                case "update":
                    Console.WriteLine("Usage: AddressBook update \"John Smith, 123 Fake St., Seattle, WA, 98101, USA\" \"Jane Doe, 456 Superior St., Bellevue, WA, 98004, USA\"");
                    break;
                case "remove":
                    Console.WriteLine("Usage: AddressBook remove \"John Smith, 123 Fake St., Seattle, WA, 98101, USA\"");
                    break;
                default:
                    Console.WriteLine("Usage: AddressBook [command] ");
                    Console.WriteLine("Where command is one of: ");
                    Console.WriteLine("    show  - list the addresses.");
                    Console.WriteLine("    add   - add to the addresses.");
                    Console.WriteLine("    update  - edit or update an address that matches.");
                    Console.WriteLine("    remove  - remove an address that matches.");
                    break;
            }
            Console.ResetColor();
            System.Environment.Exit(1);
        }

        static void Main(string[] args)
        {
            if (args == null || args.Length == 0 || args[0].Equals(" "))
            {
                Usage();
            }

            contacts = new AddressBook();

            if (args[0].ToLower().Equals("show"))
            {
                contacts.Print();
            }
            else if (args[0].ToLower().Equals("add"))
            {
                if (args.Length < 2 || args.Length > 2)
                {
                    Usage("add");
                }

                Address address = Address.ConvertToAddress(args[1]);
                if (address != null)
                {
                    contacts.AddAddress(address);
                    contacts.Print();
                }
                else
                {
                    Usage("add");
                }
            }
            else if (args[0].ToLower().Equals("update"))
            {
                if (args.Length < 3 || args.Length > 3)
                {
                    Usage("update");
                }

                Address oldAddress = Address.ConvertToAddress(args[1]);
                Address newAddress = Address.ConvertToAddress(args[2]);

                if (oldAddress != null && newAddress != null)
                {
                    contacts.UpdateAddress(oldAddress, newAddress);
                    contacts.Print();
                }
                else
                {
                    Usage("update");
                }
            }
            else if (args[0].ToLower().Equals("remove"))
            {
                if (args.Length < 2 || args.Length > 2)
                {
                    Usage("remove");
                }

                Address address = Address.ConvertToAddress(args[1]);
                if (address != null)
                {
                    contacts.RemoveAddress(address);
                    contacts.Print();
                }
                else
                {
                    Usage("remove");
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