using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookFormatter
    {
        public static void Serialize(string fileName, AddressBook contacts)
        {
            try
            {
                FileStream fs = CheckFile.GetWriteFileStream(fileName);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, contacts);
                fs.Close();
            }
            catch (SerializationException ex)
            {
                throw new Exception("Failed to write contents of file. Reason: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static AddressBook Deserialize(string fileName, bool ignoreNotFound)
        {
            AddressBook contacts;
            try
            {
                FileStream fs = CheckFile.GetReadFileStream(fileName, ignoreNotFound);
                BinaryFormatter bf = new BinaryFormatter();
                contacts = (AddressBook)bf.Deserialize(fs);
                fs.Close();
            }
            catch (ArgumentNullException)
            {
                contacts = new AddressBook();
            }
            catch (SerializationException ex)
            {
                throw new SerializationException("Failed to read contents of file. Reason: " + ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
            return contacts;
        }
    }
}
