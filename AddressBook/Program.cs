using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Program
    {
        static List<string> contacts = new List<string>()
        {
            "Joe Bloggs, 1 New St., Birmingham B01 3TN, UK",
            "John Doe, 16 S 31st St., Boulder CO 80304, USA"
        };

        static void Usage()
        {
            Console.WriteLine("Usage: AddressBook [command] ");
            Console.WriteLine("Where command is one of: ");
            Console.WriteLine("    list  - list the addresses.");
            Console.WriteLine("    add   - add to the addresses.");
            Console.WriteLine("    find  - find an address that matches.");
            System.Environment.Exit(1);
        }

        static void List()
        {
            for (int i = 0; i < contacts.Count; ++i) {
                Console.WriteLine(contacts.ElementAt(i));
            }
        }

        static void Add(String address)
        {
            contacts.Add(address);
            List();
        }

        static void Find(String text)
        {
            foreach(String s in contacts)
            {
                if (s.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) > -1)
                {
                    Console.WriteLine(s);
                }
            }
        }

        static void Main(String[] args)
        {
            if (null == args || 0 == args.Length || args[0].Equals(""))
            {
                Usage();
            }

            if (args[0].Equals("list"))
            {
                List();
            } 
            else if (args[0].Equals("add")) 
            {
                if(args.Length > 1)
                {
                    Add(args[1]);
                }
                else
                {
                    Console.WriteLine("Usage: AddressBook add [text]");
                }
            } 
            else if (args[0].Equals("find"))
            {
                if(args.Length > 1)
                {
                    Find(args[1]);
                }
                else
                {
                    Console.WriteLine("Usage: AddressBook find [query]");
                }
            } 
            else
            {
                Usage();
            }
        }
    }
}