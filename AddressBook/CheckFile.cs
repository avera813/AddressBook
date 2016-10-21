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
    class CheckFile
    {
        public static FileStream GetReadFileStream(string fileName, bool ignoreNotFound)
        {
            FileStream fs = null;
            try
            {
                fs = File.OpenRead(@fileName);
            }
            catch (DirectoryNotFoundException)
            {
                if(!ignoreNotFound)
                    throw new DirectoryNotFoundException("Cannot find directory: " + fileName);
            }
            catch (FileNotFoundException)
            {
                if(!ignoreNotFound)
                    throw new FileNotFoundException("Cannot find file: " + fileName);
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Read access denied to file: " + fileName);
            }
            return fs;
        }

        public static FileStream GetWriteFileStream(string fileName)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(@fileName, FileMode.OpenOrCreate);
            }
            catch (DirectoryNotFoundException)
            {
                Directory.CreateDirectory(fileName);
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Write access denied to file: " + fileName);
            }
            return fs;
        }
    }
}
