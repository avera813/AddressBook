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
        private static string fileName;

        /// <summary>
        /// Displays help information for command if usage is not correct.
        /// </summary>
        /// <param name="command"></param>
        static void Usage(ConsoleCommand command = ConsoleCommand.NONE)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            switch (command)
            {
                case ConsoleCommand.ADD:
                    Console.WriteLine("Usage: AddressBook \"addressbook.dat\" add \"John Smith, 123 Fake St., Seattle, WA, 98101, USA\"");
                    break;
                case ConsoleCommand.UPDATE:
                    Console.WriteLine("Usage: AddressBook \"addressbook.dat\" update \"John Smith\" street \"456 Superior St.\"");
                    break;
                case ConsoleCommand.REMOVE:
                    Console.WriteLine("Usage: AddressBook \"addressbook.dat\" remove \"John Smith\"");
                    break;
                case ConsoleCommand.FIND:
                    Console.WriteLine("Usage: AddressBook \"addressbook.dat\" find name \"John\"");
                    Console.WriteLine("    seach by: name, street, city, state, zip, or country");
                    break;
                case ConsoleCommand.SORT:
                    Console.WriteLine("Usage: AddressBook \"addressbook.dat\" sort name");
                    Console.WriteLine("    sort by: name, street, city, state, zip, or country");
                    break;
                case ConsoleCommand.PRINT:
                    Console.WriteLine("Usage: AddressBook \"addressbook.dat\" print [format]");
                    Console.WriteLine("    available formats: JSON, XML, TEXT");
                    break;
                default:
                    Console.WriteLine("Usage: AddressBook \"[filename]\" [command] ");
                    Console.WriteLine("Where command is one of: ");
                    
                    Console.WriteLine("    add     - add to the addresses.");
                    Console.WriteLine("    find    - find an address that matches.");
                    Console.WriteLine("    remove  - remove an address that matches.");
                    Console.WriteLine("    show    - list the addresses.");
                    Console.WriteLine("    sort    - sort addresses based on field.");
                    Console.WriteLine("    update  - edit or update an address that matches.");
                    break;
            }
            Console.ResetColor();
            System.Environment.Exit(1);
        }

        static void PrintContacts(Dictionary<string, Address> entries, string format = "")
        {
            format = format.ToUpper();
            AddressBookOutput addressBook = AddressBookSingleton.GetInstance().GetOutput(format);

            Console.WriteLine(addressBook.ToString(entries));
        }

        /// <summary>
        /// AddressBook file to read. If file does not exists, the application will create a new one.
        /// </summary>
        /// <param name="fileName"></param>
        static void ReadFile(string fileName, bool ignoreNotFound)
        {
            try
            {
                contacts = AddressBookFormatter.Deserialize(fileName, ignoreNotFound);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// AddressBook file to write to. If file exists, the file is overwritten with new content.
        /// </summary>
        /// <param name="fileName"></param>
        static void WriteFile(string fileName)
        {
            try
            {
                AddressBookFormatter.Serialize(fileName, contacts);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            contacts = new AddressBook();

            if (args == null || args.Length < 2 || args[0].Equals(" "))
            {
                Usage();
            }

            fileName = args[0];

            if (args[1].ToLower().Equals("show"))
            {
                ReadFile(fileName, false);
                PrintContacts(contacts.GetAll());
            }
            else if (args[1].ToLower().Equals("add"))
            {
                ReadFile(fileName, true);
                if (args.Length != 3)
                    Usage(ConsoleCommand.ADD);

                string[] entry = args[2].Split(',').Select(prop => prop.Trim()).ToArray();

                if (entry.Length != 6)
                    Usage(ConsoleCommand.ADD);

                contacts.Add(entry[0], new Address(entry[1], entry[2], entry[3], entry[4], entry[5]));
                WriteFile(fileName);
            }
            else if (args[1].ToLower().Equals("update"))
            {
                ReadFile(fileName, false);
                if (args.Length != 5)
                    Usage(ConsoleCommand.UPDATE);

                string name = args[2];
                string keyToUpdate = args[3];
                string newValue = args[4];

                contacts.Update(name, keyToUpdate, newValue);
                WriteFile(fileName);
            }
            else if (args[1].ToLower().Equals("remove"))
            {
                ReadFile(fileName, false);
                if (args.Length != 3)
                    Usage(ConsoleCommand.REMOVE);

                string name = args[2];
                contacts.Remove(name);
                WriteFile(fileName);
            }
            else if (args[1].ToLower().Equals("find"))
            {
                ReadFile(fileName, false);
                if (args.Length != 4)
                    Usage(ConsoleCommand.FIND);

                Dictionary<string, Address> found = contacts.Find(args[2], args[3]);
                PrintContacts(found);
            }
            else if (args[1].ToLower().Equals("sort"))
            {
                ReadFile(fileName, false);
                if (args.Length != 3)
                    Usage(ConsoleCommand.SORT);

                contacts.Sort(args[2]);
                WriteFile(fileName);
            }
            else if(args[1].ToLower().Equals("print"))
            {
                ReadFile(fileName, true);
                if (args.Length != 3)
                    Usage(ConsoleCommand.PRINT);

                PrintContacts(contacts.GetAll(), args[2]);
            }
            else
            {
                Usage();
            }
        }
    }
}