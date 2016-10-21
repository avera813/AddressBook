using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
                    Console.WriteLine("Usage: AddressBook update \"John Smith\" street \"456 Superior St.\"");
                    break;
                case "remove":
                    Console.WriteLine("Usage: AddressBook remove \"John Smith\"");
                    break;
                case "find":
                    Console.WriteLine("Usage: AddressBook find name \"John\"");
                    Console.WriteLine("    seach by: name, street, city, state, zip, or country");
                    break;
                case "sort":
                    Console.WriteLine("Usage: AddressBook sort name");
                    Console.WriteLine("    sort by: name, street, city, state, zip, or country");
                    break;
                default:
                    Console.WriteLine("Usage: AddressBook [command] ");
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

        static void PrintContacts(Dictionary<string, Address> entries)
        {
            foreach (KeyValuePair<string, Address> entry in entries)
            {
                Console.WriteLine(entry.Key.ToString() + ", " + entry.Value.ToString());
            }
        }

        /// <summary>
        /// AddressBook file to read. If file does not exists, the application will create a new one.
        /// </summary>
        /// <param name="fileName"></param>
        static void ReadFile(string fileName)
        {
            try
            {
                CheckFile checkFile = new CheckFile(fileName);
                FileStream fs = checkFile.GetReadFileStream();
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    contacts = (AddressBook)bf.Deserialize(fs);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Failed to read contents of file. Reason: " + ex.Message);
                }
                finally
                {
                    fs.Close();
                }
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
                CheckFile checkFile = new CheckFile(fileName);
                FileStream fs = checkFile.GetWriteFileStream();
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, contacts);
                }
                catch (SerializationException ex)
                {
                    Console.WriteLine("Failed to write contents of file. Reason: " + ex.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            contacts = new AddressBook();
            ReadFile(@"c:\test\addresses.dat");
            if (args == null || args.Length == 0 || args[0].Equals(" "))
            {
                Usage();
            }
            if (args[0].ToLower().Equals("show"))
            {
                PrintContacts(contacts.GetAll());
            }            
            else if (args[0].ToLower().Equals("add"))
            {
                if (args.Length != 2)
                    Usage("add");

                string[] entry = args[1].Split(',').Select(prop => prop.Trim()).ToArray();

                if (entry.Length != 6)
                    Usage("add");

                contacts.Add(entry[0], new Address(entry[1], entry[2], entry[3], entry[4], entry[5]));
                WriteFile("addresses.dat");
            }
            else if (args[0].ToLower().Equals("update"))
            {
                if (args.Length != 4)
                    Usage("update");

                string name = args[1];
                string keyToUpdate = args[2];
                string newValue = args[3];

                contacts.Update(name, keyToUpdate, newValue);
                WriteFile("addresses.dat");
            }
            else if (args[0].ToLower().Equals("remove"))
            {
                if (args.Length != 2)
                    Usage("remove");

                string name = args[1];

                contacts.Remove(name);
                WriteFile("addresses.dat");
            }
            else if (args[0].ToLower().Equals("find"))
            {
                if (args.Length != 3)
                    Usage("find");

                Dictionary<string, Address> found = contacts.Find(args[1], args[2]);
                PrintContacts(found);
            }
            else if (args[0].ToLower().Equals("sort"))
            {
                if (args.Length != 2)
                    Usage("sort");

                contacts.Sort(args[1]);
                WriteFile("addresses.dat");
            }
            else
            {
                Usage();
            }
        }
    }
}