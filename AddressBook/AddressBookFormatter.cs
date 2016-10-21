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
            if( File.Exists(@fileName) || contacts.GetAll().Count > 0)
            {
                try
                {
                    FileStream fs = CheckFile.GetWriteFileStream(fileName);
                    if (contacts.GetAll().Count > 0)
                    {
                        try
                        {
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(fs, contacts);
                        }
                        catch (SerializationException ex)
                        {
                            throw new Exception("Failed to write contents of file. Reason: " + ex.Message);
                        }
                        finally
                        {
                            fs.Close();
                        }
                    }
                    else
                    {
                        fs.Close();
                        File.Delete(@fileName);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static AddressBook Deserialize(string fileName, bool ignoreNotFound)
        {
            AddressBook contacts = new AddressBook();
            try
            {
                FileStream fs = CheckFile.GetReadFileStream(fileName, ignoreNotFound);
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    contacts = (AddressBook)bf.Deserialize(fs);
                }
                catch (SerializationException ex)
                {
                    if(!ignoreNotFound)
                    {
                        throw new SerializationException("Failed to read contents of file. Reason: " + ex.Message);
                    }
                }
                finally
                {
                    fs.Close();
                } 
            } 
            catch (Exception)
            {
                throw;
            }
            return contacts;
        }
    }
}
